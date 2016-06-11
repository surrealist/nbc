using NBC.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess.Bases;
using NBC.Models;


namespace NBC.Services {
    public class UnitService : ServiceBase<Unit>
    {

        public UnitService(IRepository<Unit> baseRepo) : base(baseRepo)
        {
            //
        }

        public override Unit Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public override Unit Add(Unit item)
        {
            if ((All().Any(x => x.Name == item.Name))
            || (All().Any(x => x.Alias == item.Alias)))
                {
                throw new Exception($"Unit {item.Name} or {item.Alias} is already existed.");
            }
            return base.Add(item);
        }
    }
}
