using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using NBC.DataAccess.Contexts;

namespace NBC.Services {
 public class SVService : ServiceBase<SV>
    {
        public SVService(IRepository<SV> baseRepo) : base(baseRepo)
        {
            
        }

        public override SV Find(params object[] keys)
        {
            var key = (int)keys[0];
            return Query(x => x.Id == key).SingleOrDefault();
        }

        public override SV Add(SV item)
        {

            SV temp = Query(x => (x.Name == item.Name) && (x.Alias == item.Alias)).SingleOrDefault();

            if(temp == null)
            {
               // AppDbContext Dbc = new AppDbContext();

               
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                base.Add(item);
                base.SaveChanges();
                return item;
            }
            else
            {
                throw new Exception("This SV is already exist.");
            }



        }
        public override SV Remove(SV item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
