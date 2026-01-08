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
        public DbSet<Role> Roles { get; set; }

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
            });

            // TEAM
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity.Property(t => t.TeamName)
                      .IsRequired()
                      .HasMaxLength(100);

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

            

            // ROLE
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);

                entity.Property(r => r.RoleName)
                      .IsRequired()
                      .HasMaxLength(50);
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
