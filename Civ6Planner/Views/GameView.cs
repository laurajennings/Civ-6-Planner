using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Civ6Planner.Views
{
    public partial class GameView : Form, IGameView
    {
        //private BindingList<TaskModel> _tasksBindingList;
        public GameView()
        {
            InitializeComponent();
        }

        public string CivName { set { lblCivName.Text = value; } }
        public string CivLeader { set { lblCivLeader.Text = value; } }
        public string CivAbilities { set { lblCivAbilities.Text = value; } }
        public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public void SetBindingListData(BindingSource taskList)
        //{
        //    _tasksBindingList.DataSource = taskList;
        //}

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
