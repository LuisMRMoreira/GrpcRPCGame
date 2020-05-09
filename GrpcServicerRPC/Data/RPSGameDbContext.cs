using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServerRPS.Data
{
    public class RPSGameDbContext : DbContext
    {

        public RPSGameDbContext(DbContextOptions<RPSGameDbContext> options)
    : base(options)
        {
        }

        public DbSet<GrpcServerRPS.Models.User> User { get; set; }

        public DbSet<GrpcServerRPS.Models.History> History { get; set; }

    }
}
