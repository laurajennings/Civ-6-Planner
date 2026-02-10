using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }
    }
}
