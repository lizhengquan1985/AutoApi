using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.DataType
{
    public class SpotRecord
    {
        public long Id { get; set; }
        public string Coin { get; set; }
        public string AccountId { get; set; }
        public bool HasSell { get; set; }
        public string UserName { get; set; }


        public decimal BuyTotalQuantity { get; set; }
        public decimal BuyOrderPrice { get; set; }
        public decimal BuyTradePrice { get; set; }
        public DateTime BuyDate { get; set; }
        public string BuyOrderResult { get; set; }
        public bool BuySuccess { get; set; }


        public decimal SellTotalQuantity { get; set; }
        public decimal SellOrderPrice { get; set; }
        public decimal SellTradePrice { get; set; }
        public DateTime SellDate { get; set; }
        public string SellOrderResult { get; set; }
        public bool SellSuccess { get; set; }

        public string BuyAnalyze { get; set; }
        public string SellAnalyze { get; set; }

        public string BuyOrderId { get; set; }
        public string BuyOrderQuery { get; set; }
        public string SellOrderId { get; set; }
        public string SellOrderQuery { get; set; }
    }
}
