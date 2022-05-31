using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema3.Models;

namespace Cinema3.Data
{
    public class Cinema3Context : DbContext
    {
        public Cinema3Context (DbContextOptions<Cinema3Context> options)
            : base(options)
        {
        }

        public DbSet<Cinema3.Models.Filme> Filme { get; set; }

        public DbSet<Cinema3.Models.Periodo> Periodo { get; set; }

        public DbSet<Cinema3.Models.Sala> Sala { get; set; }

        public DbSet<Cinema3.Models.Ingressos> Ingressos { get; set; }
    }
}
