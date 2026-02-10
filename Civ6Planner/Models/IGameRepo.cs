using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Models
{
    public interface IGameRepo
    {
        void Add(GameModel gameModel);
        void Edit(GameModel gameModel);
        void Delete(int gameId);
        IEnumerable<GameModel> GetAll();
    }
}
