using System.Data.Entity;
using NBC.Models;
using System;

namespace NBC.DataAccess.Contexts {
  public class AppDbContext : DbContext {

    public virtual DbSet<Year> Years { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
    }
  }
}