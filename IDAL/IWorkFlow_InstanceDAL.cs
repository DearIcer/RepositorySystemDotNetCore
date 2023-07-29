using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IWorkFlow_InstanceDAL : IBaseDAL<WorkFlow_Instance>
    {
        DbSet<WorkFlow_Instance> GetWorkFlow_Instance();
    }
}
