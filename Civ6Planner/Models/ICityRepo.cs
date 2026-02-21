using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public interface ICityRepo
    {
        IEnumerable<CityModel> GetByGameId(int gameId);
        List<string> GetCitiesByCivId(int civId);
        void AddCitiesToGame(int gameId, int civId);
    }
}
