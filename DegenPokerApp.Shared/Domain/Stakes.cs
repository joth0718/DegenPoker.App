using System;
using System.ComponentModel.DataAnnotations;

namespace DegenPokerApp.Shared.Domain
{
    public class Stakes
    {
        public int StakeId { get; set; }
        public string? StakeName { get; set; }
    }
}
