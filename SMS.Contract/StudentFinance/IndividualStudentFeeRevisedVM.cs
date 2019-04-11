using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.StudentFinance
{
    public class IndividualStudentFeeRevisedVM
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string RegistrationNumber { get; set; }
        public string RollNumber { get; set; }
        public string SectionName { get; set; }
        public int HeadTypeId { get; set; }
        public string HeadName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercenatge { get; set; }
    }
}
