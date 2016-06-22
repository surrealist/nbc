using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Linq;

namespace NBC.Services
{
    public class ActivityTypeService : ServiceBase<ActivityType>
    {

        public ActivityTypeService(IRepository<ActivityType> baseRepo) : base(baseRepo)
        {

        }
        public override ActivityType Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override ActivityType Add(ActivityType item)
        {
           ActivityType temp = Query(x => x.Name == item.Name).SingleOrDefault();

            if (temp == null)
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                base.Add(item);
                base.SaveChanges();
                return item;
            }
            else
            {
                throw new Exception("Already exist.");
            }
        }
        public override ActivityType Remove(ActivityType item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
