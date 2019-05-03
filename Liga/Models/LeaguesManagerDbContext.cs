using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Liga.Models
{
    public class LeaguesManagerDbContext : DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Match> Matches { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Match>()
                .HasRequired(x => x.HomeClubs)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamID);

            modelBuilder.Entity<Match>()
                .HasRequired(x => x.AwayClubs)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamID);
        }
    }
}