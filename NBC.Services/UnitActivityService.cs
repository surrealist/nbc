using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Services
{
    public class UnitActivityService : ServiceBase<UnitActivity>
    {

        public UnitActivityService(IRepository<UnitActivity> baseRepo) : base(baseRepo)
        {
            //
        }
        public override UnitActivity Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override UnitActivity Add(UnitActivity item)
        {
            //not implement
            UnitActivity temp = null;

            if (temp == null)
            {
                //AppDbContext Dbc = new AppDbContext();

                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                base.Add(item);
                base.SaveChanges();
                return item;
            }
            else
            {
                throw new Exception("This UnitActivity is already exist.");
            }
        }
        public override UnitActivity Remove(UnitActivity item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}


