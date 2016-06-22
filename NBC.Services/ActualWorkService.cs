using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Linq;


namespace NBC.Services
{
    public class ActualWorkService : ServiceBase<ActualWork>
    {

        public ActualWorkService(IRepository<ActualWork> baseRepo) : base(baseRepo) {
            //
        }
        public override ActualWork Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override ActualWork Add(ActualWork item)
        {
            // Not implement
            ActualWork temp = null;

            if (temp == null)
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                base.Add(item);
                base.SaveChanges();
                return base.Add(item);
            }
            else
            {
                throw new Exception("This ActualWork is already exist.");
            }
        }
        public override ActualWork Remove(ActualWork item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
