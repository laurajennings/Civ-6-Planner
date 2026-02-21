using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CsvHelper;
using System.Globalization;

namespace Civ6Planner._Repos
{
    public class Seed : BaseRepo
    {
        private readonly string _connectionString;
        private readonly string csvPathCivs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "civs.csv");

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
                                        abilities TEXT,
                                        cities TEXT)";
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
                                        game_id INTEGER,
                                        FOREIGN KEY (civ_id) REFERENCES civs(civ_id),
                                        FOREIGN KEY (game_id) REFERENCES games(game_id))";
                command.ExecuteNonQuery();
                InsertCivs(connection);
            }
        }

        protected virtual void InsertCivs(SQLiteConnection connection)
        {
            var civList = ReadCivsFromCsv();
            using (var transaction  = connection.BeginTransaction())
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO civs (name, leader, abilities, cities) VALUES (@name, @leader, @abilities, @cities)";
                foreach (var civ in civList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", civ.Name);
                    command.Parameters.AddWithValue("@leader", civ.Leader);
                    command.Parameters.AddWithValue("@abilities", civ.Abilities);
                    command.Parameters.AddWithValue("@cities", civ.Cities);
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
        }

        private List<CivCsvModel> ReadCivsFromCsv()
        {
            if (!File.Exists(csvPathCivs))
            {
                throw new FileNotFoundException($"csv not found: {csvPathCivs}");
            }
            var civList = new List<CivCsvModel>();
            using (var reader = new StreamReader(csvPathCivs))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var importRecords = csv.GetRecords<CivCsvModel>().ToList();
                foreach (var record in importRecords)
                {
                    civList.Add(new CivCsvModel
                    {
                        Name = record.Name,
                        Leader = record.Leader,
                        Abilities = record.Abilities,
                        Cities = record.Cities
                    });
                }
            }
            return civList;
        }
    }
}
