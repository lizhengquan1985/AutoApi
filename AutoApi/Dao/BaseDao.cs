using log4net;
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
        protected ILog logger = LogManager.GetLogger(typeof(BaseDao));

        public IDapperConnection Database { get; set; }
    }
}
