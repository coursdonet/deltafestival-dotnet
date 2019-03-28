using System;

namespace Entities
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int MembersCount { get; set; }
        public int Score { get; set; }

        public DateTime? WinDate { get; set; }
    }
}
