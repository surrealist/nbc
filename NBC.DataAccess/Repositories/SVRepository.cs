using System.Data.Entity;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories
{
    public class SVRepository : RepositoryBase<SV>
    {

        public SVRepository(DbContext context): base(context) {
            //
        }
    }
}
