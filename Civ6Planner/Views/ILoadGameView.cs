using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Views
{
    public interface ILoadGameView
    {
        string SearchName { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler DeleteClicked;
        event EventHandler CancelClicked;
        event EventHandler LoadClicked;

        void SetGameBindingSource(BindingSource gamesList);
        void Show();
    }
}
