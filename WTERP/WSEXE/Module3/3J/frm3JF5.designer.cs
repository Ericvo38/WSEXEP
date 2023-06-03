
namespace WTERP
{
    partial class frm3JF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm3JF5));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DGV2 = new WTERP.WSEXE.CustomDGV();
            this.MK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOURCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BPCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MK_NO,
            this.SOURCE,
            this.WKG,
            this.CARNO,
            this.UKG,
            this.BPCS,
            this.USR_NAME});
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellDoubleClick);
            // 
            // MK_NO
            // 
            this.MK_NO.DataPropertyName = "MK_NO";
            resources.ApplyResources(this.MK_NO, "MK_NO");
            this.MK_NO.Name = "MK_NO";
            this.MK_NO.ReadOnly = true;
            // 
            // SOURCE
            // 
            this.SOURCE.DataPropertyName = "SOURCE";
            resources.ApplyResources(this.SOURCE, "SOURCE");
            this.SOURCE.Name = "SOURCE";
            this.SOURCE.ReadOnly = true;
            // 
            // WKG
            // 
            this.WKG.DataPropertyName = "WKG";
            resources.ApplyResources(this.WKG, "WKG");
            this.WKG.Name = "WKG";
            this.WKG.ReadOnly = true;
            // 
            // CARNO
            // 
            this.CARNO.DataPropertyName = "CARNO";
            resources.ApplyResources(this.CARNO, "CARNO");
            this.CARNO.Name = "CARNO";
            this.CARNO.ReadOnly = true;
            // 
            // UKG
            // 
            this.UKG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UKG.DataPropertyName = "UKG";
            resources.ApplyResources(this.UKG, "UKG");
            this.UKG.Name = "UKG";
            this.UKG.ReadOnly = true;
            // 
            // BPCS
            // 
            this.BPCS.DataPropertyName = "BPCS";
            resources.ApplyResources(this.BPCS, "BPCS");
            this.BPCS.Name = "BPCS";
            this.BPCS.ReadOnly = true;
            // 
            // USR_NAME
            // 
            this.USR_NAME.DataPropertyName = "USR_NAME";
            resources.ApplyResources(this.USR_NAME, "USR_NAME");
            this.USR_NAME.Name = "USR_NAME";
            this.USR_NAME.ReadOnly = true;
            // 
            // frm3JF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm3JF5";
            this.Load += new System.EventHandler(this.frm3JF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private WTERP.WSEXE.CustomDGV DGV2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOURCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn BPCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn USR_NAME;
    }
}