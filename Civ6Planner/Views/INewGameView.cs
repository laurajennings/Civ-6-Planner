using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Views
{
    public interface INewGameView
    {
        string Name { get; set; }
        string CivName { set; }
        string CivLeader { set; }
        string CivAbilities { set; }

        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // Events
        event EventHandler SaveClicked;
        event EventHandler CancelClicked;
        event EventHandler CivSelectionChanged;

        // Methods
        void SetCivBindingSource(BindingSource civList);
        void SetCivColumns();
        void Show();

    }
}
