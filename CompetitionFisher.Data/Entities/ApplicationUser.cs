using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Championship> Championships { get; set; }
    }

}
