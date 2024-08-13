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

        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);

            modelBuilder.Entity<Option>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Answer>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Answer)
                .WithOne(a => a.Question)
                .HasForeignKey<Answer>(a => a.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.SelectedOption)
                .WithMany()
                .HasForeignKey(a => a.SelectedOptionId);

            // Seed data
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuestionText = "Is the celebrity male?" },
                new Question { Id = 2, QuestionText = "Is the person tall, medium, or short?" },
                new Question { Id = 3, QuestionText = "Is the person old, young, or middle-aged?" },
                new Question { Id = 4, QuestionText = "Is the person alive?" },
                new Question { Id = 5, QuestionText = "Is the person an actor?" },
                new Question { Id = 6, QuestionText = "Is the person a singer?" },
                new Question { Id = 7, QuestionText = "Is the person American?" },
                new Question { Id = 8, QuestionText = "Is the person involved in sports?" },
                new Question { Id = 9, QuestionText = "Is the person a politician?" },
                new Question { Id = 10, QuestionText = "Has the person won any awards?" },
                new Question { Id = 11, QuestionText = "Is the person known for their philanthropy?" },
                new Question { Id = 12, QuestionText = "Is the person involved in business?" },
                new Question { Id = 13, QuestionText = "Is the person associated with fashion?" },
                new Question { Id = 14, QuestionText = "Is the person known internationally?" },
                new Question { Id = 15, QuestionText = "Is the person a public speaker?" }
            );

            modelBuilder.Entity<Option>().HasData(
                new Option { Id = 1, OptionText = "Yes", QuestionId = 1 },
                new Option { Id = 2, OptionText = "No", QuestionId = 1 },
                new Option { Id = 3, OptionText = "Tall", QuestionId = 2 },
                new Option { Id = 4, OptionText = "Medium", QuestionId = 2 },
                new Option { Id = 5, OptionText = "Short", QuestionId = 2 },
                new Option { Id = 6, OptionText = "Old", QuestionId = 3 },
                new Option { Id = 7, OptionText = "Young", QuestionId = 3 },
                new Option { Id = 8, OptionText = "Middle-aged", QuestionId = 3 },
                new Option { Id = 9, OptionText = "Yes", QuestionId = 4 },
                new Option { Id = 10, OptionText = "No", QuestionId = 4 },
                new Option { Id = 11, OptionText = "Yes", QuestionId = 5 },
                new Option { Id = 12, OptionText = "No", QuestionId = 5 },
                new Option { Id = 13, OptionText = "Yes", QuestionId = 6 },
                new Option { Id = 14, OptionText = "No", QuestionId = 6 },
                new Option { Id = 15, OptionText = "Yes", QuestionId = 7 },
                new Option { Id = 16, OptionText = "No", QuestionId = 7 },
                new Option { Id = 17, OptionText = "Yes", QuestionId = 8 },
                new Option { Id = 18, OptionText = "No", QuestionId = 8 },
                new Option { Id = 19, OptionText = "Yes", QuestionId = 9 },
                new Option { Id = 20, OptionText = "No", QuestionId = 9 },
                new Option { Id = 21, OptionText = "Yes", QuestionId = 10 },
                new Option { Id = 22, OptionText = "No", QuestionId = 10 },
                new Option { Id = 23, OptionText = "Yes", QuestionId = 11 },
                new Option { Id = 24, OptionText = "No", QuestionId = 11 },
                new Option { Id = 25, OptionText = "Yes", QuestionId = 12 },
                new Option { Id = 26, OptionText = "No", QuestionId = 12 },
                new Option { Id = 27, OptionText = "Yes", QuestionId = 13 },
                new Option { Id = 28, OptionText = "No", QuestionId = 13 },
                new Option { Id = 29, OptionText = "Yes", QuestionId = 14 },
                new Option { Id = 30, OptionText = "No", QuestionId = 14 },
                new Option { Id = 31, OptionText = "Yes", QuestionId = 15 },
                new Option { Id = 32, OptionText = "No", QuestionId = 15 }
            );
        }
    }
}
