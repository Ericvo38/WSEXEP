﻿
namespace WTERP
{
    partial class Language
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Language));
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rdCH = new System.Windows.Forms.RadioButton();
            this.rdVN = new System.Windows.Forms.RadioButton();
            this.rdENL = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            resources.ApplyResources(this.groupBox11, "groupBox11");
            this.groupBox11.Controls.Add(this.rdCH);
            this.groupBox11.Controls.Add(this.rdVN);
            this.groupBox11.Controls.Add(this.rdENL);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.TabStop = false;
            // 
            // rdCH
            // 
            resources.ApplyResources(this.rdCH, "rdCH");
            this.rdCH.Name = "rdCH";
            this.rdCH.UseVisualStyleBackColor = true;
            this.rdCH.CheckedChanged += new System.EventHandler(this.rdCH_CheckedChanged);
            // 
            // rdVN
            // 
            resources.ApplyResources(this.rdVN, "rdVN");
            this.rdVN.Checked = true;
            this.rdVN.Name = "rdVN";
            this.rdVN.TabStop = true;
            this.rdVN.UseVisualStyleBackColor = true;
            this.rdVN.CheckedChanged += new System.EventHandler(this.rdVN_CheckedChanged);
            // 
            // rdENL
            // 
            resources.ApplyResources(this.rdENL, "rdENL");
            this.rdENL.Name = "rdENL";
            this.rdENL.UseVisualStyleBackColor = true;
            this.rdENL.CheckedChanged += new System.EventHandler(this.rdENL_CheckedChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.ForeColor = System.Drawing.Color.LimeGreen;
            this.progressBar1.Name = "progressBar1";
            // 
            // Language
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox11);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Language";
            this.Load += new System.EventHandler(this.Langues_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RadioButton rdVN;
        private System.Windows.Forms.RadioButton rdENL;
        private System.Windows.Forms.RadioButton rdCH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}