using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetitionFisher.Data;
using CompetitionFisher.Data.Entities;

namespace CompetitionFisher.Api.Controllers
{
    public class FishermenController : ApiController
    {
        private CfContext db = new CfContext();

        // GET: api/Users
        public IQueryable<Fisherman> GetFishermen()
        {
            return db.Fishermen;
        }

    }
}
