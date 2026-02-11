using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Presenters
{
    public class LoadGamePresenter
    {
        private ILoadGameView _view;
        private IGameRepo _repo;
        private BindingSource _gamesBindingSource;
        private IEnumerable<GameModel> _gameList;

        public LoadGamePresenter(ILoadGameView view, IGameRepo repo)
        {
            _view = view;
            _repo = repo;
            _gamesBindingSource = new BindingSource();

            _view.SearchEvent += OnSearchEvent;
            _view.DeleteClicked += OnDeleteClicked;
            _view.CancelClicked += OnCancelClicked;
            _view.LoadClicked += OnLoadClicked;

            _view.SetGameBindingSource(_gamesBindingSource);
            GetAllGames();

            _view.Show();
        }

        private void OnSearchEvent(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDeleteClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCancelClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnLoadClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GetAllGames()
        {
            _gameList = _repo.GetAll();
            _gamesBindingSource.DataSource = _gameList;
        }
    }
}
