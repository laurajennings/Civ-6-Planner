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

        }

        private void OnLoadGameClicked(object sender, EventArgs e)
        {

        }

        private void OpenGame(GameModel game)
        {

        }
    }
}
