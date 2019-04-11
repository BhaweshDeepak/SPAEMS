using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract
{
    public abstract class BaseVm<T>
    {
        public T Id { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
