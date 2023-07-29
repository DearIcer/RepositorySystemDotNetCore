﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IWorkFlow_InstanceStepDAL : IBaseDAL<WorkFlow_InstanceStep>
    {
        DbSet<WorkFlow_InstanceStep> GetWorkFlow_InstanceStep();
    }
}
