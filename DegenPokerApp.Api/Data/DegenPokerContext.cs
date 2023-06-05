using DegenPokerApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace DegenPokerApp.Api.Data
{
    public class DegenPokerContext : DbContext
    {
        public DegenPokerContext(DbContextOptions<DegenPokerContext> options)
            : base(options)
        { }

        #region DbSets
        public DbSet<Country> Countries { get; set; }
        //public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }

        public DbSet<PokerClub> PokerClubs { get; set; }
        public DbSet<PokerSession> PokerSessions { get; set; }
        public DbSet<Stakes> Stakes { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //todo
        }
    }
}
