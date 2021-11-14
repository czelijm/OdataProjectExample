using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdataProjectExample.DataAccess.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Customer>().HasMany<Order>().WithOne(c=>c.Customer);
            //modelBuilder.Entity<Order>().HasOne<Customer>();

            modelBuilder.Entity<Customer>().Property(c => c.Name).HasMaxLength(255);
        }

    }
}
