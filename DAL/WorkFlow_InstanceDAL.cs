using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class WorkFlow_InstanceDAL : BaseDAL<WorkFlow_Instance>, IWorkFlow_InstanceDAL
    {
        private RepositorySystemContext _dbContext;
        public WorkFlow_InstanceDAL(RepositorySystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<WorkFlow_Instance> GetWorkFlow_Instance()
        {
            return _dbContext.WorkFlow_Instance;
        }
    }
}
