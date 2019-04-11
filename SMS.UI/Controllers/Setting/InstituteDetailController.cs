using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Contract;
using SMS.Repository.Setting;

namespace SMS.UI.Controllers.Setting
{
    public class InstituteDetailController:Controller
    {
        private readonly IInstituteRepository _instituteRepository;
        public InstituteDetailController(IInstituteRepository instituteRepository)
        {
            _instituteRepository = instituteRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateInstitute(InstitueDetail model)
        {

            if(ModelState.IsValid)
            {
                string fileName = string.Empty;
                if(Request.Files.Count>0)
                {
                    var file = Request.Files[0];
                    file.SaveAs(Server.MapPath("~/InstituteImage/" + file.FileName));
                    fileName = "~/InstituteImage/" + file.FileName;
                }
                model.InstituteImage = fileName;
                var result = _instituteRepository.InsertEntity(model);
                return Json(result);
            }
            return Json("Errro in validation");

        }
    }
}