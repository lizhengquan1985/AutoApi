using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AutoApi.Controller
{
    public class SpotRecordController : ApiController
    {
        [HttpGet]
        public async Task<object> CoinBuyList(string coin)
        {
            return 1;
        }
    }
}
