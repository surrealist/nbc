using System;
using System.Linq;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System.Collections.Generic;

namespace NBC.Services {
    public class YearService : ServiceBase<Year>
    {
        NBC.DataAccess.Contexts.AppDbContext db = new DataAccess.Contexts.AppDbContext();
        public YearService(IRepository<Year> baseRepo) : base(baseRepo)
        {
            //
        }

        public override Year Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public Year GetYearById(int Id)
        {            
            return Query(x => x.Id == Id).SingleOrDefault();
        }
        
        public object GetYear()
        {
            var years = (from u in db.Years select new { u.Id, u.Name }).ToList();
            return years;
        }

        public override Year Add(Year item)
        {
            Year year = Find(item.Id);

            if(year == null)
            {                
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                year = base.Add(item);
                base.SaveChanges();  
                return year;
            }
            else
            {
                throw new Exception("Already exist.");
            }
        }
        public override Year Remove(Year item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
           
            return base.SaveChanges();
        }

    }
}
