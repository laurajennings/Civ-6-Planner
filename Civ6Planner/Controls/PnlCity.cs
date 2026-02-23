using Civ6Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Controls
{
    public class PnlCity : Panel
    {
        public PnlCity(CityModel city)
        {
            Controls.Add(new Label() { Text = city.Name });
        }
    }
}
