using IDAL;
using Models;

namespace DAL
{
    public class R_RoleInfo_MenuInfoDAL : BaseDAL<R_RoleInfo_MenuInfo>, IR_RoleInfo_MenuInfoDAL
    {
        private RepositorySystemContext _dbContext;
        public R_RoleInfo_MenuInfoDAL(RepositorySystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
