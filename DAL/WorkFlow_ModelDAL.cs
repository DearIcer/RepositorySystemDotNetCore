using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class WorkFlow_ModelDAL : BaseDeleteDAL<WorkFlow_Model>, IWorkFlow_ModelDAL
    {
        private RepositorySystemContext _dbContext;
        public WorkFlow_ModelDAL(RepositorySystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<WorkFlow_Model> GetWorkFlow_Model()
        {
            return _dbContext.WorkFlow_Model;
        }
    }
}
