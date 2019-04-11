using SMS.Repository.StudentFinance;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using SMS.Contract.StudentFinance.StudentFeeDeposit;

namespace SMS.UI.Controllers.StudentFinance
{
    public class StudentFeeDepositController:Controller
    {
        private readonly IStudentFeeDeposit _studentFeeDeposit;
        private readonly IFeeHeadTypeRepository _feeHeadTypeRepository;
        public StudentFeeDepositController(IStudentFeeDeposit studentFeeDeposit,IFeeHeadTypeRepository feeHeadTypeRepository)
        {
            _studentFeeDeposit = studentFeeDeposit;
            _feeHeadTypeRepository = feeHeadTypeRepository;
        }
        public ActionResult Index()
        {
            return View("~/Views/StudentFeeDeposit/StudentFeeDeposit.cshtml");
        }

        public  JsonResult Index(int [] headTypeId, decimal [] amount, decimal [] discountAmount, string [] discountDescription, int [] paymentFor)
        {
            return Json("");
        }

        public JsonResult GetStudentInfoList(string entity,int type)
        {
            var result = _studentFeeDeposit.GetAutoCompleteFeild(entity,type);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudentList(int studentId)
        {
            var result = _studentFeeDeposit.GetStudentDetailById(studentId);
            return PartialView(result);
        }

        public JsonResult GetStudentInformationById(int studentId)
        {
            var result = _studentFeeDeposit.GetStudentDetailById(studentId);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudentFeeDepositDetail(int studentId)
        {
            var result = _studentFeeDeposit.GetStudentFeeSummaryDetails(studentId);
            return PartialView(result);

        }

        public ActionResult StudentDepositPartial()
        {
            var result = _feeHeadTypeRepository.GetEntityList();
            return PartialView(result);
        }
    }
}