namespace SavannahGame.Forms
{
    partial class GameForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.delayTrackBar = new System.Windows.Forms.TrackBar();
            this.delayLabel = new System.Windows.Forms.Label();
            this.slidersPanel = new System.Windows.Forms.Panel();
            this.savannahPictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rabbitsLabel = new System.Windows.Forms.Label();
            this.lionsLabel = new System.Windows.Forms.Label();
            this.rabbitsTextBox = new System.Windows.Forms.TextBox();
            this.lionsTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delayTrackBar)).BeginInit();
            this.slidersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.savannahPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // delayTrackBar
            // 
            this.delayTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayTrackBar.LargeChange = 50;
            this.delayTrackBar.Location = new System.Drawing.Point(12, 20);
            this.delayTrackBar.Maximum = 1000;
            this.delayTrackBar.Minimum = 10;
            this.delayTrackBar.Name = "delayTrackBar";
            this.delayTrackBar.Size = new System.Drawing.Size(540, 45);
            this.delayTrackBar.SmallChange = 10;
            this.delayTrackBar.TabIndex = 2;
            this.delayTrackBar.TickFrequency = 10;
            this.delayTrackBar.Value = 100;
            this.delayTrackBar.ValueChanged += new System.EventHandler(this.delayTrackBar_ValueChanged);
            // 
            // delayLabel
            // 
            this.delayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayLabel.Location = new System.Drawing.Point(560, 20);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(50, 26);
            this.delayLabel.TabIndex = 4;
            this.delayLabel.Text = "\r\n100";
            // 
            // slidersPanel
            // 
            this.slidersPanel.Controls.Add(this.delayTrackBar);
            this.slidersPanel.Controls.Add(this.delayLabel);
            this.slidersPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.slidersPanel.Location = new System.Drawing.Point(0, 684);
            this.slidersPanel.Name = "slidersPanel";
            this.slidersPanel.Size = new System.Drawing.Size(752, 77);
            this.slidersPanel.TabIndex = 6;
            // 
            // savannahPictureBox
            // 
            this.savannahPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savannahPictureBox.Location = new System.Drawing.Point(0, 0);
            this.savannahPictureBox.Name = "savannahPictureBox";
            this.savannahPictureBox.Size = new System.Drawing.Size(556, 684);
            this.savannahPictureBox.TabIndex = 8;
            this.savannahPictureBox.TabStop = false;
            this.savannahPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.savannahPictureBox_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.savannahPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(752, 684);
            this.splitContainer1.SplitterDistance = 556;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.rabbitsLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lionsLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rabbitsTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lionsTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 684);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // rabbitsLabel
            // 
            this.rabbitsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rabbitsLabel.AutoSize = true;
            this.rabbitsLabel.Location = new System.Drawing.Point(3, 0);
            this.rabbitsLabel.Name = "rabbitsLabel";
            this.rabbitsLabel.Size = new System.Drawing.Size(43, 26);
            this.rabbitsLabel.TabIndex = 0;
            this.rabbitsLabel.Text = "Rabbits";
            this.rabbitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lionsLabel
            // 
            this.lionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lionsLabel.AutoSize = true;
            this.lionsLabel.Location = new System.Drawing.Point(3, 26);
            this.lionsLabel.Name = "lionsLabel";
            this.lionsLabel.Size = new System.Drawing.Size(32, 26);
            this.lionsLabel.TabIndex = 1;
            this.lionsLabel.Text = "Lions";
            this.lionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rabbitsTextBox
            // 
            this.rabbitsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rabbitsTextBox.Location = new System.Drawing.Point(52, 3);
            this.rabbitsTextBox.Name = "rabbitsTextBox";
            this.rabbitsTextBox.ReadOnly = true;
            this.rabbitsTextBox.Size = new System.Drawing.Size(145, 20);
            this.rabbitsTextBox.TabIndex = 2;
            // 
            // lionsTextBox
            // 
            this.lionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lionsTextBox.Location = new System.Drawing.Point(52, 29);
            this.lionsTextBox.Name = "lionsTextBox";
            this.lionsTextBox.ReadOnly = true;
            this.lionsTextBox.Size = new System.Drawing.Size(145, 20);
            this.lionsTextBox.TabIndex = 3;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(52, 55);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(145, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 761);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.slidersPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.Text = "Savannah Game";
            ((System.ComponentModel.ISupportInitialize)(this.delayTrackBar)).EndInit();
            this.slidersPanel.ResumeLayout(false);
            this.slidersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.savannahPictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar delayTrackBar;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Panel slidersPanel;
        private System.Windows.Forms.PictureBox savannahPictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label rabbitsLabel;
        private System.Windows.Forms.Label lionsLabel;
        private System.Windows.Forms.TextBox rabbitsTextBox;
        private System.Windows.Forms.TextBox lionsTextBox;
        private System.Windows.Forms.Button startButton;
    }
}

