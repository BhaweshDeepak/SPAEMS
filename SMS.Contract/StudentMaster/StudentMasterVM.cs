using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Contract.StudentMaster
{
    public class StudentMasterVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Father name is required")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Mother name is required")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "Registration is required")]
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Roll number is required")]
        public string RollNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is  required")]
        public int? GenderId { get; set; }
        [Required(ErrorMessage = "Blood group is required")]
        public int? BloodGroup { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "Caste is required")]
        public int? CastId { get; set; }
        public int? ReligionId { get; set; }
        [Required(ErrorMessage = "Aadhar number  is required")]
        public string AdharCardNumber { get; set; }
        [Required(ErrorMessage = "Father Phone is required")]
        public string FatherPhone { get; set; }
        [Required(ErrorMessage = "Contact phone is required")]
        public string ContactPhone { get; set; }
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Class name is required")]
        public int ClassId { get; set; }
        [Required(ErrorMessage ="Address is required")]
        public string Adddress { get; set; }
        [Required(ErrorMessage = "Section name is required")]
        public int SectionId { get; set; }
        [Required(ErrorMessage ="Academic year is required")]
        public int AcademicYear { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? UpdatedBy { get; set; }
    }
}
