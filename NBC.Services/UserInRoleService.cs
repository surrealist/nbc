﻿using System;
using System.Linq;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System.Collections.Generic;


namespace NBC.Services
{
    public class UserInRoleService : ServiceBase<UserInRole>
    {
        
        public UserInRoleService(IRepository<UserInRole> baseRepo) : base(baseRepo)
        {
            //
        }
        public override UserInRole Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public UserInRole GetUserInRoleByUserIdAndUserRoleId(int? User_Id,int? UserRole_Id)
        {
            return Query(x => x.Role.Id  == UserRole_Id && x.User.Id == User_Id).SingleOrDefault();
        }
        public List<UserInRole> GetUserInRoleByUserId(int? Id)
        {
            var dataContexts = new DataAccess.Contexts.AppDbContext();
           
            var q = (from u in dataContexts.UserInRoles where u.User.Id == Id select u);
            if (q.Count() != 0)
            {
                var resoult = q.ToList();
                              
                return (resoult);
            }
            else {
                return (null);
            }
           
        }
        public override UserInRole Add(UserInRole item)
        {
            //UserInRole userInRoler = GetUserInRoleByUserIdAndUserRoleId(item.User.Id,item.Role.Id);

            // if (userInRoler == null)
            // {
            // item.CreatedDate = DateTime.Now;
            //  item.ModifiedDate = DateTime.Now;
            // userInRoler = base.Add(item);
            try
            {
               
                base.Add(item);
                base.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                return null;
            }
           
          //  }
           // else
           // {
              //  return null;
           // }
        }
        public override UserInRole Remove(UserInRole item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

    }
}