using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ConsumableInfoDAL : BaseDeleteDAL<ConsumableInfo>, IConsumableInfoDAL
    {
        private RepositorySystemContext _dbContext;
        public ConsumableInfoDAL(RepositorySystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<ConsumableInfo> GetConsumableInfo()
        {
            return _dbContext.ConsumableInfo;
        }
    }
}
