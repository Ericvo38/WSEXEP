
namespace WTERP
{
    partial class Form1RF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1RF5));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.tbok = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.bttk = new System.Windows.Forms.Button();
            this.dataGridViewFormR = new System.Windows.Forms.DataGridView();
            this.PT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PT_BRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFormR)).BeginInit();
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
            // tbok
            // 
            resources.ApplyResources(this.tbok, "tbok");
            this.tbok.Name = "tbok";
            this.tbok.UseVisualStyleBackColor = true;
            this.tbok.Click += new System.EventHandler(this.tbok_Click);
            // 
            // btdong
            // 
            resources.ApplyResources(this.btdong, "btdong");
            this.btdong.Name = "btdong";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // bttk
            // 
            resources.ApplyResources(this.bttk, "bttk");
            this.bttk.Name = "bttk";
            this.bttk.UseVisualStyleBackColor = true;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // dataGridViewFormR
            // 
            this.dataGridViewFormR.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewFormR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFormR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PT_NO,
            this.PATT_NO,
            this.PATT_C,
            this.PATT_E,
            this.PT_BRAND,
            this.MEMO});
            resources.ApplyResources(this.dataGridViewFormR, "dataGridViewFormR");
            this.dataGridViewFormR.Name = "dataGridViewFormR";
            this.dataGridViewFormR.RowTemplate.Height = 28;
            this.dataGridViewFormR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFormR.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewFormR_CellMouseDoubleClick);
            // 
            // PT_NO
            // 
            this.PT_NO.DataPropertyName = "PT_NO";
            resources.ApplyResources(this.PT_NO, "PT_NO");
            this.PT_NO.Name = "PT_NO";
            // 
            // PATT_NO
            // 
            this.PATT_NO.DataPropertyName = "PATT_NO";
            resources.ApplyResources(this.PATT_NO, "PATT_NO");
            this.PATT_NO.Name = "PATT_NO";
            // 
            // PATT_C
            // 
            this.PATT_C.DataPropertyName = "PATT_C";
            resources.ApplyResources(this.PATT_C, "PATT_C");
            this.PATT_C.Name = "PATT_C";
            // 
            // PATT_E
            // 
            this.PATT_E.DataPropertyName = "PATT_E";
            resources.ApplyResources(this.PATT_E, "PATT_E");
            this.PATT_E.Name = "PATT_E";
            // 
            // PT_BRAND
            // 
            this.PT_BRAND.DataPropertyName = "PT_BRAND";
            resources.ApplyResources(this.PT_BRAND, "PT_BRAND");
            this.PT_BRAND.Name = "PT_BRAND";
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            resources.ApplyResources(this.MEMO, "MEMO");
            this.MEMO.Name = "MEMO";
            // 
            // Form1RF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewFormR);
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.tbok);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1RF5";
            this.Load += new System.EventHandler(this.Form1RF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFormR)).EndInit();
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
        private System.Windows.Forms.Button tbok;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.DataGridView dataGridViewFormR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn PT_BRAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}