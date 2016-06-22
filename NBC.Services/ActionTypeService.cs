using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Linq;


namespace NBC.Services
{
    public class ActionTypeService : ServiceBase<ActionType>
    {

        public ActionTypeService(IRepository<ActionType> baseRepo) : base(baseRepo) { 
            //
        }
        public override ActionType Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override ActionType Add(ActionType item)
        {
            ActionType action = Query(x => x.Name == item.Name).SingleOrDefault();

            if(action == null)
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
                throw new Exception("This ActionType is already exist.");
            }
        }
        public override ActionType Remove(ActionType item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
