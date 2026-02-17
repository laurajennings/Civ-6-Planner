using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Civ6Planner._Repos
{
    public class Seed : BaseRepo
    {
        private readonly string _connectionString;
        private readonly string csvPathCivs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "civs.csv");
        private readonly string csvPathCities = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cities.csv");

        public Seed(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CheckDbExists()
        {
            var builder = new SQLiteConnectionStringBuilder(_connectionString);
            string dbPath = builder.DataSource;

            if (!File.Exists(dbPath))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = @"CREATE TABLE IF NOT EXISTS civs(
                                        civ_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        name TEXT,
                                        leader TEXT,
                                        abilities TEXT)";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS games(
                                        game_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        name TEXT,
                                        notes TEXT,
                                        civ_id INTEGER,
                                        FOREIGN KEY (civ_id) REFERENCES civs(civ_id))";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS tasks(
                                        task_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        name TEXT,
                                        type TEXT,
                                        boosts TEXT,
                                        status TEXT,
                                        game_id INTEGER,
                                        FOREIGN KEY (game_id) REFERENCES games(game_id) ON DELETE CASCADE)";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS cities(
                                        city_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        name TEXT,
                                        civ_id INTEGER,
                                        FOREIGN KEY (civ_id) REFERENCES civs(civ_id))";
                command.ExecuteNonQuery();
                InsertCivs(connection);
                InsertCities(connection);
            }
        }

        protected virtual void InsertCivs(SQLiteConnection connection)
        {
            var civList = ReadCivsFromCsv();
            using (var transaction  = connection.BeginTransaction())
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO civs (name, leader, abilities) VALUES (@name, @leader, @abilities)";
                foreach (var civ in civList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", civ.Name);
                    command.Parameters.AddWithValue("@leader", civ.Leader);
                    command.Parameters.AddWithValue("@abilities", civ.Abilities);
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
        }

        protected virtual void InsertCities(SQLiteConnection connection)
        {
            var cityList = ReadCitiesFromCsv();
            using (var transaction = connection.BeginTransaction())
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = @"INSERT INTO cities (name, civ_id)
                                        SELECT @name, civ_id FROM civs WHERE name = @civ_name";
                foreach (var city in cityList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", city.Name);
                    command.Parameters.AddWithValue("@civ_name", city.CivName);
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }

        }

        private List<CityModel> ReadCitiesFromCsv()
        {
            if (!File.Exists(csvPathCities))
            {
                throw new FileNotFoundException($"csv not found: {csvPathCities}");
            }
            var cityList = new List<CityModel>();
            var lines = File.ReadAllLines(csvPathCities);
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;
                var values = line.Split(',');
                if (values.Length >= 2)
                {
                    cityList.Add(new CityModel
                    {
                        Name = values[0].Trim(),
                        CivName = values[1].Trim()
                    });
                }
            }
            return cityList;
        }

        private List<CivModel> ReadCivsFromCsv()
        {
            if (!File.Exists(csvPathCivs))
            {
                throw new FileNotFoundException($"csv not found: {csvPathCivs}");
            }
            var civList = new List<CivModel>();
            var lines = File.ReadAllLines(csvPathCivs);
            
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;
                var values = line.Split(',');
                if (values.Length >= 3)
                {
                    civList.Add(new CivModel
                    {
                        Name = values[0].Trim(),
                        Leader = values[1].Trim(),
                        Abilities = values[2].Trim()
                    });
                }
            }
            return civList;
        }
    }
}
