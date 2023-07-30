﻿using CommonLib;
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
    public class RoleInfoController : Controller
    {
        // GET: RoleInfo
        private RepositorySystemContext _dbContext;
        private IRoleInfoBLL _roleInfo;
        private IUserInfoBLL _userInfoBLL;
        private IMenuInfoBLL _menuInfoBLL;
        public RoleInfoController(RepositorySystemContext dbcontext , IRoleInfoBLL roleInfo, IUserInfoBLL userInfoBLL ,IMenuInfoBLL menuInfoBLL)
        { 
            this._dbContext = dbcontext;
            this._roleInfo = roleInfo;
            this._userInfoBLL = userInfoBLL;
            this._menuInfoBLL = menuInfoBLL;
        }
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult CreateRoleInfoView()
        {
            return View();
        }
        public IActionResult UpdateRoleInfoView()
        {
            return View();
        }
        public IActionResult BindUserInfoView()
        {
            return View();
        }
        public IActionResult BindMenuInfoView()
        {
            return View();
        }

        /// <summary>
        /// 获取所有的角色表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="id"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public IActionResult GetRoleInfos(int page, int limit, string id, string RoleName)
        {
            int count;

            List<GetRoleInfoDTO> list = _roleInfo.GetAllRoleInfos(page, limit, id, RoleName, out count);

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
        /// 添加角色的接口
        /// </summary>
        /// <param name="role">页面传入的角色实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateRoleInfo([Form] RoleInfo role)
        {
            string msg;

            bool isSuccess = _roleInfo.CreateRoleInfo(role, out msg);

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
        /// 更新角色信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateRoleInfo([Form] RoleInfo role)
        {
            string msg;

            bool isSuccess = _roleInfo.UpdateRoleInfo(role, out msg);

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
        /// 角色软删除，单实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteRoleInfo(string id)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            bool isOK = _roleInfo.DeleteRoleInfo(id);

            if (isOK)
            {
                result.Msg = "删除角色成功";
                result.Code = 200;
            }

            return Json(result);
        }

        /// <summary>
        /// 角色软删除，多实例
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteRoleInfos(List<string> ids)
        {
            ReturnResult result = new ReturnResult();
            if (ids == null || ids.Count == 0)
            {
                result.Msg = "选中角色为空";
                return Json(result);
            }
            bool isOk = _roleInfo.DeleteRoleInfo(ids);
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
        /// 获取用户未绑定数据集的接口
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfoOptions(string roleId)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(roleId))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            List<GetUserInfosDTO> options = _userInfoBLL.GetUserInfos();
            List<string> UserIds = _roleInfo.GetBindUserIds(roleId);
            result.Data = new
            {
                options,
                UserIds
            };
            result.Code = 200;
            result.Msg = "获取成功";
            result.IsSuccess = true;
            return Json(result);
        }

        /// <summary>
        /// 获取菜单未绑定数据集的接口
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuInfoOptions(string roleId)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(roleId))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            List<GetMenuInfoDTO> options = _menuInfoBLL.GetAllMenuInfos();
            List<string> MenuIds = _roleInfo.GetBindMenuIds(roleId);
            result.Data = new
            {
                options,
                MenuIds
            };
            result.Code = 200;
            result.Msg = "获取成功";
            result.IsSuccess = true;
            return Json(result);
        }

        /// <summary>
        /// 绑定用户角色的接口
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BindUserInfo(List<string> userIds, string roleId)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(roleId))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            result.IsSuccess = _roleInfo.BindUserInfo(userIds, roleId);
            result.Msg = "绑定角色成功";
            result.Code = 200;
            return Json(result);

        }

        /// <summary>
        /// 绑定用户菜单接口
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BindMenuInfo(List<string> menuIds, string roleId)
        {
            ReturnResult result = new ReturnResult();

            if (string.IsNullOrWhiteSpace(roleId))
            {
                result.Msg = "id不能为空";
                return Json(result);
            }

            result.IsSuccess = _roleInfo.BindMenuInfo(menuIds, roleId);

            result.Msg = "绑定菜单成功";
            result.Code = 200;
            return Json(result);

        }
    }
    
}