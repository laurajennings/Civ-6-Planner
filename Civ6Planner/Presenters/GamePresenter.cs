using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private ITaskRepo _taskRepo;
        private GameModel _game;

        private BindingSource _tasksBindingSource;

        public GamePresenter(IGameView view, IGameRepo repo, ICivRepo civRepo, ITaskRepo taskRepo, GameModel game)
        {
            _view = view;
            _repo = repo;
            _civRepo = civRepo;
            _taskRepo = taskRepo;
            _game = game;

            var civ = _civRepo.GetById(game.CivId);
            _view.CivName = civ.Name;
            _view.CivLeader = civ.Leader;
            _view.CivAbilities = civ.Abilities;

            _tasksBindingSource = new BindingSource { DataSource = new BindingList<TaskModel>() };
            _view.SetBindingListData(_tasksBindingSource);
            GetAllTasks();

            _view.Show();
        }

        private void GetAllTasks()
        {
            var tasks = _taskRepo.GetByGameId(_game.GameId);

            var taskList = _tasksBindingSource.DataSource as BindingList<TaskModel>;
            taskList.Clear();
            foreach (var task in tasks)
            {
                taskList.Add(task);
            }
        }
    }
}
