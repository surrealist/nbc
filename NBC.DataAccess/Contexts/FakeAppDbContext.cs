using System.Data.Entity;
using NBC.Models;
using System;
using System.Collections.Generic;

namespace NBC.DataAccess.Contexts
{
    public class FakeAppDbContext : DbContext
    {
        private ICollection<Setting> Settings;
        private ICollection<Year> Years;
        private ICollection<Unit> Units;
        private ICollection<ActionType> ActionTypes;
        private ICollection<ActualWork> ActualWorks;
        private ICollection<Applicant> Applicants;
        private ICollection<Company> Companies;
        private ICollection<Consultant> Consultants;
        private ICollection<Person> Persons;
        private ICollection<TimeTable> TimeTables;

    }
}
