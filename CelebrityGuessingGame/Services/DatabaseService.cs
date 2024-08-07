using Microsoft.EntityFrameworkCore;

public class DatabaseService : DbContext
{
    public DbSet<User> Users { get; set; }

    public DatabaseService(DbContextOptions<DatabaseService> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
    }
}