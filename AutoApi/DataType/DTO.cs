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
}
