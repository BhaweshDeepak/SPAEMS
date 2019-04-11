using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.StudentFinance.StudentFeeDeposit
{
    public class AutoCompleteStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string RollNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}
