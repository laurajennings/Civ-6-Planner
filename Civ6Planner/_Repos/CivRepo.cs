using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Civ6Planner._Repos
{
    public class CivRepo : BaseRepo, ICivRepo
    {
        public CivRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<CivModel> GetAll()
        {
            var civList = new List<CivModel>();
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM civs";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var civModel = new CivModel();
                        civModel.CivId = Convert.ToInt32(reader[0]);
                        civModel.Name = reader[1].ToString();
                        civModel.Leader = reader[2].ToString();
                        civModel.Abilities = reader[3].ToString();
                        civList.Add(civModel);
                    }
                }
            }
            return civList;
        }

        public CivModel GetById(int civId)
        {
            var civModel = new CivModel();
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM civs WHERE civ_id = @civ_id";
                command.Parameters.AddWithValue("@civ_id", civId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        civModel.CivId = Convert.ToInt32(reader[0]);
                        civModel.Name = reader[1].ToString();
                        civModel.Leader = reader[2].ToString();
                        civModel.Abilities = reader[3].ToString();
                    }
                }
            }
            return civModel;
        }

        public List<string> GetCitiesByCivId(int civId)
        {
            var cityList = new List<string>();
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT (cities) FROM civs WHERE civ_id = @civ_id";
                command.Parameters.AddWithValue("@civ_id", civId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cityList = JsonSerializer.Deserialize<List<string>>(reader[0].ToString());
                    }
                }
            }
            return cityList;
        }

        public void AddCitiesToGame(int gameId, int civId)
        {
            var cityList = GetCitiesByCivId(civId);
            Debug.WriteLine($"CITY LIST {cityList}");
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO cities (name, civ_id, game_id) VALUES (@name, @civ_id, @game_id)";
                foreach (var city in cityList)
                {
                    Debug.WriteLine($"CITIES, {city} game id {gameId} civ id {civId}");
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", city);
                    command.Parameters.AddWithValue("@civ_id", civId);
                    command.Parameters.AddWithValue("@game_id", gameId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
