﻿using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Services
{
    public class MasTambolService : ServiceBase<MasTambol>
    {

        public MasTambolService(IRepository<MasTambol> baseRepo) : base(baseRepo) {
            //
        }
        public override MasTambol Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override MasTambol Add(MasTambol item)
        {
            MasTambol action = Query(x => x.Name == item.Name).SingleOrDefault();

            if (action == null)
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
                throw new Exception("This MasTambol is already exist.");
            }
        }
        public override MasTambol Remove(MasTambol item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
