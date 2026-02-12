using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public class TaskModel
    {
        private int _taskId;
        private string _name;
        private string _type; // Tech-Civic-CityStateQuest-Custom
        private string _boosts; // Unlock task will boost
        private string _status; // Incomplete-Complete
        private int _gameId;
        // assigned city id

        public int TaskId { get => _taskId; set => _taskId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public string Boosts { get => _boosts; set => _boosts = value; }
        public string Status { get => _status; set => _status = value; }
        public int GameId { get => _gameId; set => _gameId = value; }
    }
}
