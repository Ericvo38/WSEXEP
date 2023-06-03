
namespace WTERP
{
    partial class frm3IF2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm3IF2));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_TRAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // tb1
            // 
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.Name = "tb1";
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // tb2
            // 
            this.tb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.TextChanged += new System.EventHandler(this.tb2_TextChanged);
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
            this.tb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.Name = "tb3";
            this.tb3.TextChanged += new System.EventHandler(this.tb3_TextChanged);
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tb4
            // 
            this.tb4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.Name = "tb4";
            this.tb4.TextChanged += new System.EventHandler(this.tb4_TextChanged);
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Name = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tb5
            // 
            this.tb5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb5, "tb5");
            this.tb5.Name = "tb5";
            this.tb5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb5_KeyDown);
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGV1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_NO,
            this.P_NAME,
            this.P_NAME1,
            this.PRICE,
            this.P_NAME2,
            this.P_NAME3,
            this.C_NO,
            this.M_TRAN});
            resources.ApplyResources(this.DGV1, "DGV1");
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGV1_MouseClick);
            this.DGV1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DGV1_MouseDoubleClick);
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            this.P_NO.ReadOnly = true;
            // 
            // P_NAME
            // 
            this.P_NAME.DataPropertyName = "P_NAME";
            resources.ApplyResources(this.P_NAME, "P_NAME");
            this.P_NAME.Name = "P_NAME";
            this.P_NAME.ReadOnly = true;
            // 
            // P_NAME1
            // 
            this.P_NAME1.DataPropertyName = "P_NAME1";
            resources.ApplyResources(this.P_NAME1, "P_NAME1");
            this.P_NAME1.Name = "P_NAME1";
            this.P_NAME1.ReadOnly = true;
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            resources.ApplyResources(this.PRICE, "PRICE");
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            // 
            // P_NAME2
            // 
            this.P_NAME2.DataPropertyName = "P_NAME2";
            resources.ApplyResources(this.P_NAME2, "P_NAME2");
            this.P_NAME2.Name = "P_NAME2";
            this.P_NAME2.ReadOnly = true;
            // 
            // P_NAME3
            // 
            this.P_NAME3.DataPropertyName = "P_NAME3";
            resources.ApplyResources(this.P_NAME3, "P_NAME3");
            this.P_NAME3.Name = "P_NAME3";
            this.P_NAME3.ReadOnly = true;
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            this.C_NO.ReadOnly = true;
            // 
            // M_TRAN
            // 
            this.M_TRAN.DataPropertyName = "M_TRAN";
            resources.ApplyResources(this.M_TRAN, "M_TRAN");
            this.M_TRAN.Name = "M_TRAN";
            this.M_TRAN.ReadOnly = true;
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frm3IF2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm3IF2";
            this.Load += new System.EventHandler(this.frm3IF2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME3;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_TRAN;
    }
}