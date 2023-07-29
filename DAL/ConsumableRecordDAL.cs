using IDAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ConsumableRecordDAL : BaseDAL<ConsumableRecord>, IConsumableRecordDAL
    {
        private RepositorySystemContext _dbContext;
        public ConsumableRecordDAL(RepositorySystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<ConsumableRecord> GetConsumableRecord()
        {
            return _dbContext.ConsumableRecord;
        }
    }
}
