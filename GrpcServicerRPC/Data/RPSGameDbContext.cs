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

        // Código extra para tornar os campos de Username, Email e SessionID únicos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrpcServerRPS.Models.User>(b =>
            {
                b.Property<string>("Username")
                            .IsRequired()
                            .ValueGeneratedOnAdd()
                            .HasColumnType("nvarchar(max)");

                b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)");

                b.Property<string>("SessionID")
                    .HasColumnType("nvarchar(max)");


                b.HasIndex("Username")
                    .IsUnique();

                b.HasIndex("Email")
                    .IsUnique();

                b.HasIndex("SessionID")
                    .IsUnique();
            });
        }
    }
}
