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
    public partial class NewGameVeiw : Form, INewGameView
    {
        private string _message;
        private bool _isSuccessful;

        public NewGameVeiw()
        {
            InitializeComponent();
            Events();
        }

        private void Events()
        {
            dataGridCivs.SelectionChanged += delegate
            {
                CivSelectionChanged?.Invoke(this, EventArgs.Empty);
            };
            btnSave.Click += delegate
            {
                SaveClicked?.Invoke(this, EventArgs.Empty);
            };
            btnCancel.Click += delegate
            {
                CancelClicked?.Invoke(this, EventArgs.Empty);
            };
        }

        public string CivName
        {
            set { lblCivName.Text = value; }
        }
        public string CivLeader
        {
            set { lblCivLeader.Text = value; }
        }
        public string CivAbilities
        {
            set { lblCivAbilities.Text = value; }
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

        public event EventHandler SaveClicked;
        public event EventHandler CancelClicked;
        public event EventHandler CivSelectionChanged;

        public void SetCivBindingSource(BindingSource civList)
        {
            dataGridCivs.DataSource = civList;
        }

        public void SetCivColumns()
        {
            throw new NotImplementedException();
        }


    }
}
