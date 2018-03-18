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
        public async Task<List<SpotRecord>> ListSpotRecord(string coin)
        {
            var sql = $"select * from t_spot_record where Coin=@coin order by Id desc";
            return (await Database.QueryAsync<SpotRecord>(sql, new { coin })).ToList();
        }
    }
}
