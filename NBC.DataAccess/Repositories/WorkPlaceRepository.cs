﻿using System.Data.Entity;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories
{
    public class WorkPlaceRepository : RepositoryBase<WorkPlace>
    {

        public WorkPlaceRepository(DbContext context): base(context) {
            //
        }
    }
}
