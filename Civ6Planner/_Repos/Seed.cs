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
                                        FOREIGN KEY (game_id) REFERENCES games(game_id))";
                command.ExecuteNonQuery();
            }
        }

    }
}
