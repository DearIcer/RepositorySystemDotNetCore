using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class WorkFlow_InstanceStepDAL : BaseDAL<WorkFlow_InstanceStep>, IWorkFlow_InstanceStepDAL
    {
        private RepositorySystemContext _dbContext;

        public WorkFlow_InstanceStepDAL(RepositorySystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<WorkFlow_InstanceStep> GetWorkFlow_InstanceStep()
        {
            return _dbContext.WorkFlow_InstanceStep;
        }
    }
}
