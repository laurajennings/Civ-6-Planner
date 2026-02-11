using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Views
{
    public interface IMainView
    {
        event EventHandler NewGameClicked;
        event EventHandler LoadGameClicked;

        void ShowMessage(string message);
    }
}
