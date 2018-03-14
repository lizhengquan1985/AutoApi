using SharpDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.Dao
{
    public class BaseDao : IBaseDao
    {
        public IDapperConnection Database { get; set; }
    }
}
