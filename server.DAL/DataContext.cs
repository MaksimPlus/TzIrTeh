using Microsoft.EntityFrameworkCore;
using server.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DAL
{
    public class DataDbContext : DbContext 
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                 .HasOne(p => p.Questionnaire)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(j => j.Name).IsUnique(); 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired();
            modelBuilder.Entity<User>().HasData(
                new User {Id = 1, Name = "Maxim", Password = "Maxim1"}
                );
        }
        
    }
}
