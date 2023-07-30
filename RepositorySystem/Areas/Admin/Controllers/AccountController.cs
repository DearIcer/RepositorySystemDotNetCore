using CommonLib;
using IBLL;
using Microsoft.AspNetCore.Mvc;

namespace RepositorySystemInterface.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        // GET: Account
        private IUserInfoBLL _userInfoBLL;
        public AccountController(IUserInfoBLL userInfoBLL)
        {
            _userInfoBLL = userInfoBLL;
        }
        public IActionResult LoginView()
        {
            return View();
        }

        /// <summary>
        /// 登录的接口
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string account,string password)
        {
            ReturnResult result = new ReturnResult();

            //判断账号密码合法性
            if(string.IsNullOrWhiteSpace(account))
            {
                result.Msg = "账号不能为空";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                result.Msg = "密码不能为空";
                return Json(result);
            }

            string msg;
            string userName;
            string userId;

            // 调用登录业务
            bool isSuccess = _userInfoBLL.Login(account, password, out msg, out userName, out userId);

            result.Msg = msg;

            if(isSuccess)
            {
                result.IsSuccess = isSuccess;
                result.Code = 0;
                result.Data = userName;

                HttpContext.Session.SetString("UserId", userId);
                HttpContext.Session.SetString("UserName", userName);             
                CookieOptions options = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(2),
                };
                Response.Cookies.Append("UserId", userId, options);
                Response.Cookies.Append("UserName", userName, options);
                return Json(result);
            }
            else
            {
                result.Code = 500;

                return Json(result);
            }
        }
    }
}