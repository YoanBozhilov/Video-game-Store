using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AllDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public AllDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

