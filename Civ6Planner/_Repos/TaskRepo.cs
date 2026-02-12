using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner._Repos
{
    public class TaskRepo : BaseRepo, ITaskRepo
    {
        public TaskRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(TaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(TaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskModel> GetAll()
        {
            var taskList = new List<TaskModel>();
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tasks";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var taskModel = new TaskModel();
                        taskModel.TaskId = Convert.ToInt32(reader[0]);
                        taskModel.Name = reader[1].ToString();
                        taskModel.Type = reader[2].ToString();
                        taskModel.Boosts = reader[3].ToString();
                        taskList.Add(taskModel);
                    }
                }
            }
            Debug.WriteLine($"task list: {taskList.Count}");
            return taskList;
        }
    }
}
