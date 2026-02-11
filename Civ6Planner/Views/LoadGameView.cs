using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Civ6Planner.Views
{
    public partial class LoadGameView : Form, ILoadGameView
    {
        public LoadGameView()
        {
            InitializeComponent();
        }

        public string SearchName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler SearchEvent;
        public event EventHandler DeleteClicked;
        public event EventHandler CancelClicked;
        public event EventHandler LoadClicked;

        public void SetGameBindingSource(BindingSource gamesList)
        {
            dataGridGames.DataSource = gamesList;
        }
    }
}
