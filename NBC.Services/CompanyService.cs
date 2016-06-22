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
    public class CompanyService : ServiceBase<Company>
    {

        public CompanyService(IRepository<Company> baseRepo) : base(baseRepo)
        {
            //
        }
        public override Company Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override Company Add(Company item)
        {
            Company temp = Query(x => x.Name == item.Name).SingleOrDefault();

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
                throw new Exception("This Company is already exist.");
            }
        }
        public override Company Remove(Company item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
