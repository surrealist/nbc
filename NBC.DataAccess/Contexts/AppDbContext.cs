using System.Data.Entity;
using NBC.Models;
using System;

namespace NBC.DataAccess.Contexts {
  public class AppDbContext : DbContext {

        public virtual DbSet<ActionType> ActionTypes { get; set; }

        public virtual DbSet<ActivityType> ActivityTypes { get; set; }

        public virtual DbSet<ActualWork> ActualWorks { get; set; }

        public virtual DbSet<Applicant> Applicants { get; set; }

        public virtual DbSet<ApplicantConsult> ApplicantConsults { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Consultant> Consultants { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Setting> Settings { get; set; }

        public virtual DbSet<SV> SV { get; set; }

        public virtual DbSet<SVActivityYear> SVActivityYears { get; set; }

        public virtual DbSet<SVUnitYear> SVUnitYear { get; set; }

        public virtual DbSet<TimeTable> TimeTables { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<UnitActivity> UnitActivities { get; set; }

        public virtual DbSet<UnitConsult> UnitConsults { get; set; }

        public virtual DbSet<Year> Years { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
    }
  }
}