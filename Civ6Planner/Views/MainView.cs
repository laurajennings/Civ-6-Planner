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
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            Events();

        }

        private void Events()
        {
            menuStripItemNewGame.Click += delegate
            {
                NewGameClicked?.Invoke(this, EventArgs.Empty);
            };
            menuStripItemLoadGame.Click += delegate
            {
                LoadGameClicked?.Invoke(this, EventArgs.Empty);
            };
            timerMessage.Tick += delegate
            {
                pnlMessage.Visible = false;
                timerMessage.Stop();
            };
        }

        public event EventHandler NewGameClicked;
        public event EventHandler LoadGameClicked;

        public void ShowMessage(string message)
        {
            pnlMessage.Visible = true;
            lblMessage.Text = message;
            timerMessage.Start();
        }
    }
}
