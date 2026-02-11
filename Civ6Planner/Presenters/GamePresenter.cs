using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Presenters
{
    public class GamePresenter
    {
        private IGameView _view;
        private IGameRepo _repo;
        private GameModel _gameModel;

        public GamePresenter(IGameView view, IGameRepo repo, GameModel gameModel)
        {
            _view = view;
            _repo = repo;
            _gameModel = gameModel;

            _view.Show();
        }
    }
}
