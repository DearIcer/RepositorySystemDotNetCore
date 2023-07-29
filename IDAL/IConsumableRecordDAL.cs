using Microsoft.EntityFrameworkCore;
using Models;

namespace IDAL
{
    public interface IConsumableRecordDAL : IBaseDAL<ConsumableRecord>
    {
        DbSet<ConsumableRecord> GetConsumableRecord();
    }
}
