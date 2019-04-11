using SMS.Contract.StudentFinance;
using SMS.Contract.StudentFinance.StudentFeeComman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repository.StudentFinance
{
    public interface IFeeAllocationRepository
    {
        string AllocateStudentFee(FeeAllocationType feeAllocationType,string paramsData,string[] headId,string[] amount,string[] discountPerce,string[] discountAmnt, int [] paymentType);
        List<StudentFeeAllocationMasterVM> GetStudentAllocationListById(int allocationId);
    }
}
