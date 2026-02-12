using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public interface ITaskRepo
    {
        void Add(TaskModel taskModel);
        void Edit(TaskModel taskModel);
        void Delete(TaskModel taskModel);
        void AddDefaultTasksToGame(int gameId);
        IEnumerable<TaskModel> GetByGameId(int gameId);
        IEnumerable<TaskModel> GetAll();

        // Search by name
        // Search by boosts
        // Filter by type
    }
}
