using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestProjectGraphQL.domain.models;

namespace TestProjectGraphQL.data.models
{
    public class dbContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Order> Orders{ get; set; }

        public dbContext(DbContextOptions<dbContext> dboptions) : base(dboptions)
        {
            Database.EnsureCreated();
        }

        public dbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Order> orders = new List<Order>();
            List<Train> trains = new List<Train>();
            orders.Add(new Order() { ID = Guid.NewGuid()});
            trains.Add(new Train() { ID = Guid.NewGuid()});
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<Train>().HasData(trains);
        }
    }
}
