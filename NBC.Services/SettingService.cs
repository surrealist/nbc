using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;

namespace NBC.Services {
  public class SettingService : ServiceBase<Setting> {

    public SettingService(IRepository<Setting> baseRepo) : base(baseRepo) {
      //
    }

    public override Setting Find(params object[] keys) {
      var key1 = (string)keys[0];
      return Query(x => x.Profile == key1).SingleOrDefault();
    }

    public Setting Current {
      get {       

        var s = Find("DEFAULT");
        if (s == null) {
          s = new Setting();
          s.Profile = "DEFAULT";
          s.CurrentYearId = null;

          Add(s);
          SaveChanges();
        }

        return s;
      }
    }

    public void ChangeCurrentYear(int year) {
      Current.CurrentYearId = year;
    }
  }
}
