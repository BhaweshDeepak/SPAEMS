using SMS.Contract.StudentFinance.StudentFeeComman;
using SMS.Repository.StudentFinance;
using System.Collections.Generic;
using SMS.Core;
using System.Linq;
using System.Linq.Expressions;
using SMS.Implementation.Comman;
using System;
using SMS.Contract.StudentFinance;

namespace SMS.Implementation.StudentFinance
{
    public class FeeAllocationRepository:IFeeAllocationRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public FeeAllocationRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string AllocateStudentFee(FeeAllocationType feeAllocationType,string paramsData,string[] headId,string[] amount, string [] discountPerce, string[] discountAmnt, int [] paymentType)
        {
            UpSertFeeAllocationMaster(feeAllocationType,paramsData,headId,amount,discountPerce,discountAmnt,paymentType);
            List<int> studentIds = new List<int>();
            switch(feeAllocationType)
            {
                case FeeAllocationType.Class:
                    studentIds = GetStudentListFromMapping(paramsData.ConvertStringTolistInt<int>());
                    DeActiveFeeForStudent(studentIds);
                    AllocateStudentFee(studentIds,headId,amount,discountAmnt,discountPerce,paymentType);
                    return "Class Fee Allocation";
                case FeeAllocationType.Gender:
                    List<int> genderIds = paramsData.ConvertStringTolistInt<int>();
                    studentIds = GetStudentListFromMaster(item => genderIds.Contains((int)item.GenderId));
                    DeActiveFeeForStudent(studentIds);
                    AllocateStudentFee(studentIds,headId,amount,discountAmnt,discountPerce,paymentType);
                    return "Gender Fee Allocation";
                case FeeAllocationType.Cast:
                    List<int> castIds = paramsData.ConvertStringTolistInt<int>();
                    studentIds = GetStudentListFromMaster(item => castIds.Contains((int)item.CastId));
                    DeActiveFeeForStudent(studentIds);
                    AllocateStudentFee(studentIds,headId,amount,discountAmnt,discountPerce,paymentType);
                    return "Cast Fee Allocation";
                case FeeAllocationType.Religion:
                    List<int> religionIds = paramsData.ConvertStringTolistInt<int>();
                    studentIds = GetStudentListFromMaster(item => religionIds.Contains((int)item.ReligionId));
                    DeActiveFeeForStudent(studentIds);
                    AllocateStudentFee(studentIds,headId,amount,discountAmnt,discountPerce,paymentType);
                    return "Religion Fee Allocation";
                case FeeAllocationType.Category:
                    List<int> categoryIds = paramsData.ConvertStringTolistInt<int>();
                    studentIds = GetStudentListFromMaster(item => categoryIds.Contains((int)item.CategoryId));
                    DeActiveFeeForStudent(studentIds);
                    AllocateStudentFee(studentIds,headId,amount,discountAmnt,discountPerce,paymentType);
                    return "Category Fee Allocation";
                default:
                    return "Default fee Allocation";
            }
        }

