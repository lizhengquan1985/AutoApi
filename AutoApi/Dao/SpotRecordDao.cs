using AutoApi.DataType;
using SharpDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.Dao
{
    public class SpotRecordDao : BaseDao
    {
        public async Task<List<SpotRecord>> ListSpotRecord(string coin, string order, string username, string fw, int count)
        {
            var where = $"where 1=1";
            var limit = "";
            if (!string.IsNullOrEmpty(coin))
            {
                where += $" and Coin=@coin";
            }
            else
            {
                limit += $"limit 0, {count}";
            }
            if (!string.IsNullOrEmpty(username))
            {
                where += $" and username='{username}'";
            }
            if (fw == "1")
            {
                where += $" and hassell=1";
            }
            else if (fw == "2")
            {
                where += $" and hassell=0";
            }
            where += $" and not (hassell=1 and selldate<'{DateTime.Now.AddDays(-2)}')";
            if (string.IsNullOrEmpty(order))
            {
                order = "Id";
            }
            var sql = $"select * from t_spot_record {where} order by {order} desc {limit}";
            return (await Database.QueryAsync<SpotRecord>(sql, new { coin })).ToList();
        }

        public async Task<List<SpotRecordDTO>> ListSpotRecordDTO(string username)
        {
            var sql = "select dt '统计日期', sum(buytradeprice * buytotalquantity) '投出金额',count(1) '交易笔数',sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) '收益', sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) / sum(buytradeprice * buytotalquantity) '收益率' from(select *, DATE_FORMAT(selldate, '%m-%d-%Y') dt from t_spot_record where sellsuccess = 1 and username = @username) t group by dt desc;";
            return (await Database.QueryAsync<SpotRecordDTO>(sql, new { username})).ToList();
        }

        /* 2月28日开始总收益 */
        //select username, coin, selltradeprice, selltotalquantity, buytradeprice, buytotalquantity, selltradeprice*selltotalquantity - buytradeprice * buytotalquantity '单笔收益', selltradeprice / buytradeprice,selldate from t_spot_record where sellsuccess = 1 order by selldate desc;
        //select min(buydate) '起始日期',max(selldate) '结束日期',sum(buytradeprice * buytotalquantity) '投出金额',count(1) '交易笔数',sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) '收益', sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) / sum(buytradeprice * buytotalquantity) '收益率' from t_spot_record where sellsuccess = 1;
        //select sum(buytradeprice* buytotalquantity) '套牢金额',count(1) '套牢笔数' from t_spot_record where sellsuccess = 0;
        //select coin, count(1) '交易笔数', sum(buytotalquantity - selltotalquantity) '收益' from t_spot_record where sellsuccess = 1 group by coin;
        //select dt '-----统计日期', sum(buytradeprice * buytotalquantity) '投出金额',count(1) '交易笔数',sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) '收益', sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) / sum(buytradeprice * buytotalquantity) '收益率' from(select *, DATE_FORMAT(selldate, '%m-%d-%Y %H') dt from t_spot_record where sellsuccess = 1) t group by dt desc;

    }
}
