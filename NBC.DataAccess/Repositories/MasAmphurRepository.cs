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
    public class MasAmphurRepository : RepositoryBase<MasAmphur>
    {

        public MasAmphurRepository(DbContext context) : base(context)
        {
            //
        }
    }
}
