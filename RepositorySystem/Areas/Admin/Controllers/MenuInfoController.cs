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
    public class MenuInfoController : Controller
    {

        // GET: Menu
        private IMenuInfoBLL _menuInfoBLL;
        public MenuInfoController(IMenuInfoBLL menuInfo ) 
        {
            _menuInfoBLL = menuInfo;
        }
        public IActionResult ListView()
        {
            return View();
        }

        public IActionResult UpdateMenuInfoView()
        {
            return View();
        }

        public IActionResult CreateMenuInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取菜单列表的接口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="id"></param>
        /// <param name="MenuName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuInfos(int page, int limit, string id, string MenuName)
        {

            int count;

            List<GetMenuInfoDTO> list = _menuInfoBLL.GetAllMenuInfos(page, limit, id, MenuName, out count);

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
        /// 添加菜单的接口
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateMenuInfo([Form] MenuInfo infos)
        {
            string msg;

            bool isSuccess = _menuInfoBLL.CreateMenuInfo(infos, out msg);

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
        /// 菜单软删除接口
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IActionResult DeleteMenuInfo(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                 return Json(result);
            }

            bool isOK = _menuInfoBLL.DeleteMenuInfo(id);

            if (isOK)
            {
                result.Msg = "删除菜单成功";
                result.Code = 200;
            }

             return Json(result);
        }

        /// <summary>
        /// 菜单软删除接口，批量
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteMenuInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();
            if (ids == null || ids.Count == 0)
            {
                result.Msg = "选中菜单为空";
                 return Json(result);
            }
            bool isOk = _menuInfoBLL.DeleteMenuInfos(ids);
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
        /// 根据用户登录获取访问菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenus() 
        {
            //返回的菜单消息
            GetMenuDTO res = new GetMenuDTO();
            #region 测试数据
            //List<HomeMenuInfoDTO> menuInfoList = new List<HomeMenuInfoDTO>()
            //{
            //    new HomeMenuInfoDTO()
            //    {
            //        Title = "用户管理",
            //        Href = "/UserInfo/ListView",
            //        Icon = "fa fa-user",
            //        Target = "_self"
            //    },
            //    new HomeMenuInfoDTO()
            //    {
            //        Title = "系统管理",
            //        Href = "",
            //        Icon =  "fa fa-cog",
            //        Target = "_self",
            //        Child = new List<HomeMenuInfoDTO>
            //        {
            //            new HomeMenuInfoDTO()
            //            {
            //                Title = "角色管理",
            //                Href = "/RoleInfo/ListView",
            //                Icon = "fa fa-street-view",
            //                Target = "_self"
            //            }
            //        }
            //    }
            //};
            //res.MenuInfo[0].Child = menuInfoList;
            #endregion
            //构建菜单树
            string userId = HttpContext.Request.Cookies["UserId"];

            if (userId == null)
            {
                res = new GetMenuDTO(new List<HomeMenuInfoDTO>());
                 return Json(res);
            }
            else
            {
                List<HomeMenuInfoDTO> menuInfoList = _menuInfoBLL.GetAllHomeMenuInfos(userId);
                res = new GetMenuDTO(menuInfoList);
            }
            //res = new GetMenuDTO(menuInfoList);
             return Json(res);
        }

        /// <summary>
        /// 获取下拉列表的接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSelectOptions()
        {
            ReturnResult result = new ReturnResult();

            var data = _menuInfoBLL.GetSelectOptions();

            result.Code = 200;
            result.Msg = "获取成功";
            result.IsSuccess = true;
            result.Data = data;

             return Json(result);
        }

        [HttpPost]
        public IActionResult UpdateMenuInfo([Form] MenuInfo menuInfo)
        {
            string msg;
            bool isSuccess = _menuInfoBLL.UpdateMenuInfo(menuInfo, out msg);
            ReturnResult result = new ReturnResult();
            result.Msg = msg;
            result.IsSuccess = isSuccess;
            if (isSuccess)
            {
                result.Code = 200;
            }
             return Json(result);
        }
    }
}