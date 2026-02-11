using Civ6Planner._Repos;
using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Presenters
{
    public class MainPresenter
    {
        private IMainView _mainView;
        private readonly string _sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            _mainView = mainView;
            _sqlConnectionString = sqlConnectionString;
            _mainView.NewGameClicked += OnNewGameClicked;
            _mainView.LoadGameClicked += OnLoadGameClicked;
        }

        private void OnNewGameClicked(object sender, EventArgs e)
        {
            INewGameView view = NewGameView.GetInstance((MainView)_mainView);
            IGameRepo repo = new GameRepo(_sqlConnectionString);
            ICivRepo civRepo = new CivRepo(_sqlConnectionString);
            new NewGamePresenter(view, repo, civRepo, OpenGame, ShowMessage);
        }

        private void OnLoadGameClicked(object sender, EventArgs e)
        {
            ILoadGameView view = LoadGameView.GetInstance((MainView)_mainView);
            IGameRepo repo = new GameRepo(_sqlConnectionString);
            new LoadGamePresenter(view, repo, OpenGame, ShowMessage);
        }

        private void OpenGame(GameModel game)
        {
            IGameView view = GameView.GetInstance((MainView)_mainView);
            IGameRepo repo = new GameRepo(_sqlConnectionString);
            new GamePresenter(view, repo, game);
        }

        private void ShowMessage(string message) 
        {
            _mainView.ShowMessage(message);
        }

    }
}
