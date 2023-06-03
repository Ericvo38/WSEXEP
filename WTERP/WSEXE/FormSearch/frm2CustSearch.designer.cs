
namespace WTERP
{
    partial class frm2CustSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2CustSearch));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txttenKH = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME2_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_ANAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtmaKH = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txttenKH
            // 
            resources.ApplyResources(this.txttenKH, "txttenKH");
            this.txttenKH.Name = "txttenKH";
            this.txttenKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenKH_KeyDown);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // btnThoat
            // 
            resources.ApplyResources(this.btnThoat, "btnThoat");
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_NO,
            this.C_NAME2,
            this.C_NAME2_E,
            this.C_ANAME2,
            this.ADR3});
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowTemplate.Height = 28;
            this.DGV2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellDoubleClick);
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            this.C_NO.ReadOnly = true;
            // 
            // C_NAME2
            // 
            this.C_NAME2.DataPropertyName = "C_NAME2";
            resources.ApplyResources(this.C_NAME2, "C_NAME2");
            this.C_NAME2.Name = "C_NAME2";
            this.C_NAME2.ReadOnly = true;
            // 
            // C_NAME2_E
            // 
            this.C_NAME2_E.DataPropertyName = "C_NAME2_E";
            resources.ApplyResources(this.C_NAME2_E, "C_NAME2_E");
            this.C_NAME2_E.Name = "C_NAME2_E";
            this.C_NAME2_E.ReadOnly = true;
            // 
            // C_ANAME2
            // 
            this.C_ANAME2.DataPropertyName = "C_ANAME2";
            resources.ApplyResources(this.C_ANAME2, "C_ANAME2");
            this.C_ANAME2.Name = "C_ANAME2";
            this.C_ANAME2.ReadOnly = true;
            // 
            // ADR3
            // 
            this.ADR3.DataPropertyName = "ADR3";
            resources.ApplyResources(this.ADR3, "ADR3");
            this.ADR3.Name = "ADR3";
            this.ADR3.ReadOnly = true;
            // 
            // txtmaKH
            // 
            resources.ApplyResources(this.txtmaKH, "txtmaKH");
            this.txtmaKH.Name = "txtmaKH";
            this.txtmaKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmaKH_KeyDown);
            // 
            // frm2CustSearch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtmaKH);
            this.Controls.Add(this.txttenKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2CustSearch";
            this.Load += new System.EventHandler(this.frm2CustSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttenKH;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.TextBox txtmaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME2_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_ANAME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR3;
    }
}