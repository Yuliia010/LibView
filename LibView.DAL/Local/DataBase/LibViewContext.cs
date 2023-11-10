using LibView.DAL.Local.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace LibView.DAL.Local.DataBase
{
    public class LibViewContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=BookViewer; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public DbSet<User> Users { get; set; }
        public DbSet<Text> Texts { get; set; }

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

            var text = new Text()
            {
                Id = 1,
                Name = "Testing",
                Description = "Test on adding a new object",
                EngText = "Some text",
                TranslText = "Якийсь текст"
            };

            modelBuilder.Entity<Text>().HasData(text);

            base.OnModelCreating(modelBuilder);

        }
    }
}