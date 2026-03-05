using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Controls
{
    public class PnlMainTasks : FlowLayoutPanel
    {
        public BindingSource BindingSource { get; set; }

        public PnlMainTasks()
        {
            BindingSource = new BindingSource { DataSource = new BindingList<TaskModel>() };
            BindingSource.ListChanged += (s, e) => RefreshTasks();
        }

        private void RefreshTasks()
        {
            SuspendLayout();
            Controls.Clear();
            var tasks = BindingSource.DataSource as BindingList<TaskModel>;
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    var taskPanel = new TaskCard(task);
                    Controls.Add(taskPanel);
                }
            }
            ResumeLayout();
        }
    }
}
