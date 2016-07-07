using System;
using System.Linq;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;

namespace NBC.Services
{
    public class UserService : ServiceBase <User>
    {
        public UserService(IRepository<User> baseRepo) : base(baseRepo)
        {
            //
        }
        public override User Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public User GetUserById(int Id)
        {
            return Query(x => x.Id == Id).SingleOrDefault();
        }
        public User GetUserByCardId(string CardId)
        {
            return Query(x => x.CardId == CardId).SingleOrDefault();
        }
        public User GetUserByUserName(string UserName)
        {
            return Query(x => x.UserName == UserName).SingleOrDefault();
        }
        public override User Add(User item)
        {
            User user = Find(item.Id);
            //User user = GetUserByCardId(item.CardId);
            if (user == null)
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                user = base.Add(item);
                base.SaveChanges();
                return user;
            }
            else
            {
                throw new Exception("Already exist.");
            }
        }
        public override User Remove(User item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

    }
}
