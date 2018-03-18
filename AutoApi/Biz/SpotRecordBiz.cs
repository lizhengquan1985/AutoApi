using AutoApi.Dao;
using AutoApi.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.Biz
{
    public class SpotRecordBiz : BaseBiz
    {
        public SpotRecordDao SpotRecordDao { get; set; }

        public async Task<List<SpotRecord>> ListSpotRecord(string coin)
        {
            var spotRecords = await SpotRecordDao.ListSpotRecord(coin);
            foreach (var item in spotRecords)
            {
                item.BuyOrderResult = null;
                item.SellOrderResult = null;
                item.BuyAnalyze = null;
                item.SellAnalyze = null;
                item.BuyOrderQuery = null;
                item.SellOrderQuery = null;
            }
            return spotRecords;
        }
    }
}
