using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Presenters
{
    public class NewGamePresenter
    {
        private INewGameView _view;
        private IGameRepo _repo;
        private ICivRepo _civRepo;
        private readonly Action<GameModel> _onGameLoaded;
        private IEnumerable<CivModel> civList;
        private BindingSource _civsBindingSource;

        public NewGamePresenter(INewGameView view, IGameRepo repo, ICivRepo civRepo, Action<GameModel> onGameLoaded)
        {
            _view = view;
            _repo = repo;
            _civRepo = civRepo;
            _onGameLoaded = onGameLoaded;

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
            throw new NotImplementedException();
        }

        private void OnCancelClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
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
    }
}
