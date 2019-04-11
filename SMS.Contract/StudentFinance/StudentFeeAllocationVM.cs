using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.StudentFinance
{
    public class StudentFeeAllocationVM
    {
        public int AllocationId { get; set; }
        public int StudentId { get; set; }
        public int HeadTypeId { get; set; }
        public decimal AllotedAmount { get; set; }
        public decimal DiscountPercenatge { get; set; }
        public decimal DisountAmount { get; set; }
        public int PaymentType { get; set; }
    }
}
