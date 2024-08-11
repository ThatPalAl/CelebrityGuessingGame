using Microsoft.EntityFrameworkCore;
using CelebrityGuessingGame.Models;

namespace CelebrityGuessingGame.Services
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions<DatabaseService> options)
            : base(options)
        {
        }

        public DbSet<Celebrity> Celebrities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Celebrity>().HasData(
                new Celebrity { Id = 1, Name = "Tom Cruise", Gender = "Male", Profession = "Actor", Nationality = "American" },
                new Celebrity { Id = 2, Name = "Beyoncé", Gender = "Female", Profession = "Singer", Nationality = "American" }
            );
        }
    }
}