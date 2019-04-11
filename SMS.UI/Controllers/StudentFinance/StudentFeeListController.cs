using SMS.Repository.StudentFinance;
using System.Web.Mvc;

namespace SMS.UI.Controllers.StudentFinance
{
    public class StudentFeeListController : Controller
    {
        private readonly IStudentFeeAllocationListRepository _studentFeeAllocationListRepository;
        public StudentFeeListController(IStudentFeeAllocationListRepository studentFeeAllocationListRepository)
        {
            _studentFeeAllocationListRepository = studentFeeAllocationListRepository;
        }
        public ActionResult StudentFeeDetail()
        {
            var result = _studentFeeAllocationListRepository.GetStudentFeeList();
            return View(result);
        }
    }
}