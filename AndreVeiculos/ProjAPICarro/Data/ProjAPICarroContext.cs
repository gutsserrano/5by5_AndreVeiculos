using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAPICarro.Data
{
    public class ProjAPICarroContext : DbContext
    {
        public ProjAPICarroContext (DbContextOptions<ProjAPICarroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Operation> Operations { get; set; } = default!;
        public DbSet<Models.CarOperation> CarOperations { get; set; } = default!;
        public DbSet<Models.Person>? People { get; set; } = default!;
        public DbSet<Models.Client>? Clients { get; set; } = default!;
        public DbSet<Models.Employee>? Employees { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a chave primária na entidade raiz Pessoa
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Document);

            modelBuilder.Entity<Client>()
                .ToTable("Client");

            modelBuilder.Entity<Employee>()
                .ToTable("Employee");

            modelBuilder.Entity<CarOperation>()
                .HasOne<Car>()
                .WithMany();

            modelBuilder.Entity<CarOperation>()
                .HasOne<Operation>()
                .WithMany();

        }
    }
}
