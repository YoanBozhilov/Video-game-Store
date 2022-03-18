using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GameDbContext : DbContext
    {
 
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=sql11.freemysqlhosting.net;Database=sql11478779;Uid=sql11478779;Pwd=2VwczEdqM8;");
        }

    }
}
