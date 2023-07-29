using Models;
using Models.DTO;

namespace IBLL
{
    public interface IWorkFlow_ModelBLL
    {
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<GetWorkFlow_ModelDTO> GetWorkFlow_Model(int page, int limit, string id, out int count);

        /// <summary>
        /// 添加模板数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool CreateWorkFlow_Model(WorkFlow_Model entity, out string msg);

        /// <summary>
        /// 获取下拉列表数据
        /// </summary>
        /// <returns></returns>
        object GetSelectOptions();
    }
}
