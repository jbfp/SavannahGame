﻿namespace SavannahGame.Forms
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
            this.savannahPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.savannahPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // savannahPictureBox
            // 
            this.savannahPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.savannahPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.savannahPictureBox.Location = new System.Drawing.Point(12, 12);
            this.savannahPictureBox.Name = "savannahPictureBox";
            this.savannahPictureBox.Size = new System.Drawing.Size(728, 705);
            this.savannahPictureBox.TabIndex = 0;
            this.savannahPictureBox.TabStop = false;
            this.savannahPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.savannahPictureBox_Paint);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 729);
            this.Controls.Add(this.savannahPictureBox);
            this.Name = "GameForm";
            this.Text = "GameForm";
            ((System.ComponentModel.ISupportInitialize)(this.savannahPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox savannahPictureBox;
    }
}

