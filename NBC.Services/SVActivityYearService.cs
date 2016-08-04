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
    public class SVActivityYearService : ServiceBase<SVActivityYear>
    {

        public SVActivityYearService(IRepository<SVActivityYear> baseRepo) : base(baseRepo)
        {
            //
        }
        public override SVActivityYear Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public List<SVActivityYear> getSVActivityYearBySVid(int SV_ID,int Year) {
            return Query(x => x.SV.Id == SV_ID && x.Year.Id == Year).ToList();
        }
        
        public List<SVActivityYear> getSVActivityYearByYear(int Year_ID)
        {
            return Query(x => x.Year.Id == Year_ID).ToList();
        }

        public override SVActivityYear Add(SVActivityYear item)
        {

            //Not implement
            SVActivityYear temp = null;

            if (temp == null)
            {
                //AppDbContext Dbc = new AppDbContext();

                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                base.Add(item);
               // base.SaveChanges();
                return item;
            }
            else
            {
                throw new Exception("This SVActivityYear is already exist.");
            }
        }
        public override SVActivityYear Remove(SVActivityYear item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}


