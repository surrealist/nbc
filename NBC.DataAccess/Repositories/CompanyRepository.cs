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
    public class CompanyRepository : RepositoryBase<Company>
    {

        public CompanyRepository(DbContext context): base(context) {
            //
        }
    }
}
