using System.Data.Entity; 
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories {
  public class YearRepository : RepositoryBase<Year> {

    public YearRepository(DbContext context): base(context) {
      //
    }

  }
}
