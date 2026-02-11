using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Views
{
    public interface IGameView
    {
        string CivName { get; set; }
        string CivLeader {  get; set; }
        string CivAbilities { get; set; }
        string Notes { get; set; }

        void Show();
    }
}
