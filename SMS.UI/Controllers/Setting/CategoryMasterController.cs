using SMS.Contract.Setting;
using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Controllers.Setting
{
    public class CategoryMasterController : Controller
    {
        private readonly ICategoryMasterRepossitory _categoryMasterRepossitory;
        public CategoryMasterController(ICategoryMasterRepossitory categoryMasterRepossitory)
        {
            _categoryMasterRepossitory = categoryMasterRepossitory;
        }
        public ActionResult CreateCategory(int id=0)
        {
            var result = _categoryMasterRepossitory.GetEntityById(id);
            return View(result);
        }

        public ActionResult GetCategoryList()
        {
            return View(_categoryMasterRepossitory.GetEntityList());
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryMasterVM categoryMasterVM)
        {
            categoryMasterVM.IsActive = 1;
            int id = Request.QueryString["id"]!= null ? Convert.ToInt32(Request.QueryString["id"]) :0;
            if(id==0)
            {
                _categoryMasterRepossitory.InsertEntity(categoryMasterVM);
            }
            else
            {
                categoryMasterVM.Id = Convert.ToInt32(id);
                _categoryMasterRepossitory.UpdateEntity(categoryMasterVM);
            }
   
            return View();
        }

        public JsonResult DeleteCategory(int id)
        {
            var result = _categoryMasterRepossitory.DeleteEntity(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}