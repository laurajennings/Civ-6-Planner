using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Views
{
    public interface IGameView
    {
        string CivName { set; }
        string CivLeader { set; }
        string CivAbilities { set; }
        string Notes { get; set; }

        event EventHandler TaskListChanged;

        void SetTasksBindingList(BindingSource taskList);
        void SetCitiesBindingList(BindingSource cityList);
        void Show();
    }
}
