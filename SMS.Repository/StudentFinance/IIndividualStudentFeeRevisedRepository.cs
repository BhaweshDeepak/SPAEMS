using SMS.Contract.StudentFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repository.StudentFinance
{
    public interface IIndividualStudentFeeRevisedRepository
    {
        IndividualStudentFeeRevisedVM GetStudentFeeInformation(int studentId);
    }
}
