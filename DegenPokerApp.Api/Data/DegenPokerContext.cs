using DegenPokerApp.Shared.Domain;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace DegenPokerApp.Api.Data
{
    public class DegenPokerContext : DbContext
    {
        #region startup

        readonly string databaseName = default!;
        readonly string containerName = default!;
        private Container _container = default!;
        private Database _database = default!;
        private CosmosClient _client = default!;

        public DegenPokerContext(DbContextOptions<DegenPokerContext> options, IConfiguration configuration)
            : base(options)
        {
            _client = new CosmosClient(configuration["CosmosDB:URL"], configuration["CosmosDB:PrimaryKey"],
                new CosmosClientOptions() { ApplicationName = "DegenPokerAppClient" });
            databaseName = configuration["DatabaseName"];
            containerName = "DegenApp";

            BuildCollection().Wait();

        }



        private async Task BuildCollection()
        {
            _database = await _client.CreateDatabaseIfNotExistsAsync(databaseName);
            _container = await _database.CreateContainerIfNotExistsAsync(containerName, "/PokerClubId", 400);
            _container = _client.GetContainer(databaseName, containerName);
        }

        #endregion


        #region pokerclubs

        public async Task<List<PokerClub>> GetAllPokerClubs()
        {
            var sqlQueryGetAll = "SELECT * FROM C";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryGetAll);

            FeedIterator<PokerClub> queryResultSetIterator = _container.GetItemQueryIterator<PokerClub>(queryDefinition);
            List<PokerClub> pokerClubs = new List<PokerClub>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<PokerClub> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (PokerClub pokerClub in currentResultSet)
                {
                    pokerClubs.Add(pokerClub);
                }
            }

            return pokerClubs;
        }

        public async Task<PokerClub> AddPokerClub(PokerClub pokerClub)
        {
            return await _container.UpsertItemAsync<PokerClub>(pokerClub, new PartitionKey(pokerClub.PokerClubId));
        }

        public async Task<PokerClub> GetPokerClubDetails(string id, string pokerClubId)
        {

            return await _container.ReadItemAsync<PokerClub>(id, new PartitionKey(pokerClubId));
        }

        public async Task<PokerClub> UpdatePokerClub(PokerClub pokerClub)
        {
            return await _container.UpsertItemAsync(pokerClub, new PartitionKey(pokerClub.PokerClubId));
        }

        internal async Task DeletePokerClub(string id, string pokerClubId)
        {
            await _container.DeleteItemAsync<PokerClub>(id, new PartitionKey(pokerClubId));
        }

        #endregion
    }



}
