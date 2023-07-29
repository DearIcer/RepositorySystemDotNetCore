using Microsoft.EntityFrameworkCore;
using Models;

namespace IDAL
{
    public interface IMenuInfoDAL : IBaseDeleteDAL<MenuInfo>
    {
        DbSet<MenuInfo> GetMenuInfos();
    }
}
