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
    public class UserInfoController : Controller
    {
        // GET: Account
        private IUserInfoBLL _userInfoBLL;
        private IDepartmentInfoBLL _departmentInfoBLL;
        public UserInfoController(IUserInfoBLL userInfoBLL, IDepartmentInfoBLL departmentInfoBLL)
        {
            //_userInfoBLL = new UserInfoBLL();
            _userInfoBLL = userInfoBLL;
            _departmentInfoBLL = departmentInfoBLL;
        }
        // GET: UserInfo
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult UpdateUserInfoView()
        {
            return View();
        }
        public IActionResult CreateUserInfoView()
        {
            return View();

        }
        public IActionResult UserSetingView() { return View(); }
        public IActionResult UpdateUserInfoPasswordView() { return View(); }

        /// <summary>
        /// 获取用户的接口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="account"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfos(int page, int limit, string account, string userName)
        {
            int count;
            List<GetUserInfosDTO> list = _userInfoBLL.GetUserInfos(page, limit, account, userName, out count);

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

        /// <summary>
        /// 添加用户的接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUserInfo([Form] UserInfo user)
        {
            string msg;

            bool isSuccess = _userInfoBLL.CreateUserInfo(user, out msg);

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
        /// 用户软删除的接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteUserInfo(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                 return Json(result);
            }

            bool isOK = _userInfoBLL.DeleteUserInfo(id);

            if (isOK)
            {
                result.Msg = "删除用户成功";
                result.Code = 200;
            }

             return Json(result);
        }

        /// <summary>
        /// 用户软删除接口，批量
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteUserInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();
            if (ids == null||ids.Count == 0)
            {
                result.Msg = "选中用户为空";
                 return Json(result);
            }
            bool isOk =_userInfoBLL.DeleteUserInfo(ids);
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
        /// 更新用户的接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateUserInfo([Form] UserInfo user)
        {
            string msg;

            bool isSuccess = _userInfoBLL.UpdateUserInfo(user, out msg);

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
        /// 根据Id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfoById(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                 return Json(result);
            }
            
            var userInfo = _userInfoBLL.GetUserInfoById(id);
            var selectOption = _departmentInfoBLL.GetSelectOptions();

            result.Msg = "获取成功";
            result.Code = 200;
            result.IsSuccess = true;
            result.Data = new
            {
                userInfo,
                selectOption
            };
             return Json(result);
        }

        /// <summary>
        /// 根据id修改用户密码
        /// </summary>
        [HttpPost]
        public IActionResult UpdateUserInfoPassword(string Id, string OldPassword, string NewPassword, string AgainPassword)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(Id))
            {
                result.Msg = "id不能为空";
                 return Json(result);
            }
            string msg;
            result.IsSuccess = _userInfoBLL.UpdateUserInfoPassword(Id,OldPassword,NewPassword,AgainPassword,out msg);
            if(result.IsSuccess == true)
            {
                result.Code=200;
                result.Msg = msg;
            }
            else
            {
                result.Code = 501;
                result.Msg=msg;
            }
             return Json(result);
        }
    }
}