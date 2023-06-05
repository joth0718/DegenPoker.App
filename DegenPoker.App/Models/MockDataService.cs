using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.App.Models
{
    public class MockDataService
    {
        private static List<User>? _users = default!;
        private static List<GameType> _gameTypes = default!;
        private static List<PokerSession> _sessions = default!;
        private static List<PokerClub> _pokerClubs = default!;
        private static List<Stakes> _stakes = default!;
        private static List<Country> _countries = default!;

        public static List<User> Users
        {
            get
            {
                //we will use these in initialization of Users
                _countries ??= InitializeMockCountries();

                _gameTypes ??= InitializeMockGameTypes();

                _sessions ??= InitializeMockPokerSessions();

                _stakes ??= InitializeMockStakes();

                _pokerClubs ??= InitializeMockPokerClubs();

                _users ??= InitializeMockUsers();

                return _users;
            }
        }

        public static List<PokerClub> PokerClubs
        {
            get
            {
                //we will use these in initialization of Users
                _countries ??= InitializeMockCountries();

                _gameTypes ??= InitializeMockGameTypes();

                _sessions ??= InitializeMockPokerSessions();

                _stakes ??= InitializeMockStakes();

                _pokerClubs ??= InitializeMockPokerClubs();

                _users ??= InitializeMockUsers();

                return _pokerClubs;
            }
        }

        public static List<PokerSession> PokerSessions
        {
            get
            {
                //we will use these in initialization of Users
                _countries ??= InitializeMockCountries();

                _gameTypes ??= InitializeMockGameTypes();

                _sessions ??= InitializeMockPokerSessions();

                _stakes ??= InitializeMockStakes();

                _pokerClubs ??= InitializeMockPokerClubs();

                _users ??= InitializeMockUsers();

                return _sessions;
            }
        }

        public static List<Stakes> Stakes
        {
            get
            {
                //we will use these in initialization of Users
                _countries ??= InitializeMockCountries();

                _gameTypes ??= InitializeMockGameTypes();

                _sessions ??= InitializeMockPokerSessions();

                _stakes ??= InitializeMockStakes();

                _pokerClubs ??= InitializeMockPokerClubs();

                _users ??= InitializeMockUsers();

                return _stakes;
            }
        }


        private static List<Stakes> InitializeMockStakes()
        {
            return new List<Stakes>()
            {
                new Stakes { StakeId = 1, StakeName = "1/2", UserId = 2 },
                new Stakes { StakeId = 2, StakeName = "10/20/40", UserId = 1 },
                new Stakes { StakeId = 3, StakeName = "50/100/200", UserId = 1 }
            };
        }

        private static List<PokerClub> InitializeMockPokerClubs()
        {
            return new List<PokerClub>()
            {
                new PokerClub { PokerClubId = 1, PokerClubName = "Nuts", UserId=1 },
                new PokerClub { PokerClubId = 2, PokerClubName = "Route66", UserId=1 },
                new PokerClub { PokerClubId = 3, PokerClubName = "Queens", UserId=1 },
                new PokerClub { PokerClubId = 4, PokerClubName = "Ipkr", UserId=1 }
            };

        }

        private static List<PokerSession> InitializeMockPokerSessions()
        {
            var s1 = new PokerSession
            {
                PokerSessionId = 1,
                Comment = "TILT",
                GameTypeId = 1,
                GameId = 1,
                UserId = 1,
                StakesId = 3,
                NrOfHands = 500,
                PokerClubId = 1,
                Result = -5000,
                SessionDate = new DateTime(2023, 6, 1)
            };
            var s2 = new PokerSession
            {
                PokerSessionId = 2,
                Comment = "I'm AWESOME",
                GameTypeId = 1,
                UserId = 1,
                StakesId = 2,
                GameId = 2,
                NrOfHands = 2832,
                PokerClubId = 2,
                Result = 12726,
                SessionDate = new DateTime(2023, 6, 2)
            };
            var s3 = new PokerSession
            {
                PokerSessionId = 3,
                Comment = "I'm a horse",
                GameTypeId = 1,
                StakesId = 1,
                UserId = 2,
                GameId = 2,
                NrOfHands = 2832,
                PokerClubId = 2,
                Result = 5192,
                SessionDate = new DateTime(2023, 6, 2)
            };
            var s4 = new PokerSession
            {
                PokerSessionId = 4,
                Comment = "I'm a grizzly",
                GameTypeId = 1,
                StakesId = 1,
                UserId = 2,
                GameId = 2,
                NrOfHands = 2832,
                PokerClubId = 2,
                Result = 7123,
                SessionDate = new DateTime(2023, 6, 2)
            };
            var s5 = new PokerSession
            {
                PokerSessionId = 5,
                Comment = "",
                GameTypeId = 1,
                StakesId = 1,
                UserId = 2,
                GameId = 2,
                NrOfHands = 2832,
                PokerClubId = 2,
                Result = 7123,
                SessionDate = new DateTime(2023, 6, 2)
            };

            return new List<PokerSession>() { s1, s2, s3, s4, s5 };
        }

        private static List<User> InitializeMockUsers()
        {
            var e1 = new User
            {
                BirthDate = new DateTime(1989, 3, 11),
                Email = "degen@hustler.com",
                UserId = 1,
                FirstName = "Degen",
                LastName = "Hustler",
                Comment = "Hardest man of them all",
                JoinedDate = new DateTime(2015, 3, 1),
                Country = _countries[0],
                CountryId = _countries[0].CountryId
            };

            var e2 = new User
            {
                BirthDate = new DateTime(1979, 1, 16),
                Email = "stripps@crushers.com",
                UserId = 2,
                FirstName = "Stripps",
                LastName = "Teddy",
                Comment = "Likes to hug people",
                JoinedDate = new DateTime(2017, 12, 24),
                Country = _countries[1],
                CountryId = _countries[1].CountryId
            };

            return new List<User>() { e1, e2 };
        }

        private static List<GameType> InitializeMockGameTypes()
        {
            return new List<GameType>()
            {
                new GameType{GameTypeId = 1, GameTypeName = "PLO"},
                new GameType{GameTypeId = 2, GameTypeName = "PLO5"},
                new GameType{GameTypeId = 3, GameTypeName = "PLO6"},
                new GameType{GameTypeId = 4, GameTypeName = "NLHE"},
                new GameType{GameTypeId = 5, GameTypeName = "Drawmaha"},
                new GameType{GameTypeId = 6, GameTypeName = "Shortdeck"}
            };
        }

        private static List<Country> InitializeMockCountries()
        {
            return new List<Country>
            {
                new Country {CountryId = 1, Name = "Norway"},
                new Country {CountryId = 2, Name = "Netherlands"},
                new Country {CountryId = 3, Name = "USA"},
                new Country {CountryId = 4, Name = "Sweden"},
                new Country {CountryId = 5, Name = "Denmark"},
                new Country {CountryId = 6, Name = "UK"},
                new Country {CountryId = 7, Name = "France"},
                new Country {CountryId = 8, Name = "Brazil"}
            };
        }
    }
}





