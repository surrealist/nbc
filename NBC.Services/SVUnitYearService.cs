using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using NBC.DataAccess.Contexts;

namespace NBC.Services
{
    public class SVUnitYearService : ServiceBase<SVUnitYear>
    {
        AppDbContext db = new AppDbContext();
        public SVUnitYearService(IRepository<SVUnitYear> baseRepo) : base(baseRepo)
        {
            //
        }
        public override SVUnitYear Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public object getUnitBySV_IDAndYear_ID(int SV_ID, int Year_ID)
        {
            //var sv = (from s in db.SV where s.Id == SV_ID select s);
            var q = (from u in db.SVUnitYear where u.SV.Id == SV_ID && u.Year_Id == Year_ID select u.Unit).ToList();
            
            return q;
        }
        public override SVUnitYear Add(SVUnitYear item)
        {

            // Not implement
            SVUnitYear temp = null;

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
                throw new Exception("This SVUnitYear is already exist.");
            }
        }
        public override SVUnitYear Remove(SVUnitYear item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}


