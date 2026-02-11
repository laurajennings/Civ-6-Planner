namespace Civ6Planner.Views
{
    partial class MainView
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            menuStripItemNewGame = new ToolStripMenuItem();
            menuStripItemLoadGame = new ToolStripMenuItem();
            pnlMessage = new Panel();
            lblMessage = new Label();
            timerMessage = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            pnlMessage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuStripItemNewGame, menuStripItemLoadGame });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuStripItemNewGame
            // 
            menuStripItemNewGame.Name = "menuStripItemNewGame";
            menuStripItemNewGame.Size = new Size(77, 20);
            menuStripItemNewGame.Text = "New Game";
            // 
            // menuStripItemLoadGame
            // 
            menuStripItemLoadGame.Name = "menuStripItemLoadGame";
            menuStripItemLoadGame.Size = new Size(79, 20);
            menuStripItemLoadGame.Text = "Load Game";
            // 
            // pnlMessage
            // 
            pnlMessage.BackColor = SystemColors.ControlDark;
            pnlMessage.Controls.Add(lblMessage);
            pnlMessage.Location = new Point(588, 383);
            pnlMessage.Name = "pnlMessage";
            pnlMessage.Size = new Size(200, 55);
            pnlMessage.TabIndex = 2;
            pnlMessage.Visible = false;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 9F);
            lblMessage.Location = new Point(18, 22);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(38, 15);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            // 
            // timerMessage
            // 
            timerMessage.Enabled = true;
            timerMessage.Interval = 4000;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlMessage);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainView";
            Text = "MainView";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlMessage.ResumeLayout(false);
            pnlMessage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuStripItemNewGame;
        private ToolStripMenuItem menuStripItemLoadGame;
        private Panel pnlMessage;
        private Label lblMessage;
        private System.Windows.Forms.Timer timerMessage;
    }
}