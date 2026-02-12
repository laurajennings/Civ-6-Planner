using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public class TaskModel
    {
        private int taskId;
        private string name;
        private string type; // Tech-Civic-CityStateQuest-Custom
        private string boosts;
        private string status;
        // city foreign key

        public int TaskId { get => taskId; set => taskId = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Boosts { get => boosts; set => boosts = value; }
        public string Status { get => status; set => status = value; }
    }
}
