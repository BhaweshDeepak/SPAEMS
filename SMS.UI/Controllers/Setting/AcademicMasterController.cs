using SMS.Contract.Setting;
using SMS.Repository.Setting;
using System.Web.Mvc;

namespace SMS.UI.Controllers.Setting
{
    public class AcademicMasterController:Controller
    {
        private readonly IAcademicRepository _academicRepository;
        public AcademicMasterController(IAcademicRepository academicRepository)
        {
            _academicRepository = academicRepository;
        }
        public ActionResult AcademicList()
        {
            return View();
         
        }

        public ActionResult GetAcademicMasterList()
        {
            var result = _academicRepository.GetEntityList();
            return PartialView("~/Views/Shared/AcademicMaster/_AcademicMasterListPartial.cshtml",result);
        }

        public ActionResult CreateAcademicMaster(int id)
        {
            if(id == 0)
                return PartialView("~/Views/Shared/AcademicMaster/_AcademicMasterCreatePartial.cshtml");
            else
            {
                var result = _academicRepository.GetEntityById(id);
                return PartialView("~/Views/Shared/AcademicMaster/_AcademicMasterCreatePartial.cshtml",result);
            }
        }

        [HttpPost]
        public JsonResult CreateAcademicMaster(AcademicMasterVm academicMasterVm)
        {
            academicMasterVm.IsActive = 1;
            academicMasterVm.CreatedBy = 1;
            if(ModelState.IsValid)
            {
                var result = _academicRepository.InsertEntity(academicMasterVm);
                return Json(result);
            }
            else
            {
                return Json("Error in Academic creation");
            }
        }

        public JsonResult DeleteAcademicMaster(int id)
        {
            var result = _academicRepository.DeleteEntity(id);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}