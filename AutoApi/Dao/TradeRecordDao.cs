using AutoApi.DataType;
using SharpDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.Dao
{
    public class TradeRecordDao : BaseDao
    {
        public async Task<List<TradeRecord>> ListTradeRecord(string coin)
        {
            var sql = $"select * from t_trade_record where Coin=@coin order by Id desc";
            return (await Database.QueryAsync<TradeRecord>(sql, new { coin })).ToList();
        }
    }
}
