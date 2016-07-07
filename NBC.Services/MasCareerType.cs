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
    public class MasCareerTypeService : ServiceBase<MasCareerType>
    {

        public MasCareerTypeService(IRepository<MasCareerType> baseRepo) : base(baseRepo) {
            //
        }
        public override MasCareerType Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override MasCareerType Add(MasCareerType item)
        {
            MasCareerType action = Query(x => x.Name == item.Name).SingleOrDefault();

            if (action == null)
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
                throw new Exception("This MasCareerType is already exist.");
            }
        }
        public override MasCareerType Remove(MasCareerType item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
