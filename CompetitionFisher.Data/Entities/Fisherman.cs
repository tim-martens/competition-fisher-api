using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class Fisherman
    {
        public Guid FishermanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Competition> Competitions { get; set; }

    }
}
