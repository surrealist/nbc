using System.Data.Entity;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories
{
    public class UserInRoleRepository : RepositoryBase<UserInRole>
    {

        public UserInRoleRepository(DbContext context) : base(context)
        {
            //
        }

    }

}


