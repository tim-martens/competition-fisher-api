using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Championship> Championships { get; set; }
    }

}
