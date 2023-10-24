using LibView.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace LibView.DAL
{
    public class LitViewContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=BookViewer; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new User()
            {
                Id = 1,
                Name = "Yuliia",
                login = "admin",
                password = "admin",
                IsAdmin = true
            };

            modelBuilder.Entity<User>().HasData(user);

            base.OnModelCreating(modelBuilder);

        }
    }
}