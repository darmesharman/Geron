using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Geron.Models
{
    public class TriangleContext : DbContext
    {
        public DbSet<Triangle> Triangles { get; set; }

        public TriangleContext(DbContextOptions<TriangleContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
