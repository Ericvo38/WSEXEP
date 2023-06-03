
namespace WTERP
{
    partial class Form6AF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6AF5));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.bttk = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.dataF6F5 = new System.Windows.Forms.DataGridView();
            this.WSNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WSDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataF6F5)).BeginInit();
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // tb3
            // 
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.Name = "tb3";
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Name = "label4";
            // 
            // tb4
            // 
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.Name = "tb4";
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            // 
            // bttk
            // 
            resources.ApplyResources(this.bttk, "bttk");
            this.bttk.Name = "bttk";
            this.bttk.UseVisualStyleBackColor = true;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // btdong
            // 
            resources.ApplyResources(this.btdong, "btdong");
            this.btdong.Name = "btdong";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // dataF6F5
            // 
            this.dataF6F5.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataF6F5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataF6F5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WSNO,
            this.WSDATE,
            this.USER_ID,
            this.NAME});
            resources.ApplyResources(this.dataF6F5, "dataF6F5");
            this.dataF6F5.Name = "dataF6F5";
            this.dataF6F5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataF6F5.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataF6F5_CellMouseDoubleClick);
            // 
            // WSNO
            // 
            this.WSNO.DataPropertyName = "WSNO";
            resources.ApplyResources(this.WSNO, "WSNO");
            this.WSNO.Name = "WSNO";
            // 
            // WSDATE
            // 
            this.WSDATE.DataPropertyName = "WSDATE";
            resources.ApplyResources(this.WSDATE, "WSDATE");
            this.WSDATE.Name = "WSDATE";
            // 
            // USER_ID
            // 
            this.USER_ID.DataPropertyName = "USER_ID";
            resources.ApplyResources(this.USER_ID, "USER_ID");
            this.USER_ID.Name = "USER_ID";
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            resources.ApplyResources(this.NAME, "NAME");
            this.NAME.Name = "NAME";
            // 
            // Form6AF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataF6F5);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form6AF5";
            this.Load += new System.EventHandler(this.Form6F5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataF6F5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridView dataF6F5;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
    }
}