using System;
using System.Linq;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;

namespace NBC.Services
{
    public class RoleService : ServiceBase<Role>
    {
        public RoleService(IRepository<Role> baseRepo) : base(baseRepo)
        {
            //
        }
        public override Role Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public Role GetUserRoleById(int Id)
        {
            return Query(x => x.Id == Id).SingleOrDefault();
        }
        public Role GetRoleByName(string Name)
        {
            return Query(x => x.RoleName == Name).SingleOrDefault();
        }     

        public override Role Add(Role item)
        {
            Role Roler = Find(item.Id);

            if (Roler == null)
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                Roler = base.Add(item);
                base.SaveChanges();
                return Roler;
            }
            else
            {
                throw new Exception("Already exist.");
            }
        }
        public override Role Remove(Role item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

    }
}
