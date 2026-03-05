using Civ6Planner.Models;
using Civ6Planner.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Civ6Planner.Presenters
{
    public class GamePresenter
    {
        private IGameView _view;
        private IGameRepo _repo;
        private ICivRepo _civRepo;
        private ITaskRepo _taskRepo;
        private ICityRepo _cityRepo;
        private GameModel _game;

        private BindingSource _citiesBindingSource;
        private BindingSource _tasksBindingSource;

        public GamePresenter(IGameView view, IGameRepo repo, ICivRepo civRepo, ITaskRepo taskRepo, ICityRepo cityRepo, GameModel game)
        {
            _view = view;
            _repo = repo;
            _civRepo = civRepo;
            _taskRepo = taskRepo;
            _cityRepo = cityRepo;
            _game = game;

            _view.SettleClicked += OnSettleClicked;

            var civ = _civRepo.GetById(game.CivId);
            _view.CivName = civ.Name;
            _view.CivLeader = civ.Leader;
            _view.CivAbilities = civ.Abilities;

            _citiesBindingSource = new BindingSource { DataSource = new BindingList<CityModel>() };
            _view.SetCitiesBindingList(_citiesBindingSource);
            GetCities();

            _tasksBindingSource = new BindingSource { DataSource = new BindingList<TaskModel>() };
            //_view.SetTasksBindingList(_tasksBindingSource);
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

        private void GetCities()
        {
            var cities = _cityRepo.GetByGameId(_game.GameId);
            var cityList = _citiesBindingSource.DataSource as BindingList<CityModel>;
            cityList.Clear();
            foreach (var city in cities)
            {
                Debug.WriteLine($"GET CITIES CITY {city.Name} {cityList.Count}");
                cityList.Add(city);
            }
            Debug.WriteLine($"GET CITIES {cityList.Count}");
        }

        private void OnSettleClicked(object sender, EventArgs e)
        {
            var cities = _citiesBindingSource.DataSource as BindingList<CityModel>;
            foreach (var city in cities)
            {
                if (!city.Settled)
                {
                    Debug.WriteLine($"settle clicked {city.Name}");
                    city.Settled = true;
                    _cityRepo.Edit(city);
                    GetCities();
                    break;
                }
            }
        }
    }
}
