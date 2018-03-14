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
            return await TradeRecordDao.ListTradeRecord(coin);
        }
    }
}
