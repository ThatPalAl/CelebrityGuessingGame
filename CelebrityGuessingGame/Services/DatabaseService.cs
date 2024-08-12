using CelebrityGuessingGame.Models;
using Microsoft.EntityFrameworkCore;

namespace CelebrityGuessingGame.Services
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions<DatabaseService> options)
            : base(options)
        {
        }

        public DbSet<Celebrity> Celebrities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Celebrity>().HasKey(c => c.Id);

            modelBuilder.Entity<Celebrity>().HasData(
                new Celebrity { Id = 1, Name = "Tom Cruise", Gender = "Male", Age = 58, Nationality = "American", Occupation = new List<string> { "Actor" }, NetWorth = 570000000, Height = 1.7, Birthday = "1962-07-03", IsAlive = true },
                new Celebrity { Id = 2, Name = "Beyoncé", Gender = "Female", Age = 39, Nationality = "American", Occupation = new List<string> { "Singer", "Actress" }, NetWorth = 400000000, Height = 1.69, Birthday = "1981-09-04", IsAlive = true }
            );
        }
    }
}