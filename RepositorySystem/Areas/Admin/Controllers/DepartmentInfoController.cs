using CommonLib;
using IBLL;
using Intersoft.Crosslight.Forms;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using RepositorySystemDotNetCore.Filters;
using System.Collections.Generic;

namespace RepositorySystemInterface.Controllers
{
    [Area("Admin")]
    [CustomAttribute]
    public class DepartmentInfoController : Controller
    {
        /// <summary>
        /// 部门表数据
        /// </summary>
        private IDepartmentInfoBLL _departmentInfoBLL;
        public DepartmentInfoController(IDepartmentInfoBLL departmentInfoBLL)
        {
            _departmentInfoBLL = departmentInfoBLL;
        }

        // GET: DepartmentInfo
        public IActionResult ListView()
        {
            return View();
        }

        /// <summary>
        /// 获取所有部门表的接口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="departmentInfoId"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepartmentInfos(int page, int limit, string departmentInfoId, string departmentName)
        {

            int count;

            List<GetDepartmentInfoDTO> list = _departmentInfoBLL.GetDepartmentInfos(page, limit, departmentInfoId, departmentName, out count);

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
        public IActionResult UpdateDepartmentInfoView()
        {
            return View();
        }

        public IActionResult CreateDepartmentInfoView()
        {
            return View();
        }

        /// <summary>
        /// 添加部门的接口
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDepartmentInfo([Form] DepartmentInfo infos)
        {
            string msg;

            bool isSuccess = _departmentInfoBLL.CreateDepartmentInfo(infos, out msg);

            ReturnResult result = new ReturnResult();

            result.Msg = msg;

            result.IsSuccess = isSuccess;

            if (isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);
        }

        /// <summary>
        /// 部门软删除接口
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IActionResult DeleteDepartmentInfo(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            bool isOK = _departmentInfoBLL.DeleteDepartmentInfo(id);

            if (isOK)
            {
                result.Msg = "删除部门成功";
                result.Code = 200;
            }

            return Json(result);
        }

        /// <summary>
        /// 部门软删除接口，批量
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteDepartmentInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();
            if (ids == null || ids.Count == 0)
            {
                result.Msg = "选中部门为空";
                return Json(result);
            }
            bool isOk = _departmentInfoBLL.DeleteDepartmentInfos(ids);
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

        /// <summary>
        /// 更新部门的接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdatDepartmentInfo([Form] DepartmentInfo department)
        {
            string msg;

            bool isSuccess = _departmentInfoBLL.UpdateDepartmentInfo(department, out msg);

            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = isSuccess;
            if (isSuccess)
            {
                result.Code = 200;
            }
            return Json(result);
        }

        /// <summary>
        /// 获取下拉列表的接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSelectOptions()
        {
            ReturnResult result = new ReturnResult();

            var data = _departmentInfoBLL.GetSelectOptions();

            result.Code = 200;
            result.Msg = "获取成功";
            result.IsSuccess = true;
            result.Data = data;

            return Json(result);
        }

        /// <summary>
        /// 获取下拉列表的接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDepartmentInfoById(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "Id不能为空";
                return Json(result);
            }
            DepartmentInfo department = _departmentInfoBLL.GetDepartmentInfoById(id);
            if (department == null)
            {
                result.Msg = "未获取到部门信息";

            }
            else
            {
                var selectOption = _departmentInfoBLL.GetSelectOptions();
                result.Code = 200;
                result.Msg = "获取成功";
                result.Data = new
                {
                    department,
                    selectOption
                };
            }
            return Json(result);
        }
    }
}