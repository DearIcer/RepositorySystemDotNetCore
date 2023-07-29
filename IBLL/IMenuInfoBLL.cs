﻿using Models;
using Models.DTO;

namespace IBLL
{
    public interface IMenuInfoBLL
    {
        /// <summary>
        /// 查询菜单列表的函数
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">每页几条数据</param>
        /// <param name="account">角色ID</param>
        /// <param name="userName">角色名</param>
        /// <param name="count">返回的数据总量</param>
        /// <returns></returns>
        List<GetMenuInfoDTO> GetAllMenuInfos(int page, int limit, string id, string MenuName, out int count);

        /// <summary>
        /// 添加菜单信息
        /// </summary>
        /// <returns></returns>
        bool CreateMenuInfo(MenuInfo entity, out string msg);

        /// <summary>
        /// 菜单软删除
        /// </summary>
        /// <param name="id">要删除的菜单ID</param>
        /// <returns></returns>
        bool DeleteMenuInfo(string id);

        /// <summary>
        /// 菜单软删除部门
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteMenuInfos(List<string> ids);

        /// <summary>
        /// 返回菜单列表 非分页
        /// </summary>
        /// <returns></returns>
        List<GetMenuInfoDTO> GetAllMenuInfos();

        /// <summary>
        /// 根据id获取菜单表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MenuInfo GetMenuInfoById(string id);

        /// <summary>
        /// 返回对应用户权限的菜单项
        /// </summary>
        /// <returns></returns>
        List<HomeMenuInfoDTO> GetAllHomeMenuInfos(string userId);

        /// <summary>
        /// 获取下拉列表数据
        /// </summary>
        /// <returns></returns>
        object GetSelectOptions();


        bool UpdateMenuInfo(MenuInfo entity, out string msg);
    }
}
