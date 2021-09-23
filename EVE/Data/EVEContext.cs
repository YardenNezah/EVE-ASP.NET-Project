using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EVE.Models;

namespace EVE.Data
{
    public class EVEContext : DbContext
    {
        public EVEContext (DbContextOptions<EVEContext> options)
            : base(options)
        {
        }

        public DbSet<EVE.Models.Product> Product { get; set; }

        public DbSet<EVE.Models.Member> Member { get; set; }

        public DbSet<EVE.Models.Transaction> Transaction { get; set; }

        public DbSet<EVE.Models.Rating> Rating { get; set; }

        public DbSet<EVE.Models.Cart> Cart { get; set; }

        public DbSet<EVE.Models.Comment> Comment { get; set; }
    }
}
