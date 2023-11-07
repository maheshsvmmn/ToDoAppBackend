using Microsoft.EntityFrameworkCore;
using NoetesAPI.Models;

namespace NoetesAPI.Context
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) :base (options){   }


        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "user1", Email = "madhav@gmail.com", Password = "password", CreatedAt = DateTime.Now },
                new User { Id = 2, Name = "user2", Email = "user1@gmail.com", Password = "password", CreatedAt = DateTime.Now },
                new User { Id = 3, Name = "Madhav", Email = "user@gmail.com", Password = "password", CreatedAt = DateTime.Now }
                );

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();
            
            modelBuilder.Entity<Note>()
                .HasIndex(u => u.Id)
                .IsUnique();

            

        }
    }
}
