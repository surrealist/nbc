using System.Data.Entity;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories
{
    public class RoleRepository : RepositoryBase<Role>
    {

        public RoleRepository(DbContext context) : base(context)
        {
            //
        }

    }

}

