using Microsoft.EntityFrameworkCore;
using Prodesp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Repository.Data
{
    public class ProdespContext : DbContext
    {
        public ProdespContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Imunobiologico> Imunobiologicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imunobiologico>()
                .HasKey(i => i.Id);
        }
    }
}
