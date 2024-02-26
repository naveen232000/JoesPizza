using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JoesPizza.Models;

namespace JoesPizza.Data
{
    public class JoesPizzaContext : DbContext
    {
        public JoesPizzaContext (DbContextOptions<JoesPizzaContext> options)
            : base(options)
        {
        }

        public DbSet<JoesPizza.Models.Pizza> Pizza { get; set; } = default!;

        public DbSet<JoesPizza.Models.OrderDetails>? OrderDetails { get; set; }
    }
}
