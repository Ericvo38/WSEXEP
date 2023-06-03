
namespace WTERP
{
    partial class FrmSearchMEMO1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearchMEMO1));
            this.txtM_MO = new System.Windows.Forms.TextBox();
            this.txtM_NAME = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btok = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.M_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtM_MO
            // 
            resources.ApplyResources(this.txtM_MO, "txtM_MO");
            this.txtM_MO.Name = "txtM_MO";
            this.txtM_MO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtM_MO_KeyDown);
            // 
            // txtM_NAME
            // 
            resources.ApplyResources(this.txtM_NAME, "txtM_NAME");
            this.txtM_NAME.Name = "txtM_NAME";
            this.txtM_NAME.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtM_NAME_KeyDown);
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
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M_NO,
            this.M_NAME});
            resources.ApplyResources(this.DGV1, "DGV1");
            this.DGV1.Name = "DGV1";
            this.DGV1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV1_CellMouseDoubleClick);
            // 
            // M_NO
            // 
            this.M_NO.DataPropertyName = "M_NO";
            resources.ApplyResources(this.M_NO, "M_NO");
            this.M_NO.Name = "M_NO";
            // 
            // M_NAME
            // 
            this.M_NAME.DataPropertyName = "M_NAME";
            resources.ApplyResources(this.M_NAME, "M_NAME");
            this.M_NAME.Name = "M_NAME";
            // 
            // FrmSearchMEMO1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtM_NAME);
            this.Controls.Add(this.txtM_MO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearchMEMO1";
            this.Load += new System.EventHandler(this.FrmSearchMEMO1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtM_MO;
        private System.Windows.Forms.TextBox txtM_NAME;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_NAME;
    }
}