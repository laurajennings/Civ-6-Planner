using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

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
                Debug.WriteLine("db doesn't exist");
            }
        }
    }
}
