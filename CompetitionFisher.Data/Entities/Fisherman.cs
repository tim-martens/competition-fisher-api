﻿using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class Fisherman
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }

    }
}
