using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;


namespace TestingApp.DataModels
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<SellData> SellData { get; set; }
        // public DbSet<Customer> Customers { get; set; }
        // public DbSet<Vehicle> Vehicle { get; set; }
    }
}