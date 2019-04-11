using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Contract.Setting
{
    public class SectionMasterVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please select class")]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        [Required(ErrorMessage ="Please select section name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please select section Code")]
        public string Code { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
