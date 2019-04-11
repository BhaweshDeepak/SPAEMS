using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.StudentFinance
{
    public class FeeHeadMasterVM
    {
        public int Id { get; set; }
        public string HeadName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? DiscountPercenatge { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? NetAmount { get; set; }
        public int FeeType { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Updatedby { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
