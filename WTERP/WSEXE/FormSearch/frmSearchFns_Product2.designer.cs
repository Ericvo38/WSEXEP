
namespace WTERP
{
    partial class FormSearchFns_Product2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchFns_Product2));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewkhothanhpham = new System.Windows.Forms.DataGridView();
            this.G_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewkhothanhpham)).BeginInit();
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
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
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
            // dataGridViewkhothanhpham
            // 
            this.dataGridViewkhothanhpham.AllowUserToAddRows = false;
            this.dataGridViewkhothanhpham.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewkhothanhpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewkhothanhpham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.G_NO,
            this.G_NAME});
            resources.ApplyResources(this.dataGridViewkhothanhpham, "dataGridViewkhothanhpham");
            this.dataGridViewkhothanhpham.Name = "dataGridViewkhothanhpham";
            this.dataGridViewkhothanhpham.RowTemplate.Height = 28;
            this.dataGridViewkhothanhpham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewkhothanhpham.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewkhothanhpham_CellMouseDoubleClick);
            // 
            // G_NO
            // 
            this.G_NO.DataPropertyName = "G_NO";
            resources.ApplyResources(this.G_NO, "G_NO");
            this.G_NO.Name = "G_NO";
            // 
            // G_NAME
            // 
            this.G_NAME.DataPropertyName = "G_NAME";
            resources.ApplyResources(this.G_NAME, "G_NAME");
            this.G_NAME.Name = "G_NAME";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormSearchFns_Product2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridViewkhothanhpham);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchFns_Product2";
            this.Load += new System.EventHandler(this.Formtimkiemkhothanhpham2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewkhothanhpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dataGridViewkhothanhpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_NAME;
        private System.Windows.Forms.Button button4;
    }
}