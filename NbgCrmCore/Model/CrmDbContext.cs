using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Model
{
    public class CrmDbContext:DbContext
    {

        public DbSet<User> Users { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Basket> Baskets { set; get; }
        public DbSet<BasketItem> BasketItems { set; get; }

        public CrmDbContext()
        {

        }

        public CrmDbContext(DbContextOptions<CrmDbContext> options) 
            :base(options)
        {

        }
       
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {

            IConfigurationBuilder builder = new ConfigurationBuilder() 
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            IConfiguration _iConfiguration = builder.Build();
            string _connectionString = _iConfiguration.GetConnectionString("NbgSqlConnection");


            optionsBuilder.UseSqlServer(
                _connectionString, 
                providerOptions => providerOptions.CommandTimeout(60))
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);


        }
        /* */
    }
}
