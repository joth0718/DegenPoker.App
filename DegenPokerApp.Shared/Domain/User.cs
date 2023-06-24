namespace DegenPokerApp.Shared.Domain
{
    public class User
    {
        public string id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public Country? Country { get; set; } = default!;
        public string? Comment { get; set; }
        public DateTime? JoinedDate { get; set; }
    }
}
