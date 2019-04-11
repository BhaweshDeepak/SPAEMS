using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Contract.Setting
{
    public class AcademicMasterVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Academic name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Academic Start date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage ="Academic end date is required")]
        public DateTime EndDate { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
