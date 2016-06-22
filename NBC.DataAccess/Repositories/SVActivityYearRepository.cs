using NBC.DataAccess.Bases;
using NBC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.DataAccess.Repositories
{
    public class SVActivityYearRepository : RepositoryBase<SVActivityYear>
    {

        public SVActivityYearRepository(DbContext context) : base(context)
        {
            //
        }
    }
}
