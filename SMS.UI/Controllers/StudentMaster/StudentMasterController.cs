using SMS.Contract.StudentMaster;
using SMS.Repository.Setting;
using SMS.Repository.StudentMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Controllers.StudentMaster
{
    public class StudentMasterController:Controller
    {
        private readonly IStudentMasterRepository _studentMasterRepository;
        private readonly IGenderMasterRepository _genderMasterRepository;
        private readonly IClassMasterRepository _classMasterRepository;
        private readonly ISectionMasterRepository _sectionMasterRepository;
        private readonly IBloodGroupMasterRepository _bloodGroupMasterRepository;
        private readonly ICasteRepository _casteRepository;
        private readonly IReligionMasterRepository _religionMasterRepository;

        public StudentMasterController(IStudentMasterRepository studentMasterRepository,IGenderMasterRepository genderMasterRepository,
            IClassMasterRepository classMasterRepository,ISectionMasterRepository sectionMasterRepository,
            IBloodGroupMasterRepository bloodGroupMasterRepository,ICasteRepository casteRepository
            ,IReligionMasterRepository religionMasterRepository
            )
        {
            _studentMasterRepository = studentMasterRepository;
            _genderMasterRepository = genderMasterRepository;
            _classMasterRepository = classMasterRepository;
            _sectionMasterRepository = sectionMasterRepository;
            _bloodGroupMasterRepository = bloodGroupMasterRepository;
            _casteRepository = casteRepository;
            _religionMasterRepository = religionMasterRepository;
        }
        public ActionResult Index()
        {
            var result = _studentMasterRepository.GetStudentListVMs();
            return PartialView("~/Views/StudentMaster/_StudentList.cshtml",result);
        }


        // GET: StudentMaster/Create
        public ActionResult Create(int id = 0)
        {
            TempData["Id"] = id;
            ViewBag.ClassMaster = _classMasterRepository.GetEntityList();
            ViewBag.SectionMaster = _sectionMasterRepository.GetEntityList();
            ViewBag.GenderMaster = _genderMasterRepository.GetEntityList();
            ViewBag.BloodGroup = _bloodGroupMasterRepository.GetEntities();
            ViewBag.Caste = _casteRepository.GetEntities();
            ViewBag.Religion = _religionMasterRepository.GetEntityList();
            if(id == 0)
            {
                return View();
            }
            else
            {
                var result = _studentMasterRepository.GetEntities().Where(item => item.Id == id).ToList();
                return View(result.FirstOrDefault());
            }
        }

        // POST: StudentMaster/Create
        [HttpPost]
        public JsonResult Create(StudentMasterVM studentMasterVM)
        {
            studentMasterVM.IsActive = 1;
            studentMasterVM.CreatedBy = 1;
            studentMasterVM.Id = Convert.ToInt32(TempData["Id"]);
            var result = _studentMasterRepository.UpSertStudentMaster(studentMasterVM);
            return Json(result);
        }


  
    }
}
