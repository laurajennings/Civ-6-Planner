using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public class GameModel
    {
        private int _gameId;
        private string _name;
        private string _notes;
        private int _civId;
        private IEnumerable<CityModel> _cities;
        // cities settled
        // tasks
        // focused achievements

        public int GameId
        {
            get { return _gameId; }
            set { _gameId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        public int CivId
        {
            get { return _civId; }
            set { _civId = value; }
        }
        public IEnumerable<CityModel> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }
       
    }
}
