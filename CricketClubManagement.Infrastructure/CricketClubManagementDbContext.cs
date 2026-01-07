using CricketClubManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CricketClubManagement.Infrastructure
{
    public class CricketClubManagementDbContext : DbContext
    {
        public CricketClubManagementDbContext(DbContextOptions<CricketClubManagementDbContext> options)
        : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerMatch> PlayerMatches { get; set; }
        public DbSet<TeamSeason> TeamSeasons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Fee> Fees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PLAYER
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity.Property(p => p.PlayerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.PlayerContact)
                      .HasMaxLength(30);

                entity.Property(p => p.PlayerAge)
                      .IsRequired();

                entity.HasOne(p => p.Role)
                      .WithMany(r => r.Players)
                      .HasForeignKey(p => p.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.Fees)
                      .WithOne(f => f.Player)
                      .HasForeignKey(f => f.PlayerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.PlayerMatches)
                      .WithOne(pm => pm.Player)
                      .HasForeignKey(pm => pm.PlayerId);
            });

            // TEAM
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity.Property(t => t.TeamName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasMany(t => t.TeamSeasons)
                      .WithOne(ts => ts.Team)
                      .HasForeignKey(ts => ts.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.HomeMatches)
                      .WithOne(m => m.HomeTeam)
                      .HasForeignKey(m => m.HomeTeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.AwayMatches)
                      .WithOne(m => m.AwayTeam)
                      .HasForeignKey(m => m.AwayTeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // MATCH
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(m => m.MatchId);

                entity.Property(m => m.MatchName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(m => m.MatchDate)
                      .IsRequired();

                entity.HasOne(m => m.Season)
                      .WithMany(s => s.Matches)
                      .HasForeignKey(m => m.SeasonId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // PLAYERMATCH (bridge)
            modelBuilder.Entity<PlayerMatch>(entity =>
            {
                entity.HasKey(pm => new { pm.PlayerId, pm.MatchId });

                entity.Property(pm => pm.RunsScored).IsRequired(false);
                entity.Property(pm => pm.WicketsTaken).IsRequired(false);
                entity.Property(pm => pm.Catches).IsRequired(false);
            });

            // TEAMSEASON (bridge)
            modelBuilder.Entity<TeamSeason>(entity =>
            {
                entity.HasKey(ts => new { ts.TeamId, ts.SeasonId });

                entity.HasOne(ts => ts.Team)
                      .WithMany(t => t.TeamSeasons)
                      .HasForeignKey(ts => ts.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ts => ts.Season)
                      .WithMany(s => s.TeamSeasons)
                      .HasForeignKey(ts => ts.SeasonId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ROLE
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);

                entity.Property(r => r.RoleName)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            // FEE
            modelBuilder.Entity<Fee>(entity =>
            {
                entity.HasKey(f => f.FeeId);

                entity.Property(f => f.Amount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(f => f.FeeDate)
                      .IsRequired();

                entity.HasOne(f => f.Player)
                      .WithMany(p => p.Fees)
                      .HasForeignKey(f => f.PlayerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // SEASON
            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasKey(s => s.SeasonId);

                entity.Property(s => s.SeasonTitle)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.SeasonStartDate)
                      .IsRequired();

                entity.Property(s => s.SeasonEndDate)
                      .IsRequired();
            });
        }
    }
}
