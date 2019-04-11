using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.StudentFinance
{
    public class StudentFeeAllocationMasterVM
    {
        public int AllocationTypeId { get; set; }
        public int AllocationOn { get; set; }
        public int HeadTypeId { get; set; }
        public decimal Amount { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? DiscountPerc { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int FeeType { get; set; }
    }
}
