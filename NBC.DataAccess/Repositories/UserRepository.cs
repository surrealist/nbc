using System.Data.Entity;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {

        public UserRepository(DbContext context) : base(context)
        {
            //
        }

    }
    
}
