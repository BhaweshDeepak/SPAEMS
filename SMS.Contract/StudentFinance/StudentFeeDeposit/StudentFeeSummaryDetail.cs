using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.StudentFinance.StudentFeeDeposit
{
    public class StudentFeeSummaryDetail
    {
        public decimal AllotedAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercenatge { get; set; }
        public decimal NetFeeAmount { get; set; }
        public string FeePaymentType { get; set; }
        public string HeadName { get; set; }
        public decimal AmountDeposited { get; set; }
    }
}
