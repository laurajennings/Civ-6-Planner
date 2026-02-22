using Civ6Planner.Controls;
using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Civ6Planner.Views
{
    public partial class GameView : Form, IGameView
    {
        public GameView()
        {
            InitializeComponent();

        }

        private void ListChangedEvent()
        {
            flowPanelTasks.BindingSource.ListChanged += (s, e) =>
            {
                OnTaskListChanged(flowPanelTasks, flowPanelTasks.BindingSource);
            };
        }

        private void CitiesEvents()
        {
            tlpCities.BindingSource.ListChanged += (s, e) =>
            {
                OnCityListChanged(tlpCities, tlpCities.BindingSource);
            };
        }

        public string CivName { set { lblCivName.Text = value; } }
        public string CivLeader { set { lblCivLeader.Text = value; } }
        public string CivAbilities { set { lblCivAbilities.Text = value; } }
        public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler TaskListChanged;

        private void OnTaskListChanged(FlowLayoutPanel flowPanel, BindingSource bindingSource)
        {
            flowPanel.SuspendLayout();
            flowPanel.Controls.Clear();
            var tasks = bindingSource.DataSource as BindingList<TaskModel>;
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    var card = new TaskCard(task);
                    flowPanel.Controls.Add(card);
                }
            }
            flowPanel.ResumeLayout();
        }

        private void OnCityListChanged(TableLayoutPanel tlpCities, BindingSource bindingSource)
        {
            tlpCities.SuspendLayout();
            tlpCities.Controls.Clear();
            
            var cities = bindingSource.DataSource as BindingList<CityModel>;
            foreach (var city in cities)
            {
                if (city.Settled == true)
                {
                    var panel = new PnlCity(city);
                }
            }
            var settleButton = new BtnSettle();
            tlpCities.Controls.Add(settleButton);
            settleButton.Click += delegate
            {
                OnSettleClicked();
            };
        }

        public void OnSettleClicked()
        {
            var cities = tlpCities.BindingSource.DataSource as BindingList<CityModel>;
            foreach (var city in cities)
            {
                if (!city.Settled)
                {
                    city.Settled = true;
                    Debug.WriteLine($"city settled {city.Name}");
                    break;
                }
            }
            
        }

        public void SetTasksBindingList(BindingSource taskList)
        {
            flowPanelTasks.BindingSource = taskList;
            ListChangedEvent();
        }

        public void SetCitiesBindingList(BindingSource cityList)
        {
            tlpCities.BindingSource = cityList;
            CitiesEvents();
        }

        private static GameView _instance;
        public static GameView GetInstance(Form parentContainer)
        {
            _instance = new GameView();
            _instance.MdiParent = parentContainer;
            _instance.FormBorderStyle = FormBorderStyle.None;
            _instance.Dock = DockStyle.Fill;
            return _instance;
        }
    }
}
