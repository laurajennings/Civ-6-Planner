using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public interface ICivRepo
    {
        IEnumerable<CivModel> GetAll();
        CivModel GetById(int civId);
        List<string> GetCitiesByCivId(int civId);
        void AddCitiesToGame(int gameId, int civId);
    }
}
