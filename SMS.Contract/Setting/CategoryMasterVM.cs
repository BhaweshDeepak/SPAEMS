using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Contract.Setting
{
    public class CategoryMasterVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category name is required")]
        public string Name { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
