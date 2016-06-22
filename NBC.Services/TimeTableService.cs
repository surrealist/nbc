using NBC.DataAccess.Bases;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Services
{
    public class TimeTableService : ServiceBase<TimeTable>
    {

        public TimeTableService(IRepository<TimeTable> baseRepo) : base(baseRepo)
        {
            //
        }
        public override TimeTable Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }

        public override TimeTable Add(TimeTable item)
        {
            TimeTable temp = Query(x => x.SeqId == item.SeqId).SingleOrDefault();

            if (temp == null)
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
                throw new Exception("This TimeTable is already exist.");
            }
        }
        public override TimeTable Remove(TimeTable item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}


