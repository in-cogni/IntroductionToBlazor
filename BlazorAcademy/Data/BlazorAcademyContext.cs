using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Direction> Directions { get; set; } = default!;
        public DbSet<Group> Groups { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;
        //public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<TeacherSimple> TeacherSimples { get; set; } = default!; 
        public DbSet<Discipline> Disciplines { get; set; } = default!;
    }
}