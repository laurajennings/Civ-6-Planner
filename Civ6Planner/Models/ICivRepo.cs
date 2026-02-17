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
        IEnumerable<CityModel> GetCitiesByCivId(int civId);
    }
}
