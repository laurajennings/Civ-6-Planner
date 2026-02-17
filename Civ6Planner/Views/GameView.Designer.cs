namespace Civ6Planner.Views
{
    partial class GameView
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
            groupBox1 = new GroupBox();
            lblCivLeader = new Label();
            lblCivAbilities = new Label();
            lblCivName = new Label();
            groupBox2 = new GroupBox();
            flowPanelTasks = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowPanelTasks);
            groupBox1.Controls.Add(lblCivLeader);
            groupBox1.Controls.Add(lblCivAbilities);
            groupBox1.Controls.Add(lblCivName);
            groupBox1.Location = new Point(2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 226);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Civ Info";
            // 
            // lblCivLeader
            // 
            lblCivLeader.AutoSize = true;
            lblCivLeader.Location = new Point(10, 65);
            lblCivLeader.Name = "lblCivLeader";
            lblCivLeader.Size = new Size(38, 15);
            lblCivLeader.TabIndex = 2;
            lblCivLeader.Text = "label3";
            // 
            // lblCivAbilities
            // 
            lblCivAbilities.AutoSize = true;
            lblCivAbilities.Location = new Point(10, 101);
            lblCivAbilities.Name = "lblCivAbilities";
            lblCivAbilities.Size = new Size(38, 15);
            lblCivAbilities.TabIndex = 1;
            lblCivAbilities.Text = "label2";
            // 
            // lblCivName
            // 
            lblCivName.AutoSize = true;
            lblCivName.Location = new Point(10, 33);
            lblCivName.Name = "lblCivName";
            lblCivName.Size = new Size(38, 15);
            lblCivName.TabIndex = 0;
            lblCivName.Text = "label1";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(2, 225);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 227);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Notes";
            // 
            // flowPanelTasks
            // 
            flowPanelTasks.Location = new Point(195, 0);
            flowPanelTasks.Name = "flowPanelTasks";
            flowPanelTasks.Size = new Size(200, 451);
            flowPanelTasks.TabIndex = 2;
            // 
            // GameView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "GameView";
            Text = "GameView";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblCivLeader;
        private Label lblCivAbilities;
        private Label lblCivName;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowPanelTasks;
    }
}