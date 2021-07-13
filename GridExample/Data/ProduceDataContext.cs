using GridExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridExample.Data
{
    public class ProduceDataContext : DbContext
    {
        public ProduceDataContext(DbContextOptions<ProduceDataContext> options) : base(options) 
        { 
        }

        public DbSet<Produce> Produce { get; set; }

    }
}
