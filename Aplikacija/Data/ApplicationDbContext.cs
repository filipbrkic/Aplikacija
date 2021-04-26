using Aplikacija.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacija.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Predbiljezba> Predbiljezbas { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Zaposlenik> Zaposleniks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predbiljezba>().ToTable("Predbiljezba");
            modelBuilder.Entity<Seminar>().ToTable("Seminar");
            modelBuilder.Entity<Zaposlenik>().ToTable("Zaposlenik");
            base.OnModelCreating(modelBuilder);
        }
    }
}
