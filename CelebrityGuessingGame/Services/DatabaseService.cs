using CelebrityGuessingGame.Models;
using Microsoft.EntityFrameworkCore;

namespace CelebrityGuessingGame.Services;

public class DatabaseService : DbContext
{
    public required DbSet<User> Users { get; set; }

    public DatabaseService(DbContextOptions<DatabaseService> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
    }
}