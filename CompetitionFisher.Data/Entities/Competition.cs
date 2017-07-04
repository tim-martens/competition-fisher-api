using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class Competition
    {
        public Guid CompetitionId { get; set; }

        public DateTime CompetitionDate { get; set; }

        public ICollection<Fisherman> Fishermen { get; set; }
        public ICollection<Result> Results { get; set; }
    }

}
