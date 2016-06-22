using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Linq;

namespace NBC.Services
{
    public class ConsultantService : ServiceBase<Consultant>
    {

        public ConsultantService(IRepository<Consultant> baseRepo) : base(baseRepo)
        {
            //
        }
        public override Consultant Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override Consultant Add(Consultant item)
        {
            Consultant temp = Query(x => x.Citizenid == item.Citizenid).SingleOrDefault();

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
                throw new Exception("This Consultant is already exist.");
            }
        }
        public override Consultant Remove(Consultant item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
