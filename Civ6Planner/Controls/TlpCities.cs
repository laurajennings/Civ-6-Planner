using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ6Planner.Controls
{
    public class TlpCities : TableLayoutPanel
    {
        private BindingSource _bindingSource;

        public TlpCities()
        {

        }
        public BindingSource BindingSource { get; set; }
    }
}
