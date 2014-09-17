namespace SavannahGame.Forms
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.savannahPictureBox = new System.Windows.Forms.PictureBox();
            this.stepsTrackBar = new System.Windows.Forms.TrackBar();
            this.delayTrackBar = new System.Windows.Forms.TrackBar();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.delayLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.savannahPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // savannahPictureBox
            // 
            this.savannahPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.savannahPictureBox.Location = new System.Drawing.Point(12, 12);
            this.savannahPictureBox.Name = "savannahPictureBox";
            this.savannahPictureBox.Size = new System.Drawing.Size(728, 705);
            this.savannahPictureBox.TabIndex = 0;
            this.savannahPictureBox.TabStop = false;
            this.savannahPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.savannahPictureBox_Paint);
            // 
            // stepsTrackBar
            // 
            this.stepsTrackBar.Location = new System.Drawing.Point(12, 723);
            this.stepsTrackBar.Maximum = 20;
            this.stepsTrackBar.Minimum = 1;
            this.stepsTrackBar.Name = "stepsTrackBar";
            this.stepsTrackBar.Size = new System.Drawing.Size(256, 45);
            this.stepsTrackBar.TabIndex = 1;
            this.stepsTrackBar.Value = 1;
            this.stepsTrackBar.ValueChanged += new System.EventHandler(this.stepsTrackBar_ValueChanged);
            // 
            // delayTrackBar
            // 
            this.delayTrackBar.LargeChange = 100;
            this.delayTrackBar.Location = new System.Drawing.Point(389, 723);
            this.delayTrackBar.Maximum = 2000;
            this.delayTrackBar.Minimum = 50;
            this.delayTrackBar.Name = "delayTrackBar";
            this.delayTrackBar.Size = new System.Drawing.Size(256, 45);
            this.delayTrackBar.SmallChange = 50;
            this.delayTrackBar.TabIndex = 2;
            this.delayTrackBar.TickFrequency = 100;
            this.delayTrackBar.Value = 100;
            this.delayTrackBar.ValueChanged += new System.EventHandler(this.delayTrackBar_ValueChanged);
            // 
            // stepsLabel
            // 
            this.stepsLabel.AutoSize = true;
            this.stepsLabel.Location = new System.Drawing.Point(274, 723);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(13, 26);
            this.stepsLabel.TabIndex = 3;
            this.stepsLabel.Text = "\r\n0";
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(651, 723);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(25, 26);
            this.delayLabel.TabIndex = 4;
            this.delayLabel.Text = "\r\n100";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 761);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.stepsLabel);
            this.Controls.Add(this.delayTrackBar);
            this.Controls.Add(this.stepsTrackBar);
            this.Controls.Add(this.savannahPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.Text = "Savannah Game";
            ((System.ComponentModel.ISupportInitialize)(this.savannahPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox savannahPictureBox;
        private System.Windows.Forms.TrackBar stepsTrackBar;
        private System.Windows.Forms.TrackBar delayTrackBar;
        private System.Windows.Forms.Label stepsLabel;
        private System.Windows.Forms.Label delayLabel;
    }
}

