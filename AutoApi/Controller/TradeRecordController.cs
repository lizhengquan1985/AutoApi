using AutoApi.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AutoApi.Controller
{
    public class TradeRecordController : ApiController
    {
        public TradeRecordBiz TradeRecordBiz { get; set; }

        [HttpGet]
        public async Task<object> CoinBuyList(string coin)
        {
            return await TradeRecordBiz.ListTradeRecord(coin);
        }
    }
}
