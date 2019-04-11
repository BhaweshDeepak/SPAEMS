using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Contract;
using SMS.Contract.Setting;

namespace SMS.UI.Controllers.Setting
{
    public class ClassMasterController : Controller
    {
        private readonly IClassMasterRepository _classMasterRepository;
        public ClassMasterController(IClassMasterRepository classMasterRepository)
        {
            _classMasterRepository = classMasterRepository;
        }
        public ActionResult ClassMasterList()
        {
            return View();
        }

        public ActionResult GetClassMasterList()
        {
            var result = _classMasterRepository.GetEntityList();
            return PartialView("~/Views/Shared/ClassMaster/_ClassMasterListPartial.cshtml",result);
        }
        public JsonResult DeleteClassId(int Id)
        {
            var result = _classMasterRepository.DeleteEntity(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClassEdit(int Id)
        {
            TempData["id"] = Id;
            if(Id==0)
            {
                return PartialView("~/Views/Shared/ClassMaster/_ClassMasterCreatePartial.cshtml");
            }
            else
            {
                var result = _classMasterRepository.GetEntityById(Id);
                return PartialView("~/Views/Shared/ClassMaster/_ClassMasterCreatePartial.cshtml",result);
            }

        }
        [HttpPost]
        public JsonResult PostClassEdit(ClassMasterVm classMasterVm)
        {
            if(TempData["id"] == null || Convert.ToInt32(TempData["id"])==0)
            {
                classMasterVm.IsActive = 1;
                classMasterVm.UpdatedBy = 1;
                classMasterVm.UpdatedDate = DateTime.Now.Date;
                var result = _classMasterRepository.InsertEntity(classMasterVm);
                return Json(result);
            }
            else
            {
                classMasterVm.Id = Convert.ToInt32(TempData["id"]);
                classMasterVm.IsActive = 1;
                classMasterVm.CreatedBy = 1;

                 var result = _classMasterRepository.UpdateEntity(classMasterVm);
                return Json(result);
            }
        }
    }
}