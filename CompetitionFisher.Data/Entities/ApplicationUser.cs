using System;

namespace CompetitionFisher.Data.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; } // is set to CompetitorId in configuration
        public string FaceBookId { get; set; }
        public virtual User User { get; set; } // must have a User
        //public virtual ICollection<Championship> Championships { get; set; }
    }

}
