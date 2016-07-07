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
            base.Add(item);
            base.SaveChanges();
            return item;
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
