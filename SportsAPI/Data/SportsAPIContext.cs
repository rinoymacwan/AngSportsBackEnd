using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsAPI.Data;

namespace SportsAPI.Models
{
    public class SportsAPIContext : DbContext
    {
        public SportsAPIContext (DbContextOptions<SportsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SportsAPI.Data.Test> Test { get; set; }

        public DbSet<SportsAPI.Data.User> User { get; set; }

        public DbSet<SportsAPI.Data.UserTestMapping> UserTestMapping { get; set; }
    }
}
