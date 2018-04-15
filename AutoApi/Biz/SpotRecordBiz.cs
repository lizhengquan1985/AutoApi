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

        public async Task<List<SpotRecordListDTO>> ListSpotRecord(string coin, string order, string username, string fw, int count)
        {
            if (SpotRecordDao == null)
            {
                logger.Error("---------------- SpotRecordDao wei null");
            }
            var spotRecords = await SpotRecordDao.ListSpotRecord(coin, order, username, fw, count);
            var result = new List<SpotRecordListDTO>();
            foreach (var item in spotRecords)
            {
                result.Add(CopyUtils.Mapper<SpotRecordListDTO, SpotRecord>(item));
            }
            return result;
        }

        public async Task<List<SpotRecordDTO>> ListSpotRecordDTO(string username)
        {
            return await SpotRecordDao.ListSpotRecordDTO(username);
        }

        public async Task<List<TradePoint>> ListTradePointOfBuy(string username, string coin)
        {
            return await SpotRecordDao.ListTradePointOfBuy(username, coin);
        }
        public async Task<List<TradePoint>> ListTradePointOfSell(string username, string coin)
        {
            return await SpotRecordDao.ListTradePointOfSell(username, coin);
        }
    }
}
