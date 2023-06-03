
namespace WTERP
{
    partial class frm2PF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2PF5));
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsoVB = new System.Windows.Forms.TextBox();
            this.btnQRy = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtmaKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_ANAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Name = "label7";
            // 
            // txtsoVB
            // 
            resources.ApplyResources(this.txtsoVB, "txtsoVB");
            this.txtsoVB.Name = "txtsoVB";
            this.txtsoVB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoVB_KeyDown);
            // 
            // btnQRy
            // 
            resources.ApplyResources(this.btnQRy, "btnQRy");
            this.btnQRy.Name = "btnQRy";
            this.btnQRy.UseVisualStyleBackColor = true;
            this.btnQRy.Click += new System.EventHandler(this.btnQRy_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtmaKH
            // 
            resources.ApplyResources(this.txtmaKH, "txtmaKH");
            this.txtmaKH.Name = "txtmaKH";
            this.txtmaKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmaKH_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // DGV2
            // 
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OR_NO,
            this.WS_DATE,
            this.C_ANAME,
            this.C_NO});
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.RowTemplate.Height = 28;
            this.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // OR_NO
            // 
            this.OR_NO.DataPropertyName = "OR_NO";
            resources.ApplyResources(this.OR_NO, "OR_NO");
            this.OR_NO.Name = "OR_NO";
            // 
            // WS_DATE
            // 
            this.WS_DATE.DataPropertyName = "WS_DATE";
            resources.ApplyResources(this.WS_DATE, "WS_DATE");
            this.WS_DATE.Name = "WS_DATE";
            // 
            // C_ANAME
            // 
            this.C_ANAME.DataPropertyName = "C_ANAME";
            resources.ApplyResources(this.C_ANAME, "C_ANAME");
            this.C_ANAME.Name = "C_ANAME";
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGV2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // date
            // 
            resources.ApplyResources(this.date, "date");
            this.date.Name = "date";
            this.date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.date_KeyDown);
            // 
            // frm2PF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.date);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmaKH);
            this.Controls.Add(this.txtsoVB);
            this.Controls.Add(this.btnQRy);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2PF5";
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsoVB;
        private System.Windows.Forms.Button btnQRy;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtmaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox date;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_ANAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
    }
}