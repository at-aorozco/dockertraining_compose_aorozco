using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dockertraining_compose_aorozco.Models
{
    public class GamesContext : DbContext
    {
        public DbSet<Game> Game { get; set; }

        public GamesContext(DbContextOptions options) : base(options)
        {

        }
    }
}
