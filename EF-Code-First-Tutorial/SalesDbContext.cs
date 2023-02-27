using EF_Code_First_Tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First_Tutorial
{
    public class SalesDbContext : DbContext
    {  
        //tables Accessible
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public SalesDbContext() { }
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var connStr = "Server=localhost\\sqlexpress;" +
                        "database = SalesDb2;" +
                        "Trusted_connection = true;" +
                        "Trustservercertificate=true;";
            optionsBuilder.UseSqlServer(connStr);
        }
    }

}
