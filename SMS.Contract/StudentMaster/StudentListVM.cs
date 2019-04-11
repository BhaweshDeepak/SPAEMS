using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.StudentMaster
{
    public class StudentListVM
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string RegistrationNumber { get; set; }
        public string EnrollmentNumber { get; set; }
    }
}
