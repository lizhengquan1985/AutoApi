using AutoApi.Biz;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AutoApi.Controller
{
    public class SpotRecordController : ApiController
    {
        protected ILog logger = LogManager.GetLogger(typeof(SpotRecordController));

        public SpotRecordBiz SpotRecordBiz { get; set; }


        [HttpGet]
        [ActionName("list")]
        public async Task<object> CoinBuyList(string coin, string order, string username, string fw)
        {
            try
            {
                return await SpotRecordBiz.ListSpotRecord(coin, order, username, fw);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return null;
            }
        }

        [HttpGet]
        [ActionName("listdto")]
        public async Task<object> ListSpotRecordDTO(string username = "lzq")
        {
            return await SpotRecordBiz.ListSpotRecordDTO(username);
        }
    }
}
