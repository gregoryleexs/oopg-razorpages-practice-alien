using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Area51.Models;

namespace Area51.Data
{
    public class Area51Context : DbContext
    {
        public Area51Context (DbContextOptions<Area51Context> options)
            : base(options)
        {
        }

        public DbSet<Area51.Models.Alien> Alien { get; set; } = default!;
    }
}
