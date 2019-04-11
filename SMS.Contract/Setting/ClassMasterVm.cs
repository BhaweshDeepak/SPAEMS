using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contract.Setting
{
    public class ClassMasterVm:BaseVm<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
