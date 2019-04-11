using SMS.Contract.StudentFinance;
using SMS.Repository.StudentFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Controllers.StudentFinance
{
    public class FeeHeadController : Controller
    {
        private readonly IFeeHeadTypeRepository _feeHeadTypeRepository;
        public FeeHeadController(IFeeHeadTypeRepository feeHeadTypeRepository)
        {
            _feeHeadTypeRepository = feeHeadTypeRepository;
        }
        public ActionResult FeeHeadIndex()
        {
            return View();
        }

        public ActionResult CreateFeeHeadType(int id=0)
        {
            TempData["id"] = id;
            if(id==0)
            {
                return PartialView("~/Views/FeeHead/_FeeHeadTypePartial.cshtml");
            }
            else
            {
                var result = _feeHeadTypeRepository.GetEntityById(id);
                return PartialView("~/Views/FeeHead/_FeeHeadTypePartial.cshtml", result);
            }
          
        }
        [HttpPost]
        public JsonResult CreateFeeHeadType(FeeHeadMasterVM feeHeadMasterVM)
        {
            if(Convert.ToInt32(TempData["id"])==0)
            {
                feeHeadMasterVM.IsActive = 1;
                feeHeadMasterVM.CreatedBy = 1;
                var result = _feeHeadTypeRepository.InsertEntity(feeHeadMasterVM);
                return Json(result);
            }
            else
            {
                feeHeadMasterVM.IsActive = 1;
                feeHeadMasterVM.UpdatedDate = DateTime.Now.Date;
                feeHeadMasterVM.Updatedby = 1;
                feeHeadMasterVM.Id = Convert.ToInt32(TempData["id"]);
                var result = _feeHeadTypeRepository.UpdateEntity(feeHeadMasterVM);
                return Json(result);
            }

        }
        public ActionResult GetFeeHeadTypeList()
        {
            var result = _feeHeadTypeRepository.GetEntityList();
            return PartialView("~/Views/FeeHead/_FeeHeadGetList.cshtml", result);
        }

        public JsonResult DeleteHeadType(int id)
        {
            var result = _feeHeadTypeRepository.DeleteEntity(id);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}