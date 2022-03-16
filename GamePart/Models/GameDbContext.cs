using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePart.Models
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GameDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}