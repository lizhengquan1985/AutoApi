using AutoApi.Biz;
using AutoApi.Dao;
using Autofac;
using Autofac.Integration.WebApi;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SharpDapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dependencies;

namespace AutoApi
{
    public class Startup
    {
        public static IDependencyResolver DependencyResolver { get; set; }
        public void Configuration(IAppBuilder app)
        {
            // In OWIN you create your own HttpConfiguration rather than
            // re-using the GlobalConfiguration.
            var config = new HttpConfiguration();

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
                "DefaultActionApi",
                "{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            var builder = new ContainerBuilder();
            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(GetType().Assembly).PropertiesAutowired();

            //注册 ApplicationService
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(type => (typeof(BaseBiz).IsAssignableFrom(type) || typeof(IBaseDao).IsAssignableFrom(type)))
                .AsSelf().PropertiesAutowired()
                .InstancePerRequest();

            builder.Register<SpotRecordBiz>(c => new SpotRecordBiz()).OnActivated(e =>
            {
            }).InstancePerRequest();

            //注册数据库对象
            builder.Register<IDapperConnection>(ctx => new DapperConnection(new MySqlConnection(ConfigurationManager.ConnectionStrings["mysql"].ToString()))).InstancePerRequest();

            // Create and assign a dependency resolver for Web API to use.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DependencyResolver = config.DependencyResolver;

            // The Autofac middleware should be the first middleware added to the IAppBuilder.
            // If you "UseAutofacMiddleware" then all of the middleware in the container
            // will be injected into the pipeline right after the Autofac lifetime scope
            // is created/injected.
            //
            // Alternatively, you can control when container-based
            // middleware is used by using "UseAutofacLifetimeScopeInjector" along with
            // "UseMiddlewareFromContainer". As long as the lifetime scope injector
            // comes first, everything is good.
            app.UseAutofacMiddleware(container);

            // Again, the alternative to "UseAutofacMiddleware" is something like this:
            // app.UseAutofacLifetimeScopeInjector(container);
            //app.UseMiddlewareFromContainer<FirstMiddleware>();
            //app.UseMiddlewareFromContainer<ContextMiddleware>();

            // Make sure the Autofac lifetime scope is passed to Web API.

            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
