using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;

namespace NBC.Services {
  public class YearService : ServiceBase<Year> {

    public YearService(IRepository<Year> baseRepo) : base(baseRepo) {
      //
    }

    public override Year Find(params object[] keys) {
      var key1 = (int)keys[0];
      return Query(x => x.Id == key1).SingleOrDefault();
    }

    public override Year Add(Year item) {
      if (All().Any(y => y.Id == item.Id)) {
        throw new Exception($"Year {item.Id} is already existed.");
      }


      return base.Add(item);
    }
  }
}
