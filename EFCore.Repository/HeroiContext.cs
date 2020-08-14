﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore.Domain;

namespace EFCore.Repository
{
    public class HeroiContext : DbContext
    {
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }
    }
}
