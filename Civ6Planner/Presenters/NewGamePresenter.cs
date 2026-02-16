using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Civ6Planner.Presenters
{
    public class NewGamePresenter
    {
        private INewGameView _view;
        private IGameRepo _repo;
        private ICivRepo _civRepo;
        private ITaskRepo _taskRepo;
        private readonly Action<GameModel> _onGameLoaded;
        private readonly Action<string> _onShowMessage;
        private IEnumerable<CivModel> civList;
        private BindingSource _civsBindingSource;

        public NewGamePresenter(INewGameView view, IGameRepo repo, ICivRepo civRepo, ITaskRepo taskRepo, Action<GameModel> onGameLoaded, Action<string> onShowMessage)
        {
            _view = view;
            _repo = repo;
            _civRepo = civRepo;
            _taskRepo = taskRepo;
            _onGameLoaded = onGameLoaded;
            _onShowMessage = onShowMessage;

            _view.SaveClicked += OnSaveClicked;
            _view.CancelClicked += OnCancelClicked;
            _view.CivSelectionChanged += OnCivSelectionChanged;

            _civsBindingSource = new BindingSource();
            _view.SetCivBindingSource(_civsBindingSource);
            GetCivList();
            _view.SetCivColumns();

            _view.Show();
        }

        private void OnSaveClicked(object? sender, EventArgs e)
        {
            var gameModel = new GameModel();
            gameModel.Name = _view.Name;
            var selectedCiv = (CivModel)_civsBindingSource.Current;
            gameModel.CivId = selectedCiv.CivId;
            try
            {
                int gameId = _repo.Add(gameModel);
                _taskRepo.AddDefaultTasksToGame(gameId);
                _view.Message = "Game added successfully";
                _onGameLoaded?.Invoke(gameModel);
                ClearFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
            _onShowMessage?.Invoke(_view.Message);
        }

        private void OnCancelClicked(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void OnCivSelectionChanged(object? sender, EventArgs e)
        {
            var selectedCiv = (CivModel)_civsBindingSource.Current;
            _view.CivName = selectedCiv.Name;
            _view.CivLeader = selectedCiv.Leader;
            _view.CivAbilities = selectedCiv.Abilities;
            _view.Name = selectedCiv.Leader;
        }

        private void GetCivList()
        {
            civList = _civRepo.GetAll();
            _civsBindingSource.DataSource = civList;
        }

        private void ClearFields()
        {
            _view.Name = "";
            _view.CivName = "";
            _view.CivLeader = "";
            _view.CivAbilities = "";
        }
    }
}
