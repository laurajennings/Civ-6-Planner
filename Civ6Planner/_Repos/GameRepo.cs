using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner._Repos
{
    public class GameRepo : BaseRepo, IGameRepo
    {
        public void Add(GameModel gameModel)
        {
            throw new NotImplementedException();
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
