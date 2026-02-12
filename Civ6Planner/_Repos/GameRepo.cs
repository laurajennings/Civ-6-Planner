using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

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
            Debug.WriteLine($"add game: {gameModel.GameId}");
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
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM games WHERE game_id = @game_id";
                command.Parameters.AddWithValue("@game_id", gameId);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(GameModel gameModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameModel> GetAll()
        {
            var gameList = new List<GameModel>();
            using (var connection = new SQLiteConnection(_connectionString))
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM games";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var gameModel = new GameModel();
                        gameModel.GameId = Convert.ToInt32(reader[0]);
                        gameModel.Name = reader[1].ToString();
                        gameModel.CivId = Convert.ToInt32(reader[2]);
                        gameList.Add(gameModel);
                    }
                }
            }
            return gameList;
        }
    }
}
