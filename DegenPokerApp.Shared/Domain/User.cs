using System;

namespace DegenPokerApp.Shared.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country? Country { get; set; } = default!;
        public string? Comment { get; set; }
        public DateTime? JoinedDate { get; set; }
    }
}
