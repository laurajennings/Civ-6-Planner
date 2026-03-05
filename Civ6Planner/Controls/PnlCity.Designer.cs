namespace Civ6Planner.Controls
{
    partial class PnlCity
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            flowPanelTasks = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Location = new Point(63, 32);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            lblName.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowPanelTasks
            // 
            flowPanelTasks.AllowDrop = true;
            flowPanelTasks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowPanelTasks.AutoScroll = true;
            flowPanelTasks.Location = new Point(11, 60);
            flowPanelTasks.Name = "flowPanelTasks";
            flowPanelTasks.Padding = new Padding(5);
            flowPanelTasks.Size = new Size(200, 169);
            flowPanelTasks.TabIndex = 1;
            flowPanelTasks.WrapContents = false;
            // 
            // PnlCity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowPanelTasks);
            Controls.Add(lblName);
            Name = "PnlCity";
            Size = new Size(214, 229);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private FlowLayoutPanel flowPanelTasks;
    }
}
