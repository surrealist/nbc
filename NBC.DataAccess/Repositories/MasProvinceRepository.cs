using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess.Bases;
using NBC.Models;
using System.Data.Entity;

namespace NBC.DataAccess.Repositories
{
    public class MasProvinceRepository : RepositoryBase<MasProvince>
    {

        public MasProvinceRepository(DbContext context) : base(context)
        {
            //
        }
    }
}
