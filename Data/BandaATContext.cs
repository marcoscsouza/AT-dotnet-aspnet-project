using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Data
{
    public class BandaATContext : DbContext
    {
        public BandaATContext (DbContextOptions<BandaATContext> options)
            : base(options)
        {
        }

        public DbSet<BandaModel> Bandas { get; set; }

        public DbSet<MusicoModel> Musicos { get; set; }
    }
}
