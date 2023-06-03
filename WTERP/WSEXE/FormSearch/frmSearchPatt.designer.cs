
namespace WTERP
{
    partial class frmSearchPatt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPatt));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewPatt = new System.Windows.Forms.DataGridView();
            this.PT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatt)).BeginInit();
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
            // tb3
            // 
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.Name = "tb3";
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
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
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewPatt
            // 
            this.dataGridViewPatt.AllowUserToAddRows = false;
            this.dataGridViewPatt.AllowUserToDeleteRows = false;
            this.dataGridViewPatt.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewPatt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PT_NO,
            this.PATT_NO,
            this.PATT_C,
            this.PATT_E,
            this.MEMO});
            resources.ApplyResources(this.dataGridViewPatt, "dataGridViewPatt");
            this.dataGridViewPatt.Name = "dataGridViewPatt";
            this.dataGridViewPatt.ReadOnly = true;
            this.dataGridViewPatt.RowTemplate.Height = 28;
            this.dataGridViewPatt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPatt.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPatt_CellMouseDoubleClick);
            // 
            // PT_NO
            // 
            this.PT_NO.DataPropertyName = "PT_NO";
            resources.ApplyResources(this.PT_NO, "PT_NO");
            this.PT_NO.Name = "PT_NO";
            this.PT_NO.ReadOnly = true;
            // 
            // PATT_NO
            // 
            this.PATT_NO.DataPropertyName = "PATT_NO";
            resources.ApplyResources(this.PATT_NO, "PATT_NO");
            this.PATT_NO.Name = "PATT_NO";
            this.PATT_NO.ReadOnly = true;
            // 
            // PATT_C
            // 
            this.PATT_C.DataPropertyName = "PATT_C";
            resources.ApplyResources(this.PATT_C, "PATT_C");
            this.PATT_C.Name = "PATT_C";
            this.PATT_C.ReadOnly = true;
            // 
            // PATT_E
            // 
            this.PATT_E.DataPropertyName = "PATT_E";
            resources.ApplyResources(this.PATT_E, "PATT_E");
            this.PATT_E.Name = "PATT_E";
            this.PATT_E.ReadOnly = true;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            resources.ApplyResources(this.MEMO, "MEMO");
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            // 
            // frmSearchPatt
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewPatt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchPatt";
            this.Load += new System.EventHandler(this.Formtimkiempattmau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        public System.Windows.Forms.DataGridView dataGridViewPatt;
    }
}