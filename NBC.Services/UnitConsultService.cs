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
    public class UnitConsultService : ServiceBase<UnitConsult>
    {

        public UnitConsultService(IRepository<UnitConsult> baseRepo) : base(baseRepo)
        {
            //
        }
        public override UnitConsult Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override UnitConsult Add(UnitConsult item)
        {
            UnitConsult temp = null; 

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
                throw new Exception("This UnitConsult is already exist.");
            }
        }
        public override UnitConsult Remove(UnitConsult item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}


