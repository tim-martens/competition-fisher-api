using CompetitionFisher.Data;
using CompetitionFisher.Data.Entities;
using System.Linq;
using System.Web.Http;

namespace CompetitionFisher.Api.Controllers
{
    public class CompetitorController : ApiController
    {
        private CfContext db = new CfContext();

        // GET: api/Users
        public IQueryable<Competitor> GetCompetitors()
        {
            return db.Competitors;
        }

    }
}
