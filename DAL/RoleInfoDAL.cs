using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class RoleInfoDAL : BaseDeleteDAL<RoleInfo>, IRoleInfoDAL
    {
        private RepositorySystemContext _dbContext;
        public RoleInfoDAL(RepositorySystemContext dbContext) : base(dbContext)
        {         
            this._dbContext = dbContext;
        }

        public DbSet<RoleInfo> GetRoleInfos()
        {
            return _dbContext.RoleInfo;
        }
    }
}
