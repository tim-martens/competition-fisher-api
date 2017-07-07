﻿using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } // may have a Application user or not
        public virtual ICollection<Competition> Competitions { get; set; }

    }
}