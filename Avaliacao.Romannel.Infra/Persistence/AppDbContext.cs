﻿using Avaliacao.Romannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<ClienteComplemento> ClienteComplemento => Set<ClienteComplemento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations using Fluent API
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
