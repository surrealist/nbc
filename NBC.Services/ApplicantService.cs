using NBC.DataAccess.Bases;
using NBC.DataAccess.Contexts;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Services
{
    public class ApplicantService : ServiceBase<Applicant>
    {

        public ApplicantService(IRepository<Applicant> baseRepo): base(baseRepo) {
            //
        }
        public override Applicant Find(params object[] keys)
        {
            var key = (int)keys[0];
            return Query(x => x.Id == key).SingleOrDefault();
        }

        public override Applicant Add(Applicant item)
        {

            AppDbContext Dbc = new AppDbContext();
            UnitActivity unit = (from t in Dbc.UnitActivities where t.Name == item.UnitActivity.Name select t).SingleOrDefault();
            Person person = (from t in Dbc.Persons where t.CitizenId == item.Person.CitizenId select t).SingleOrDefault();
            //Not sure about this
            if ((item.Person.CitizenId != null) && (item.UnitActivity.Name != null) )
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                base.Add(item);
                base.SaveChanges();
                return item;
            }
            else
            {
                throw new Exception("this Unit is already exist");
            }
        }

        public override Applicant Remove(Applicant item)
        {
            return base.Remove(item);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
