using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System .ComponentModel .DataAnnotations;

namespace SMS.Contract
{
    public class InstitueDetail
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ValidationMessage), ErrorMessageResourceName = "InstitueDetailName", AllowEmptyStrings =false)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }
        public string AdminContactPersonName { get; set; }
        public string AdminPhone { get; set; }
        public string InstituteImage { get; set; }
        public string InstituteCode { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System .DateTime Createddate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System .DateTime> UpdatedDate { get; set; }
    }
}
