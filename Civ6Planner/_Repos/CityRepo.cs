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
    public class CityRepo : BaseRepo, ICityRepo
    {
        public CityRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<CityModel> GetByGameId(int gameId)
        {
            var cityList = new List<CityModel>();
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM cities WHERE game_id = @game_id";
                command.Parameters.AddWithValue("@game_id", gameId);
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var city = new CityModel();
                    city.CityId = Convert.ToInt32(reader[0]);
                    city.Name = reader[1].ToString();
                    city.CivId = Convert.ToInt32(reader[2]);
                    cityList.Add(city);
                }
            }
            return cityList;
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
                command.CommandText = "INSERT INTO cities (name, settled, civ_id, game_id) VALUES (@name, @settled, @civ_id, @game_id)";
                foreach (var city in cityList)
                {
                    Debug.WriteLine($"CITIES, {city} game id {gameId} civ id {civId}");
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", city);
                    command.Parameters.AddWithValue("@settled", false);
                    command.Parameters.AddWithValue("@civ_id", civId);
                    command.Parameters.AddWithValue("@game_id", gameId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
