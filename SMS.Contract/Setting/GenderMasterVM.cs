using System;


namespace SMS.Contract.Setting
{
    public class GenderMasterVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
