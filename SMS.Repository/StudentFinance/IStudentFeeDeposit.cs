using SMS.Contract.StudentFinance.StudentFeeDeposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repository.StudentFinance
{
    public interface IStudentFeeDeposit
    {
        IDictionary<int,string> GetAutoCompleteFeild(string entityData,int autoCompleteType);
        List<AutoCompleteStudent> GetStudentDetailById(int entityId);
        List<StudentFeeSummaryDetail> GetStudentFeeSummaryDetails(int studentId);
    }
}
