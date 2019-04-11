using SMS.Contract.StudentFinance;
using SMS.Contract.StudentFinance.StudentFeeComman;
using SMS.Repository.Setting;
using SMS.Repository.StudentFinance;
using SMS.Repository.StudentMaster;
using SMS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Controllers.StudentFinance
{
    public class StudentFeeAllocationController:Controller
    {
        private readonly IStudentMasterRepository _studentMasterRepository;
        private readonly IGenderMasterRepository _genderMasterRepository;
        private readonly IClassMasterRepository _classMasterRepository;
        private readonly ISectionMasterRepository _sectionMasterRepository;
        private readonly IBloodGroupMasterRepository _bloodGroupMasterRepository;
        private readonly ICasteRepository _casteRepository;
        private readonly IReligionMasterRepository _religionMasterRepository;
        private readonly IFeeAllocationRepository _feeAllocationRepository;
        private readonly IFeeHeadTypeRepository _feeHeadTypeRepository;


        public StudentFeeAllocationController(IStudentMasterRepository studentMasterRepository,IGenderMasterRepository genderMasterRepository,
            IClassMasterRepository classMasterRepository,ISectionMasterRepository sectionMasterRepository,
            IBloodGroupMasterRepository bloodGroupMasterRepository,ICasteRepository casteRepository
            ,IReligionMasterRepository religionMasterRepository,IFeeAllocationRepository feeAllocationRepository,IFeeHeadTypeRepository feeHeadTypeRepository)
        {
            _studentMasterRepository = studentMasterRepository;
            _genderMasterRepository = genderMasterRepository;
            _classMasterRepository = classMasterRepository;
            _sectionMasterRepository = sectionMasterRepository;
            _bloodGroupMasterRepository = bloodGroupMasterRepository;
            _casteRepository = casteRepository;
            _religionMasterRepository = religionMasterRepository;
            _feeAllocationRepository = feeAllocationRepository;
            _feeHeadTypeRepository = feeHeadTypeRepository;
        }
        public ActionResult StudentFeeAllocationIndex()
        {
            return View();
        }

        public JsonResult GetAllocationType(int id)
        {
            switch(id)
            {
                case 1:
                    return Json(_classMasterRepository.GetEntityList(),JsonRequestBehavior.AllowGet);
                case 2:
                    return Json(_genderMasterRepository.GetEntityList(),JsonRequestBehavior.AllowGet);
                case 3:
                    return Json(_casteRepository.GetEntities(),JsonRequestBehavior.AllowGet);
                case 4:
                    return Json(_religionMasterRepository.GetEntityList(),JsonRequestBehavior.AllowGet);
                case 5:
                    return Json(_casteRepository.GetEntities(),JsonRequestBehavior.AllowGet);
                default:
                    return Json("No data available",JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult StudentFeeAllocation(int allocationId,string allocationOn)
        {

            TempData["allocationId"] = allocationId;
            TempData["allocationOn"] = allocationOn;
            ViewBag.FeeType = new FeeTypeModel().GetFeeTypeModelList();

            List<FeeHeadMasterVM> result = _feeHeadTypeRepository.GetEntityList();
            var allocatedAmount = _feeAllocationRepository.GetStudentAllocationListById(allocationId);
            if(allocatedAmount.Count() > 0)
            {
                result.ForEach(item =>
                {
                    allocatedAmount.ForEach(allo =>
                    {
                        if(item.Id == allo.HeadTypeId)
                        {
                            item.Amount = allo.Amount;
                            item.DiscountAmount = allo.DiscountAmount;
                            item.DiscountPercenatge = allo.DiscountPerc;
                            item.NetAmount = allo.NetAmount;
                            item.FeeType = allo.FeeType;
                        }
                    });

                });
            }
            return View("~/Views/StudentFeeAllocation/_FeeHeadListPartial.cshtml",result);
        }

        [HttpPost]
        public JsonResult FeeAllocationInsert(string[] txtFeeHeadId,string[] txtAmount, string [] txtDiscountAmnt, string [] txtDiscountPer, int [] ddlPaymentType)
        {
            FeeAllocationType feeAllocationType = (FeeAllocationType)(int)TempData["allocationId"];
            var result = _feeAllocationRepository.AllocateStudentFee(feeAllocationType,TempData["allocationOn"].ToString(),txtFeeHeadId,txtAmount,txtDiscountPer, txtDiscountAmnt, ddlPaymentType);
            return Json(result);
        }
    }
}