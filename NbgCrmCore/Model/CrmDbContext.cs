using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=nbgCrm2021;Integrated Security=True");


        //   }

    }
}
