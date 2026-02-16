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
        private readonly string csvPathTasks = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.csv");
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
            using (var command = new SQLiteCommand())
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
            return taskList;
        }

        public void AddDefaultTasksToGame(int gameId)
        {
            var taskList = ReadTasksFromCsv();

            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tasks (name, type, boosts, status, game_id) VALUES (@name, @type, @boosts, @status, @game_id)";
                foreach (var task in taskList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", task.Name);
                    command.Parameters.AddWithValue("@type", task.Type);
                    command.Parameters.AddWithValue("@boosts", task.Boosts);
                    command.Parameters.AddWithValue("@status", task.Status);
                    command.Parameters.AddWithValue("@game_id", gameId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<TaskModel> ReadTasksFromCsv()
        {
            if (!File.Exists(csvPathTasks))
            {
                throw new FileNotFoundException($"csv not found: {csvPathTasks}");
            }
            var taskList = new List<TaskModel>();
            var lines = File.ReadAllLines(csvPathTasks);

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;
                var values = line.Split(',');
                if (values.Length >= 4)
                {
                    taskList.Add(new TaskModel
                    {
                        Name = values[0].Trim(),
                        Type = values[1].Trim(),
                        Boosts = values[2].Trim(),
                        Status = values[3].Trim()
                    });
                }
            }
            return taskList;
        }

        public IEnumerable<TaskModel> GetByGameId(int gameId)
        {
            var taskList = new List<TaskModel>();
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tasks WHERE game_id = @game_id";
                command.Parameters.AddWithValue("@game_id", gameId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var taskModel = new TaskModel();
                        taskModel.TaskId = Convert.ToInt32(reader[0]);
                        taskModel.Name = reader[1].ToString();
                        taskModel.Type = reader[2].ToString();
                        taskModel.Boosts = reader[3].ToString();
                        taskModel.Status = reader[4].ToString();
                        taskList.Add(taskModel);
                    }
                }
                return taskList;
            }
        }
    }
}
