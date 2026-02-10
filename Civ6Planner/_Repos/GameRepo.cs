using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Civ6Planner._Repos
{
    public class GameRepo : BaseRepo, IGameRepo
    {
        public GameRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(GameModel gameModel)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO games (name, civ_id) VALUES (@name, @civ_id)";
                command.Parameters.AddWithValue("@name", gameModel.Name);
                command.Parameters.AddWithValue("@civ_id", gameModel.CivId);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int gameId)
        {
            throw new NotImplementedException();
        }

        public void Edit(GameModel gameModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
