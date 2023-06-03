
namespace WTERP
{
    partial class FormSearchProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchProgram));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.bttk = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.dataProgram = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WSPROGRAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WSNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataProgram)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // tb1
            // 
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.Name = "tb1";
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // bttk
            // 
            resources.ApplyResources(this.bttk, "bttk");
            this.bttk.Name = "bttk";
            this.bttk.UseVisualStyleBackColor = true;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // btok
            // 
            resources.ApplyResources(this.btok, "btok");
            this.btok.Name = "btok";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // btdong
            // 
            resources.ApplyResources(this.btdong, "btdong");
            this.btdong.Name = "btdong";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // dataProgram
            // 
            this.dataProgram.AllowUserToAddRows = false;
            this.dataProgram.AllowUserToDeleteRows = false;
            this.dataProgram.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProgram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.WSPROGRAM,
            this.WSNAME,
            this.REPORT});
            resources.ApplyResources(this.dataProgram, "dataProgram");
            this.dataProgram.Name = "dataProgram";
            this.dataProgram.ReadOnly = true;
            // 
            // Select
            // 
            this.Select.DataPropertyName = "Select";
            resources.ApplyResources(this.Select, "Select");
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // WSPROGRAM
            // 
            this.WSPROGRAM.DataPropertyName = "WSPROGRAM";
            resources.ApplyResources(this.WSPROGRAM, "WSPROGRAM");
            this.WSPROGRAM.Name = "WSPROGRAM";
            this.WSPROGRAM.ReadOnly = true;
            // 
            // WSNAME
            // 
            this.WSNAME.DataPropertyName = "WSNAME";
            resources.ApplyResources(this.WSNAME, "WSNAME");
            this.WSNAME.Name = "WSNAME";
            this.WSNAME.ReadOnly = true;
            // 
            // REPORT
            // 
            this.REPORT.DataPropertyName = "REPORT";
            resources.ApplyResources(this.REPORT, "REPORT");
            this.REPORT.Name = "REPORT";
            this.REPORT.ReadOnly = true;
            // 
            // FormSearchProgram
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataProgram);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchProgram";
            this.Load += new System.EventHandler(this.FormSearchProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProgram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridView dataProgram;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSPROGRAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPORT;
    }
}