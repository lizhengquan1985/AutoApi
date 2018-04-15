using AutoApi.Biz;
using AutoApi.hb;
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

        [HttpGet]
        [ActionName("line")]
        public async Task<object> StatisticsLine(string coin, string username = "lzq")
        {
            // 购买点
            var buy = await SpotRecordBiz.ListTradePointOfBuy(username, coin);
            // 出售点
            var sell = await SpotRecordBiz.ListTradePointOfSell(username, coin);
            // 走势
            var zs = AnaylyzeApi.kline(coin + "usdt", "1min", 1440).data;
            var min = (decimal)9999999;
            var max = (decimal)0;
            foreach (var item in zs)
            {
                if (min > item.low)
                {
                    min = item.low;
                }
                if (max < item.high)
                {
                    max = item.high;
                }
            }
            return new { zs, buy, sell, min, max };
        }
    }
}
