using System;
using System.Linq;
using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;


namespace NBC.Services {
    public class YearService : ServiceBase<Year>
    {

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
