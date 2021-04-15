using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Data
{
    public class AplikacijaContext : DbContext
    {
        public AplikacijaContext(DbContextOptions<AplikacijaContext> options) : base(options)
        {
        }

        public DbSet<Predbiljezba> Predbiljezbas { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Zaposlenik> Zaposleniks { get; set; }
    }
}
