using DegenPokerApp.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace DegenPokerApp.Api.Service
{
    public class DegenPokerAppService
    {
        private readonly IDbContextFactory<DegenPokerContext> _contextFactory;
        public DegenPokerAppService(IDbContextFactory<DegenPokerContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private async Task RecreateDatabase()
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        public async Task RunSample()
        {
            await RecreateDatabase();

            //Todo
        }
    }
}
