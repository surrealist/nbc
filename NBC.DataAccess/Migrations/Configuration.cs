namespace NBC.DataAccess.Migrations
{
    using NBC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    internal sealed class Configuration : DbMigrationsConfiguration<NBC.DataAccess.Contexts.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NBC.DataAccess.Contexts.AppDbContext";
        }
       

        //Context.UserRole.AddOrUpdate(m => m.,
        //        new  { Name = "Machine 001" },
        //        new Machine { Name = "Machine 002" });
        protected override void Seed(NBC.DataAccess.Contexts.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //   
            context.Roles.AddOrUpdate(
                r => r.RoleName,
            new Role {RoleName = "Administrators",isEnable =true,CreatedDate = DateTime.Now,ModifiedDate=DateTime.Now },
            new Role { RoleName = "Registered Users", isEnable = true, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            new Role { RoleName = "Subscribers", isEnable = true, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
            );         
        }
    }
}
