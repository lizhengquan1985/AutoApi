using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.DataType
{
    public class SpotRecordDTO
    {
        //dt '统计日期', sum(buytradeprice * buytotalquantity) '投出金额',count(1) '交易笔数',sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) '收益', sum(selltradeprice * selltotalquantity - buytradeprice * buytotalquantity) / sum(buytradeprice * buytotalquantity) '收益率' 
        public string 统计日期 { get; set; }
        public string 投出金额 { get; set; }
        public string 交易笔数 { get; set; }
        public string 收益 { get; set; }
        public string 收益率 { get; set; }
    }

    public class SpotRecordListDTO
    {
        public long Id { get; set; }
        public string Coin { get; set; }
        //public string AccountId { get; set; }
        public bool HasSell { get; set; }
        public string UserName { get; set; }


        public decimal BuyTotalQuantity { get; set; }
        public decimal BuyOrderPrice { get; set; }
        public decimal BuyTradePrice { get; set; }
        public DateTime BuyDate { get; set; }
        public bool BuySuccess { get; set; }


        public decimal SellTotalQuantity { get; set; }
        public decimal SellOrderPrice { get; set; }
        public decimal SellTradePrice { get; set; }
        public DateTime SellDate { get; set; }
        public bool SellSuccess { get; set; }

        //public string BuyOrderId { get; set; }
        //public string SellOrderId { get; set; }
    }
}
