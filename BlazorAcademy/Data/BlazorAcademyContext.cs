using Microsoft.EntityFrameworkCore;
using BlazorAcademy.Models;

namespace BlazorAcademy.Data
{
    public class BlazorAcademyContext : DbContext
    {
        public BlazorAcademyContext(DbContextOptions<BlazorAcademyContext> options)
            : base(options)
        {
        }

        public DbSet<Direction> Directions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Discipline> Disciplines { get; set; }
    }
}