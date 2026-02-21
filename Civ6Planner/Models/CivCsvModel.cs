using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public class CivCsvModel
    {
        private string _name;
        private string _leader;
        private string _abilities;
        private string _cities;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Leader
        {
            get { return _leader; }
            set { _leader = value; }
        }
        public string Abilities
        {
            get { return _abilities; }
            set { _abilities = value; }
        }

        public string Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }
    }
}
