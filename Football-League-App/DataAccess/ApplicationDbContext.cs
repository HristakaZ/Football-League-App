﻿using DataStructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<FootballTeam> FootballTeams { get; set; }

        public DbSet<FootballPlayer> FootballPlayers { get; set; }

        public DbSet<FootballLeague> FootballLeagues { get; set; }

        public DbSet<FootballMatch> FootballMatches { get; set; }
    }
}
