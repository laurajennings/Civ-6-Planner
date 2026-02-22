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
        public PnlCity(CityModel city)
        {
            InitializeComponent();
            lblName.Text = city.Name;
        }
    }
}
