using System.Data.Entity;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories
{
    public class UnitRepository : RepositoryBase<Unit>
    {
        public UnitRepository(DbContext context): base(context) {
            //
        }
    }
}
