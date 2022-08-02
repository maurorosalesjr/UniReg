using System;
using Microsoft.EntityFrameworkCore;

namespace UniReg.Models
{
    public class UniRegContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        public UniRegContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
