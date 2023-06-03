
namespace WTERP
{
    partial class FormSearchBrand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchBrand));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewthuonghieu = new System.Windows.Forms.DataGridView();
            this.B_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewthuonghieu)).BeginInit();
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
            // dataGridViewthuonghieu
            // 
            this.dataGridViewthuonghieu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewthuonghieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewthuonghieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.B_NO,
            this.BRAND,
            this.TRADE});
            resources.ApplyResources(this.dataGridViewthuonghieu, "dataGridViewthuonghieu");
            this.dataGridViewthuonghieu.Name = "dataGridViewthuonghieu";
            this.dataGridViewthuonghieu.RowTemplate.Height = 28;
            this.dataGridViewthuonghieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewthuonghieu.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewthuonghieu_CellMouseDoubleClick);
            // 
            // B_NO
            // 
            this.B_NO.DataPropertyName = "B_NO";
            resources.ApplyResources(this.B_NO, "B_NO");
            this.B_NO.Name = "B_NO";
            // 
            // BRAND
            // 
            this.BRAND.DataPropertyName = "BRAND";
            resources.ApplyResources(this.BRAND, "BRAND");
            this.BRAND.Name = "BRAND";
            // 
            // TRADE
            // 
            this.TRADE.DataPropertyName = "TRADE";
            resources.ApplyResources(this.TRADE, "TRADE");
            this.TRADE.Name = "TRADE";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormSearchBrand
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridViewthuonghieu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchBrand";
            this.Load += new System.EventHandler(this.Formtimkiemnhanhieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewthuonghieu)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewthuonghieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn B_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRADE;
        private System.Windows.Forms.Button button4;
    }
}