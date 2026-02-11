using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Presenters
{
    public class LoadGamePresenter
    {
        private ILoadGameView _view;
        private IGameRepo _repo;
        private readonly Action<GameModel> _onGameLoaded;
        private readonly Action<string> _onShowMessage;
        private BindingSource _gamesBindingSource;
        private IEnumerable<GameModel> _gameList;

        public LoadGamePresenter(ILoadGameView view, IGameRepo repo, Action<GameModel> onGameLoaded, Action<string> onShowMessage)
        {
            _view = view;
            _repo = repo;
            _onGameLoaded = onGameLoaded;
            _onShowMessage = onShowMessage;
            _gamesBindingSource = new BindingSource();

            _view.SearchEvent += OnSearchEvent;
            _view.DeleteClicked += OnDeleteClicked;
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
            try
            {
                var selectedGame = (GameModel)_gamesBindingSource.Current;
                _repo.Delete(selectedGame.GameId);
                _view.IsSuccessful = true;
                _view.Message = "Game deleted";
                GetAllGames();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
            _onShowMessage?.Invoke(_view.Message);
        }

        private void OnLoadClicked(object? sender, EventArgs e)
        {
            var selectedGame = (GameModel)_gamesBindingSource.Current;
            _onGameLoaded?.Invoke(selectedGame);
        }

        private void GetAllGames()
        {
            _gameList = _repo.GetAll();
            _gamesBindingSource.DataSource = _gameList;
        }
    }
}
