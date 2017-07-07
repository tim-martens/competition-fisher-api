using CompetitionFisher.Data;
using System.Linq;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CfContext())
            {
                var users = db.Users.ToList();
                var champ = db.Championships.ToList();
                var temp = champ;
            }
        }
    }
}
