using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class DepartmentInfoDAL : BaseDeleteDAL<DepartmentInfo>,IDepartmentInfoDAL
    {
        //数据上下文
        private RepositorySystemContext _dbContext;
        public DepartmentInfoDAL(RepositorySystemContext dbContext) : base(dbContext)
        {            
            this._dbContext = dbContext;
        }
        /// <summary>
        /// 获取用户表所有的数据
        /// </summary>
        /// <returns></returns>
        public DbSet<DepartmentInfo> GetDepartmentInfos()
        {
            return _dbContext.DepartmentInfo;
        }
    }
}
