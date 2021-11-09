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

        public DbSet<EVE.Models.Rating> Rating { get; set; }

        public DbSet<EVE.Models.Cart> Cart { get; set; }

        public DbSet<EVE.Models.Comment> Comment { get; set; }

        public DbSet<EVE.Models.About> About { get; set; }

        public DbSet<EVE.Models.ProductType> ProductType { get; set; }

        public DbSet<EVE.Models.OrderDetail> OrderDetail { get; set; }

        public DbSet<EVE.Models.Favorite> Favorite { get; set; }

    }
}
