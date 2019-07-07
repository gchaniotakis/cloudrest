using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace cloudrest.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base ("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Selection>()
                .HasRequired<User>(m => m.Teacher)
                .WithMany(u => u.TeacherSelections)
                .HasForeignKey(m => m.TeacherId);

            modelBuilder.Entity<Selection>()
                .HasOptional<User>(m => m.Student)
                .WithMany(u => u.StudentSelections)
                .HasForeignKey(m => m.StudentId)
                .WillCascadeOnDelete(false);
        }
    }
}