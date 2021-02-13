using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context:Db tablolari ile proje klasslarini baglamak
   public class NorthwindContext:DbContext
    {

        // Projeyle ver tabanini ilsikliendirecegimiz kisim
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
            // optionsBuilder.UseSqlServer(@"Server=175.45.2.12"); Normalde Sql serverin bulundugu yerin Ip adresi 
        }

        //veri tabanindaki hangi nesneye hangiye karsilik gelecek belirtmeliyiz
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
