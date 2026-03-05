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

        public string CivName { set { lblCivName.Text = value; } }
        public string CivLeader { set { lblCivLeader.Text = value; } }
        public string CivAbilities { set { lblCivAbilities.Text = value; } }
        public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler TaskListChanged;
        public event EventHandler SettleClicked;
        public event EventHandler CityListChanged;

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

        private void LoadCityPanels(object sender, ListChangedEventArgs e)
        {
            pnlCities.SuspendLayout();
            pnlCities.Controls.Clear();
            
            var cities = pnlCities.BindingSource.DataSource as BindingList<CityModel>;
            foreach (var city in cities)
            {
                if (city.Settled == true)
                {
                    var panel = new PnlCity(city);
                    pnlCities.Controls.Add(panel);
                }
            }
            var btnSettle = new BtnSettle();
            pnlCities.Controls.Add(btnSettle);
            btnSettle.Click += delegate
            {
                SettleClicked?.Invoke(this, EventArgs.Empty);
            };
            pnlCities.ResumeLayout();
        }



        //public void SetTasksBindingList(BindingSource taskList)
        //{
            
        //}

        public void SetCitiesBindingList(BindingSource cityList)
        {
            pnlCities.BindingSource = cityList;
            pnlCities.BindingSource.ListChanged += LoadCityPanels;
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
