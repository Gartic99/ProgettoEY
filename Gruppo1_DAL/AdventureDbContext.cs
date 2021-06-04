using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppo1_Model;

namespace Gruppo1_DAL
{
    public class AdventureDbContext : DbContext
    {
        public AdventureDbContext(DbContextOptions<AdventureDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }

    }
}
