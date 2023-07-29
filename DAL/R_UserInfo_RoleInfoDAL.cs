using IDAL;
using Models;

namespace DAL
{
    public class R_UserInfo_RoleInfoDAL : BaseDAL<R_UserInfo_RoleInfo>, IR_UserInfo_RoleInfoDAL
    {
        private RepositorySystemContext _dbContext;
        public R_UserInfo_RoleInfoDAL(RepositorySystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
