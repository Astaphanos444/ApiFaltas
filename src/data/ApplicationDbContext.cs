using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.model;
using Microsoft.EntityFrameworkCore;

namespace app.src.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
       : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Falta> Faltas { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Falta>()
                .HasOne(f => f.User)
                .WithMany(u => u.Faltas)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict); // OU DeleteBehavior.NoAction
        }
    }
}