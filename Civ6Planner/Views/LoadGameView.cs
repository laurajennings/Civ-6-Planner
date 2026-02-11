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
        private string _message;
        private bool _isSuccessful;
        public LoadGameView()
        {
            InitializeComponent();
            Events();
        }

        private void Events()
        {
            btnLoad.Click += delegate
            {
                LoadClicked?.Invoke(this, EventArgs.Empty);
            };
            btnCancel.Click += delegate
            {
                this.Close();
            };
            btnDelete.Click += delegate
            {
                DeleteClicked?.Invoke(this, EventArgs.Empty);
            };
        }

        public string SearchName
        {
            get { return tbxSearch.Text; }
            set { tbxSearch.Text = value; }
        }
        public bool IsSuccessful
        {
            get { return _isSuccessful; }
            set { _isSuccessful = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler DeleteClicked;
        public event EventHandler CancelClicked;
        public event EventHandler LoadClicked;

        public void SetGameBindingSource(BindingSource gamesList)
        {
            dataGridGames.DataSource = gamesList;
        }

        private static LoadGameView _instance;
        public static LoadGameView GetInstance(Form parentContainer)
        {
            _instance = new LoadGameView();
            _instance.MdiParent = parentContainer;
            _instance.FormBorderStyle = FormBorderStyle.None;
            _instance.Dock = DockStyle.Fill;
            return _instance;
        }
    }
}
