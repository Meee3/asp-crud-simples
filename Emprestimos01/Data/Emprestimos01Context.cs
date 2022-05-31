using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Emprestimos01.Models;

namespace Emprestimos01.Data
{
    public class Emprestimos01Context : DbContext
    {
        public Emprestimos01Context (DbContextOptions<Emprestimos01Context> options)
            : base(options)
        {
        }

        public DbSet<Emprestimos01.Models.Emprestimos> Emprestimos { get; set; }
    }
}
