namespace Civ6Planner.Views
{
    partial class NewGameView
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
            dataGridCivs = new DataGridView();
            gbxSelectedCiv = new GroupBox();
            lblCivLeader = new Label();
            lblCivName = new Label();
            lblCivAbilities = new Label();
            tbxName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridCivs).BeginInit();
            gbxSelectedCiv.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridCivs
            // 
            dataGridCivs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCivs.Dock = DockStyle.Left;
            dataGridCivs.Location = new Point(0, 0);
            dataGridCivs.Name = "dataGridCivs";
            dataGridCivs.Size = new Size(240, 450);
            dataGridCivs.TabIndex = 0;
            // 
            // gbxSelectedCiv
            // 
            gbxSelectedCiv.Controls.Add(lblCivAbilities);
            gbxSelectedCiv.Controls.Add(lblCivName);
            gbxSelectedCiv.Controls.Add(lblCivLeader);
            gbxSelectedCiv.Location = new Point(255, 26);
            gbxSelectedCiv.Name = "gbxSelectedCiv";
            gbxSelectedCiv.Size = new Size(200, 139);
            gbxSelectedCiv.TabIndex = 1;
            gbxSelectedCiv.TabStop = false;
            gbxSelectedCiv.Text = "Selected Civ";
            // 
            // lblCivLeader
            // 
            lblCivLeader.AutoSize = true;
            lblCivLeader.Location = new Point(15, 62);
            lblCivLeader.Name = "lblCivLeader";
            lblCivLeader.Size = new Size(38, 15);
            lblCivLeader.TabIndex = 0;
            lblCivLeader.Text = "label1";
            // 
            // lblCivName
            // 
            lblCivName.AutoSize = true;
            lblCivName.Location = new Point(15, 32);
            lblCivName.Name = "lblCivName";
            lblCivName.Size = new Size(38, 15);
            lblCivName.TabIndex = 1;
            lblCivName.Text = "label2";
            // 
            // lblCivAbilities
            // 
            lblCivAbilities.AutoSize = true;
            lblCivAbilities.Location = new Point(15, 92);
            lblCivAbilities.Name = "lblCivAbilities";
            lblCivAbilities.Size = new Size(38, 15);
            lblCivAbilities.TabIndex = 2;
            lblCivAbilities.Text = "label3";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(497, 318);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(156, 23);
            tbxName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(497, 357);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(578, 357);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewGameVeiw
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(tbxName);
            Controls.Add(gbxSelectedCiv);
            Controls.Add(dataGridCivs);
            Name = "NewGameVeiw";
            Text = "NewGameVeiw";
            ((System.ComponentModel.ISupportInitialize)dataGridCivs).EndInit();
            gbxSelectedCiv.ResumeLayout(false);
            gbxSelectedCiv.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridCivs;
        private GroupBox gbxSelectedCiv;
        private Label lblCivAbilities;
        private Label lblCivName;
        private Label lblCivLeader;
        private TextBox tbxName;
        private Button btnSave;
        private Button btnCancel;
    }
}