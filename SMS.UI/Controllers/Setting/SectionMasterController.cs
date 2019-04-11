using SMS.Contract.Setting;
using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Controllers.Setting
{
    public class SectionMasterController : Controller
    {
        private readonly ISectionMasterRepository _sectionMasterRepository;
        private readonly IClassMasterRepository _classMasterRepository;
        public SectionMasterController(ISectionMasterRepository sectionMasterRepository,IClassMasterRepository classMasterRepository)
        {
            _sectionMasterRepository = sectionMasterRepository;
            _classMasterRepository = classMasterRepository;
        }
        public ActionResult SectionIndex()
        {
            return View();
        }

        public ActionResult CreateSection(int id=0)
        {
            ViewBag.ClassMasterList = _classMasterRepository.GetEntityList();
            
            if(id==0)
            {
                return PartialView("~/Views/Shared/SectionMaster/_sectionMasterCreatePartial.cshtml");
            }
            else
            {
                var result = _sectionMasterRepository.GetEntityById(id);
                TempData["Id"] = result.Id;
                return PartialView("~/Views/Shared/SectionMaster/_sectionMasterCreatePartial.cshtml",result);
                
            }

        }

        [HttpPost]
        public JsonResult CreateSection(SectionMasterVM sectionMasterVM)
        {
            if(TempData["Id"] == null)
            {
                sectionMasterVM.CreatedBy = 1;
                sectionMasterVM.IsActive = 1;
                sectionMasterVM.CreatedDate = DateTime.Now.Date;
                var result = _sectionMasterRepository.InsertEntity(sectionMasterVM);
                return Json(result);
            }
            else
            {
                sectionMasterVM.UpdatedBy = 1;
                sectionMasterVM.UpdatedDate = DateTime.Now.Date;
                sectionMasterVM.IsActive = 1;
                sectionMasterVM.Id = Convert.ToInt32(TempData["Id"]);
                var result = _sectionMasterRepository.UpdateEntity(sectionMasterVM);
                return Json(result);
            }
        }

        public ActionResult GetSectionList()
        {
            var result = _sectionMasterRepository.GetEntityList();
            return PartialView("~/Views/Shared/SectionMaster/_sectionMasterListPartial.cshtml",result);
        }

        public JsonResult DeleteSection(int sectionId)
        {
            var result = _sectionMasterRepository.DeleteEntity(sectionId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}