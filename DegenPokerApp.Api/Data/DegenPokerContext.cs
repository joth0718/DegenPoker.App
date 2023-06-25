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
            _container = await _database.CreateContainerIfNotExistsAsync(containerName, "/UserId", 400);
            _container = _client.GetContainer(databaseName, containerName);
        }

        #endregion


        #region pokerclubs

        public async Task<List<PokerClub>> GetAllPokerClubs()
        {
            var sqlQueryGetAll = "SELECT * FROM C WHERE C.Type=\"PokerClub\"";
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

        public async Task<PokerClub> AddOrUpdatePokerClub(PokerClub pokerClub)
        {
            return await _container.UpsertItemAsync<PokerClub>(pokerClub, new PartitionKey(pokerClub.UserId));
        }

        public async Task<PokerClub> GetPokerClubDetails(string id, string userId)
        {

            return await _container.ReadItemAsync<PokerClub>(id, new PartitionKey(userId));
        }

        public async Task<PokerClub> UpdatePokerClub(PokerClub pokerClub)
        {
            return await _container.UpsertItemAsync(pokerClub, new PartitionKey(pokerClub.UserId));
        }

        internal async Task DeletePokerClub(string id, string userId)
        {
            await _container.DeleteItemAsync<PokerClub>(id, new PartitionKey(userId));
        }


        #endregion

        #region Sessions

        internal async Task<IEnumerable<PokerSession>> GetAllPokerSessions()
        {
            var sqlQueryGetAll = "SELECT * FROM C WHERE C.Type=\"PokerSession\"";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryGetAll);

            FeedIterator<PokerSession> queryResultSetIterator = _container.GetItemQueryIterator<PokerSession>(queryDefinition);
            List<PokerSession> pokerSessions = new List<PokerSession>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<PokerSession> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (PokerSession pokerSession in currentResultSet)
                {
                    pokerSessions.Add(pokerSession);
                }
            }
            return pokerSessions;
        }

        internal async Task<PokerSession> GetPokerSessionDetails(string id, string userId)
        {
            var result = await _container.ReadItemAsync<PokerSession>(id, new PartitionKey(userId));
            return result;
        }

        internal async Task<PokerSession> AddOrUpdatePokerSession(PokerSession session)
        {
            return await _container.UpsertItemAsync<PokerSession>(session, new PartitionKey(session.UserId));
        }

        internal async Task DeletePokerSession(string id, string userId)
        {
            await _container.DeleteItemAsync<PokerSession>(id, new PartitionKey(userId));
        }

        #endregion

        #region GameTypes
        internal async Task<IEnumerable<GameType>> GetAllGameTypes()
        {
            var sqlQueryGetAll = "SELECT * FROM C WHERE C.Type=\"GameType\"";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryGetAll);

            FeedIterator<GameType> queryResultSetIterator = _container.GetItemQueryIterator<GameType>(queryDefinition);
            List<GameType> gameTypes = new List<GameType>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<GameType> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (GameType gameType in currentResultSet)
                {
                    gameTypes.Add(gameType);
                }
            }
            return gameTypes;
        }

        #endregion
    }



}
