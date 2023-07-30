using CommonLib;
using IBLL;
using Intersoft.Crosslight.Forms;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using RepositorySystemDotNetCore.Filters;

namespace RepositorySystemInterface.Controllers
{
    [Area("Admin")]
    [CustomAttribute]
    public class CategoryController : Controller
    {
        private ICategoryBLL _categoryBLL;
        public CategoryController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        // GET: Category
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreatetCategorView()
        {
            return View();
        }
        public IActionResult UpdateCategorView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCategories(int page, int limit, string id, string name)
        {
            int count;

            List<GetCategoryDTO> list = _categoryBLL.GetCategories(page, limit, id, name, out count);

            ReturnResult result = new ReturnResult()
            {
                Code = 0,
                Msg = "获取成功",
                Data = list,
                IsSuccess = true,
                Count = count
            };

            return Json(result);
        }
        [HttpPost]
        public IActionResult CreateCategory([Form] Category infos)
        {
            string msg;

            bool isSuccess = _categoryBLL.CreateCategory(infos, out msg);

            ReturnResult result = new ReturnResult();

            result.Msg = msg;

            result.IsSuccess = isSuccess;

            if (isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult UpdatCategory([Form] Category Info)
        {
            string msg;
            bool isSuccess = _categoryBLL.UpdateCategory(Info, out msg);
            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = isSuccess;
            if (isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);
        }

        public IActionResult DeletetCategory(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            bool isOK = _categoryBLL.DeleteCategory(id);

            if (isOK)
            {
                result.Msg = "删除分类成功";
                result.Code = 200;
            }

            return Json(result);
        }
        public ActionResult DeletetCategories(List<string> ids)
        {
            ReturnResult result = new ReturnResult();
            if (ids == null || ids.Count == 0)
            {
                result.Msg = "选中菜单为空";
                return Json(result);
            }
            bool isOk = _categoryBLL.DeleteCategory(ids);
            if (isOk)
            {
                result.Msg = "删除成功";
                result.Code = 200;
            }
            else
            {
                result.Msg = "删除失败";
            }
            return Json(result);
        }
    }
}