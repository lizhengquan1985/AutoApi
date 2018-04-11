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
        public async Task<object> CoinBuyList(string coin, string order, string username, string fw, int count = 800)
        {
            try
            {
                return await SpotRecordBiz.ListSpotRecord(coin, order, username, fw, count);
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
            var list = await SpotRecordBiz.ListSpotRecordDTO(username);
            var total = (double)0;
            list.ForEach(it => total += double.Parse(it.收益));
            return new { data = list, total };
        }
    }
}
