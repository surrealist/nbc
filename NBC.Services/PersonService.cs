using NBC.DataAccess.Bases;
using NBC.DataAccess.Contexts;
using NBC.Models;
using NBC.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Services
{
    public class PersonService : ServiceBase<Person>
    {
        public PersonService(IRepository<Person> baseRepo) : base(baseRepo)
        {
            //
        }

        public override Person Find(params object[] keys)
        {
            var key1 = (int)keys[0];
            return Query(x => x.Id == key1).SingleOrDefault();
        }
        public override Person Add(Person person)
        {
            Person tmp = Query(x => x.CitizenId == person.CitizenId).SingleOrDefault();

            if(tmp == null)
            {
                //AppDbContext Dbc = new AppDbContext();
                person.CreatedDate = DateTime.Now;
                person.ModifiedDate = DateTime.Now;


                base.Add(person);
                base.SaveChanges();
                return person;
            }
            else
            {
                throw new Exception("This person is already exist.");
            }
        }
        public override Person Remove(Person item)
        {
            return base.Remove(item);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    


    }
}
