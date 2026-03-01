using Civ6Planner.Controls;
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

namespace Civ6Planner.Controls
{
    public partial class PnlCity : UserControl
    {
        private CityModel _city;
        public CityModel City
        {
            get { return _city; }
            set { _city = value; }
        }
        public BindingSource TasksBindingSource { get; set; }
        //public event EventHadler<TaskMovedEventArgs> TaskMoved;
        public PnlCity(CityModel city)
        {
            InitializeComponent();
            _city = city;
            lblName.Text = _city.Name;

            //flowPanelTasks.DragEnter += OnPanelDragEnter;
            //flowPanelTasks.DragOver += OnPanelDragOver;
            //flowPanelTasks.DragDrop += OnPanelDragDrop;
            //flowPanelTasks.DragLeave += OnPanelDragLeave;

            TasksBindingSource = new BindingSource { DataSource = new BindingList<TaskModel>() };
            TasksBindingSource.ListChanged += (s, e) => RefreshTasks();
        }

        private void RefreshTasks()
        {
            flowPanelTasks.SuspendLayout();
            flowPanelTasks.Controls.Clear();
            var tasks = TasksBindingSource.DataSource as BindingList<TaskModel>;
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    var taskPanel = CreateTaskPanel(task);
                    flowPanelTasks.Controls.Add(taskPanel);
                }
            }
            flowPanelTasks.ResumeLayout();
        }

        private TaskCard CreateTaskPanel(TaskModel task)
        {
            var panel = new TaskCard(task);
            panel.Tag = task;
            panel.MouseEnter += (s, e) => panel.BackColor = Color.FromArgb(220, 220, 220);
            panel.MouseLeave += (s, e) => panel.BackColor = Color.White;
            panel.MouseDown += OnTaskMouseDown;
            // task label mouse down
            return panel;
        }

        private void OnTaskMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel taskPanel = sender as Panel;
                if (taskPanel == null && sender is Control control)
                {
                    taskPanel = control.Parent as Panel;
                }
                if (taskPanel != null && taskPanel.Tag is TaskModel task)
                {
                    var dragData = new DragData
                    {
                        Panel = taskPanel,
                        Task = task,
                        SourceColumn = this
                    };
                    taskPanel.DoDragDrop(dragData, DragDropEffects.Move);
                }
            }
        }

        private class DragData
        {
            public Panel Panel { get; set; }
            public TaskModel Task { get; set; }
            public PnlCity SourceColumn { get; set; }
        }
    }
}