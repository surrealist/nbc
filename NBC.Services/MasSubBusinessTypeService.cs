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
    public class MasSubBusinessTypeService : ServiceBase<MasSubBusinessType>
    {

        public MasSubBusinessTypeService(IRepository<MasSubBusinessType> baseRepo) : base(baseRepo) {
            //
        }
        public override MasSubBusinessType Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override MasSubBusinessType Add(MasSubBusinessType item)
        {
            MasSubBusinessType action = Query(x => x.Name == item.Name).SingleOrDefault();

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
                throw new Exception("This MasSubBusinessType is already exist.");
            }
        }
        public List<MasSubBusinessType> GetAllBusinessTypes()
        {
            return Query(x => x.Id != 0).ToList();
        }
        public override MasSubBusinessType Remove(MasSubBusinessType item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
