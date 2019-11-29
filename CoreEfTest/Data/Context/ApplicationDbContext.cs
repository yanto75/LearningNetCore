using CoreEfTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEfTest.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        //Called whenever EF utilized the DbContext.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Move connection string to config file
            optionsBuilder.UseSqlServer(@"Data Source=YP-SB2\SQLEXPRESS;Initial Catalog=CoreEfTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Order> Orders { get; set; }

        //We only need to create a separate DbSet<OrderItem> if we're going to work with it 
        //independently from Order, but since that's not going to happen, we can skip it.
        //public DbSet<OrderItem> OrderItems { get; set; }
    }
}
