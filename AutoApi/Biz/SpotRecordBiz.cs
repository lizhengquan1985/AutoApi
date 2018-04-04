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

        public async Task<List<SpotRecord>> ListSpotRecord(string coin, string order, string username, string fw, int count)
        {
            if (SpotRecordDao == null)
            {
                logger.Error("---------------- SpotRecordDao wei null");
            }
            var spotRecords = await SpotRecordDao.ListSpotRecord(coin, order, username, fw, count);
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

        public async Task<List<SpotRecordDTO>> ListSpotRecordDTO(string username)
        {
            return await SpotRecordDao.ListSpotRecordDTO(username);
        }
    }
}
