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
    public class ConsumableInfoController : Controller
    {
        private IConsumableInfoBLL _consumableInfoBLL;
        private ICategoryBLL _categoryBLL;
        public ConsumableInfoController(IConsumableInfoBLL consumableInfoBLL, ICategoryBLL categoryBLL)
        {
            this._consumableInfoBLL = consumableInfoBLL;
            _categoryBLL = categoryBLL;
        }
        public IActionResult UpdateConsumableInfoView()
        {
            return View();
        }
        public IActionResult CreatetConsumableInfoView()
        {
            return View();
        }
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult GetAllConsumableInfos(int page, int limit, string id, string ConsumableName)
        {
            int count;

            List<GetConsumableInfoDTO> list = _consumableInfoBLL.GetAllConsumableInfos(page, limit, id, ConsumableName, out count);

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
        public ActionResult CreateConsumableInfo([Form] ConsumableInfo infos)
        {
            string msg;

            bool isSuccess = _consumableInfoBLL.CreateConsumableInfo(infos, out msg);

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
        public IActionResult UpdateConsumableInfo([Form] ConsumableInfo infos)
        {
            string msg;

            bool isSuccess = _consumableInfoBLL.UpdateConsumableInfo(infos, out msg);

            ReturnResult result = new ReturnResult();

            result.Msg = msg;

            result.IsSuccess = isSuccess;

            if (isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);
        }

        public IActionResult Upload(IFormFile file)
        {
            ReturnResult result = new ReturnResult();
            if (file == null || file.Length == 0)
            {
                result.Msg = "文件为空";
                return Json(result);
            }

            string extension = Path.GetExtension(file.FileName);//取文件后缀
            string userId = HttpContext.Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userId))
            {
                result.Msg = "上传用户的ID不存在";
                return Json(result);
            }

            Stream stream = file.OpenReadStream();
            string msg;
            bool success = false;

            switch (extension.ToLower())
            {
                case ".xls":
                case ".xlsx":
                    success = _consumableInfoBLL.Upload(stream, extension, userId, out msg);
                    break;
                default:
                    result.Code = 501;
                    result.Msg = "上传的文件只能是Excel类型";
                    return Json(result);
            }

            if (success)
            {
                result.Msg = "上传成功";
                result.Code = 200;
                return Json(result);
            }
            else
            {
                result.Msg = "上传失败";
                result.Code = 501;
                return Json(result);
            }
        }


        /// <summary>
        /// 获取下拉列表的接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSelectOptions()
        {
            ReturnResult result = new ReturnResult();

            var data = _categoryBLL.GetSelectOptions();

            result.Code = 200;
            result.Msg = "获取成功";
            result.IsSuccess = true;
            result.Data = data;

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

            bool isOK = _consumableInfoBLL.DeleteConsumableInfo(id);

            if (isOK)
            {
                result.Msg = "删除耗材成功";
                result.Code = 200;
            }

            return Json(result);
        }
        public IActionResult DeletetCategories(List<string> ids)
        {
            ReturnResult result = new ReturnResult();

            if (ids == null || ids.Count == 0)
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            bool isOK = _consumableInfoBLL.DeleteConsumableInfo(ids);

            if (isOK)
            {
                result.Msg = "删除耗材成功";
                result.Code = 200;
            }

            return Json(result);
        }
        public IActionResult DownLoadFile()
        {
            string downloadFileName;
            Stream stream = _consumableInfoBLL.GetDownload(out downloadFileName);
            return File(stream, "application/octet-stream", downloadFileName);
        }
    }
}