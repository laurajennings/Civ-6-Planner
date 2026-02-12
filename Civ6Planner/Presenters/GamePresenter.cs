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
        private ICivRepo _civRepo;
        private GameModel _game;

        public GamePresenter(IGameView view, IGameRepo repo, ICivRepo civRepo, GameModel game)
        {
            _view = view;
            _repo = repo;
            _civRepo = civRepo;
            _game = game;

            var civ = _civRepo.GetById(game.CivId);
            _view.CivName = civ.Name;
            _view.CivLeader = civ.Leader;
            _view.CivAbilities = civ.Abilities;

            _view.Show();
        }
    }
}
