using AutoApi.Dao;
using AutoApi.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.Biz
{
    public class TradeRecordBiz : BaseBiz
    {
        public TradeRecordDao TradeRecordDao { get; set; }

        public async Task<List<TradeRecord>> ListTradeRecord(string coin)
        {
            var tradeRecord = await TradeRecordDao.ListTradeRecord(coin);
            foreach(var item in tradeRecord)
            {
                item.BuyOrderResult = null;
                item.SellOrderResult = null;
                item.BuyAnalyze = null;
                item.SellAnalyze = null;
                item.BuyOrderQuery = null;
                item.SellOrderQuery = null;
            }
            return tradeRecord;
        }
    }
}
