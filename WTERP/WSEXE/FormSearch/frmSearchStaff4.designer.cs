
namespace WTERP
{
    partial class FormSearchStaff4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchStaff4));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.dataGridViewnhanvien = new System.Windows.Forms.DataGridView();
            this.S_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewnhanvien)).BeginInit();
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
            // dataGridViewnhanvien
            // 
            this.dataGridViewnhanvien.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewnhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewnhanvien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_NO,
            this.S_NAME});
            resources.ApplyResources(this.dataGridViewnhanvien, "dataGridViewnhanvien");
            this.dataGridViewnhanvien.Name = "dataGridViewnhanvien";
            this.dataGridViewnhanvien.RowTemplate.Height = 28;
            this.dataGridViewnhanvien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewnhanvien.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewnhanvien_CellMouseDoubleClick);
            // 
            // S_NO
            // 
            this.S_NO.DataPropertyName = "S_NO";
            resources.ApplyResources(this.S_NO, "S_NO");
            this.S_NO.Name = "S_NO";
            // 
            // S_NAME
            // 
            this.S_NAME.DataPropertyName = "S_NAME";
            resources.ApplyResources(this.S_NAME, "S_NAME");
            this.S_NAME.Name = "S_NAME";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // FormSearchStaff4
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewnhanvien);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSearchStaff4";
            this.Load += new System.EventHandler(this.Formtimkiemnhanvien4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewnhanvien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_NAME;
        public System.Windows.Forms.DataGridView dataGridViewnhanvien;
    }
}