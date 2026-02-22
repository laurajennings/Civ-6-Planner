using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public class CityModel
    {
        private int _cityId;
        private string _name;
        private bool _settled;
        private int _civId;

        public int CityId { get => _cityId; set => _cityId = value; }
        public string Name { get => _name; set => _name = value; }
        public bool Settled { get => _settled; set => _settled = value; }
        public int CivId { get => _civId; set => _civId = value; }
    }
}
