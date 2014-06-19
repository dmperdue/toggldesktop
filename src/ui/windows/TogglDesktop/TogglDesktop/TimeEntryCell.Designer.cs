﻿namespace TogglDesktop
{
    partial class TimeEntryCell
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
            this.labelBillable = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelProject = new System.Windows.Forms.Label();
            this.labelTag = new System.Windows.Forms.Label();
            this.labelContinue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelBillable
            // 
            this.labelBillable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBillable.Image = global::TogglDesktop.Properties.Resources.icon_billable;
            this.labelBillable.Location = new System.Drawing.Point(200, 18);
            this.labelBillable.Name = "labelBillable";
            this.labelBillable.Size = new System.Drawing.Size(13, 13);
            this.labelBillable.TabIndex = 0;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(186)));
            this.labelDescription.Location = new System.Drawing.Point(15, 10);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(170, 17);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Blogpost about new stuff in Toggl...";
            this.labelDescription.Click += new System.EventHandler(this.labelDescription_Click);
            // 
            // labelDuration
            // 
            this.labelDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDuration.AutoSize = true;
            this.labelDuration.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(186)));
            this.labelDuration.Location = new System.Drawing.Point(250, 18);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(64, 16);
            this.labelDuration.TabIndex = 3;
            this.labelDuration.Text = "03:21:30";
            this.labelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDuration.Click += new System.EventHandler(this.labelDuration_Click);
            // 
            // labelProject
            // 
            this.labelProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProject.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(186)));
            this.labelProject.Location = new System.Drawing.Point(15, 27);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(170, 17);
            this.labelProject.TabIndex = 4;
            this.labelProject.Text = "NEW PROJECT - TOGGL CLIENT";
            this.labelProject.Click += new System.EventHandler(this.labelProject_Click);
            // 
            // labelTag
            // 
            this.labelTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTag.Image = global::TogglDesktop.Properties.Resources.icon_tags;
            this.labelTag.Location = new System.Drawing.Point(185, 18);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(13, 13);
            this.labelTag.TabIndex = 5;
            // 
            // labelContinue
            // 
            this.labelContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContinue.Image = global::TogglDesktop.Properties.Resources._continue;
            this.labelContinue.Location = new System.Drawing.Point(220, 13);
            this.labelContinue.Name = "labelContinue";
            this.labelContinue.Size = new System.Drawing.Size(24, 24);
            this.labelContinue.TabIndex = 6;
            this.labelContinue.Click += new System.EventHandler(this.labelContinue_Click);
            // 
            // TimeEntryCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.labelContinue);
            this.Controls.Add(this.labelTag);
            this.Controls.Add(this.labelProject);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelBillable);
            this.Name = "TimeEntryCell";
            this.Size = new System.Drawing.Size(314, 50);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TimeEntryCell_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBillable;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelProject;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.Label labelContinue;
    }
}
