using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.DataAccess.Repositories {
  public class SettingRepository : RepositoryBase<Setting> {

    public SettingRepository(DbContext context) : base(context) {
      //
    }

  }
}
