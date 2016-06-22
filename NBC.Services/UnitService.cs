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
    public class UnitService : ServiceBase<Unit>
    {

        public UnitService(IRepository<Unit> baseRepo) : base(baseRepo)
        {

        }      

        public override Unit Find(params object[] keys)
        {
            var key = (int)keys[0];
            return Query(x => x.Id == key).SingleOrDefault();
        }

        public override Unit Add(Unit item)
        {
            Unit tmp = Query(x => (x.Name == item.Name)&&(x.Alias ==  item.Alias)).SingleOrDefault();
            if (tmp == null)
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
                throw new Exception("this Unit is already exist");
            }
        }

        public override Unit Remove(Unit item)
        {
            return base.Remove(item);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
