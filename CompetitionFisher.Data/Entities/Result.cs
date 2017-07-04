using System;

namespace CompetitionFisher.Data.Entities
{
    public class Result
    {
        public Guid ResultId { get; set; }

        public Guid FishermanId { get; set; }
        public Fisherman Fisherman { get; set; }

        public Guid CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public int NbrCaught { get; set; }
        public int Weight { get; set; }
    }
}
