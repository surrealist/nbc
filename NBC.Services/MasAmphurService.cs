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
    public class MasAmphurService : ServiceBase<MasAmphur>
    {

        public MasAmphurService(IRepository<MasAmphur> baseRepo) : base(baseRepo) {
            //
        }
        public override MasAmphur Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public List<MasAmphur> GetAmphurByProvinceId (int Id)
        {            
            return Query(x => x.MasProvince_Id == Id).ToList();
        }
        public List<MasAmphur> GetAllAmphurd()
        {
            return Query(x => x.Id != 0).ToList();
        }
        public override MasAmphur Add(MasAmphur item)
        {
            MasAmphur action = Query(x => x.Name == item.Name).SingleOrDefault();

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
                throw new Exception("This MasAmphur is already exist.");
            }
        }
        public override MasAmphur Remove(MasAmphur item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}