namespace Civ6Planner.Views
{
    partial class LoadGameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridGames = new DataGridView();
            lblSearch = new Label();
            tbxSearch = new TextBox();
            btnLoad = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridGames).BeginInit();
            SuspendLayout();
            // 
            // dataGridGames
            // 
            dataGridGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridGames.Location = new Point(24, 115);
            dataGridGames.Name = "dataGridGames";
            dataGridGames.Size = new Size(630, 311);
            dataGridGames.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(24, 43);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(114, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search Game Name:";
            // 
            // tbxSearch
            // 
            tbxSearch.Location = new Point(24, 70);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(340, 23);
            tbxSearch.TabIndex = 2;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(672, 115);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(672, 144);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(672, 173);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // LoadGameView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
            Controls.Add(btnLoad);
            Controls.Add(tbxSearch);
            Controls.Add(lblSearch);
            Controls.Add(dataGridGames);
            Name = "LoadGameView";
            Text = "LoadGameView";
            ((System.ComponentModel.ISupportInitialize)dataGridGames).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridGames;
        private Label lblSearch;
        private TextBox tbxSearch;
        private Button btnLoad;
        private Button btnCancel;
        private Button btnDelete;
    }
}