        public List<int> GetStudentListFromMapping(IList<int> ids)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.StudentClassMappings.Where((item => ids.Contains(item.classId))).Where(item => item.IsActive == 1).Select(x => x.StudentId).ToList();
                return result;
            }
        }

        public List<int> GetStudentListFromMaster(Expression<Func<Core.StudentMaster,bool>> expression)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.StudentMasters.Where(expression).Select(x => x.Id).ToList();
                return result;
            }
        }

        public string AllocateStudentFee(List<int> stdIds,string[] headTypeId,string[] amounts, string [] discount, string [] discountPer, int [] paymentType)
        {
            using(var dB_SPADevelopementEntities = new DB_SPADevelopementEntities())
            {
                for(int i = 0;i < stdIds.Count();i++)
                {
                    for(int j = 0;j < headTypeId.Count();j++)
                    {
                        var allotedAmount = new FeeAmountBasedOnPaymentType().CalcullateFeeAmount(paymentType[j],string.IsNullOrEmpty(amounts[j]) ? 0 : decimal.Parse(amounts[j]));
                        StudentFeeAllocation studentFeeAllocation = new StudentFeeAllocation();
                        studentFeeAllocation.StudentId = stdIds[i];
                        studentFeeAllocation.HeadTypeId = int.Parse(headTypeId[j]);
                        studentFeeAllocation.AllotedAmount = allotedAmount;
                        studentFeeAllocation.DiscountAmount =string.IsNullOrEmpty(discount[j])?0: decimal.Parse(discount[j]);
                        studentFeeAllocation.DiscountPercentage =string.IsNullOrEmpty(discountPer[j])?0: decimal.Parse(discountPer[j]);

                       // studentFeeAllocation.NetFeeAmount = new CalcullateNetAmount().GetCalcaullatedAmount(string.IsNullOrEmpty(discount[j])?0:decimal.Parse(discount[j]),string.IsNullOrEmpty(discountPer[j])?0: decimal.Parse(discountPer[j]),decimal.Parse(allotedAmount.ToString()));
                        studentFeeAllocation.IsActive = 1;
                        studentFeeAllocation.CreatedBy = 1;
                        studentFeeAllocation.CreatedDate = DateTime.Now.Date;
                        studentFeeAllocation.PaymentFeeType = Convert.ToInt32(paymentType[j]);
                        dB_SPADevelopementEntities.StudentFeeAllocations.Add(studentFeeAllocation);
                        dB_SPADevelopementEntities.SaveChanges();
                    }
                }

                return "Student fee allocation success";
            }
        }

        public void DeActiveFeeForStudent(List<int> id)
        {
            using(var dB_SPADevelopementEntities = new DB_SPADevelopementEntities())
            {
                if(dB_SPADevelopementEntities.StudentFeeAllocations.Where(item => id.Contains(item.StudentId)).Count() > 0)
                {
                    var result = dB_SPADevelopementEntities.StudentFeeAllocations.Where(item => id.Contains(item.StudentId)).ToList();
                    result.ForEach(item =>
                    {
                        item.IsActive = 0;
                        dB_SPADevelopementEntities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        dB_SPADevelopementEntities.SaveChanges();
                    });

                }
            }
        }

        public void UpSertFeeAllocationMaster(FeeAllocationType feeAllocationType,string allocationOn,string[] HeadType,string[] amount,string[] discountPercenatge,string[] discountAmount, int [] paymentType)
        {
            var allocationList = (string.Join(",",allocationOn)).ConvertStringTolistInt<int>();
            using(var dbContext = new DB_SPADevelopementEntities())
            {
                var result = dbContext.StudentFeeAllocationMasters.Where(item => allocationList.Contains(item.AllocationTypeId)).ToList();
                result.ForEach(item => 
                {
                    item.IsActive = 0;
                    item.UpdatedBy = 1;
                    item.UpDatedDate = DateTime.Now.Date;
                    dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                });

                for(int i=0; i< allocationOn.Count(); i++)
                {
                    for(int j=0; j< HeadType.Count(); j++)
                    {
                        StudentFeeAllocationMaster studentFeeAllocationMaster = new StudentFeeAllocationMaster();
                        studentFeeAllocationMaster.AllocationOn = Convert.ToInt32(allocationOn[i]);
                        studentFeeAllocationMaster.AllocationTypeId = Convert.ToInt32(feeAllocationType);
                        studentFeeAllocationMaster.HeadTypeId = Convert.ToInt32(HeadType[j]);
                        studentFeeAllocationMaster.Amount =  Convert.ToDecimal(amount[j]);
                        studentFeeAllocationMaster.DiscountPercenatge =! string.IsNullOrEmpty(discountPercenatge[j])? Convert.ToDecimal(discountPercenatge[j]) :0;
                        studentFeeAllocationMaster.DiscountAmount =!string.IsNullOrEmpty(discountAmount[j]) ? Convert.ToDecimal(discountAmount[j]) :0;
                        studentFeeAllocationMaster.FeeType = Convert.ToInt32(paymentType[j]);
                        
                        studentFeeAllocationMaster.IsActive = 1;
                        studentFeeAllocationMaster.CreatedBy = 1;

                        dbContext.StudentFeeAllocationMasters.Add(studentFeeAllocationMaster);
                        dbContext.SaveChanges();
                    }

                }
            }
        }

        public List<StudentFeeAllocationMasterVM> GetStudentAllocationListById(int allocationId)
        {
            using(var dbContext = new DB_SPADevelopementEntities())
            {
                List<StudentFeeAllocationMasterVM> studentFeeAllocationMasterVMs = new List<StudentFeeAllocationMasterVM>();
                var result = dbContext.StudentFeeAllocationMasters.Where(item => item.IsActive == 1 && item.AllocationTypeId == allocationId).ToList();
                result.ForEach(item => {
                    StudentFeeAllocationMasterVM studentFeeAllocationMasterVM = new StudentFeeAllocationMasterVM();
                    studentFeeAllocationMasterVM.AllocationTypeId = item.AllocationTypeId;
                    studentFeeAllocationMasterVM.AllocationOn = item.AllocationOn;
                    studentFeeAllocationMasterVM.HeadTypeId = item.HeadTypeId;
                    studentFeeAllocationMasterVM.Amount = item.Amount;
                    studentFeeAllocationMasterVM.DiscountPerc = item.DiscountPercenatge;
                    studentFeeAllocationMasterVM.DiscountAmount = item.DiscountAmount;
                    studentFeeAllocationMasterVM.FeeType =(int) item.FeeType;
                    studentFeeAllocationMasterVM.NetAmount = new CalcullateNetAmount().GetCalcaullatedAmount(Convert.ToDecimal(item.DiscountAmount),Convert.ToDecimal(item.DiscountPercenatge),item.Amount);
                    studentFeeAllocationMasterVMs.Add(studentFeeAllocationMasterVM);
                });
                return studentFeeAllocationMasterVMs;
            }
        }
    }
}
