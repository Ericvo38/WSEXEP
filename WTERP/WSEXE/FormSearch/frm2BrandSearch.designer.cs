
namespace WTERP
{
    partial class frm2BrandSearch
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2BrandSearch));
            this.label1 = new System.Windows.Forms.Label();
            this.txtmaTH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txttenTHC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttenTHE = new System.Windows.Forms.TextBox();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.B_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // txtmaTH
            // 
            resources.ApplyResources(this.txtmaTH, "txtmaTH");
            this.txtmaTH.Name = "txtmaTH";
            this.txtmaTH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmaTH_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // txttenTHC
            // 
            resources.ApplyResources(this.txttenTHC, "txttenTHC");
            this.txttenTHC.Name = "txttenTHC";
            this.txttenTHC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenTHC_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // txttenTHE
            // 
            resources.ApplyResources(this.txttenTHE, "txttenTHE");
            this.txttenTHE.Name = "txttenTHE";
            this.txttenTHE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenTHE_KeyDown);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.B_NO,
            this.BRAND,
            this.TRADE});
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowTemplate.Height = 28;
            this.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellDoubleClick);
            // 
            // B_NO
            // 
            this.B_NO.DataPropertyName = "B_NO";
            resources.ApplyResources(this.B_NO, "B_NO");
            this.B_NO.Name = "B_NO";
            this.B_NO.ReadOnly = true;
            // 
            // BRAND
            // 
            this.BRAND.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BRAND.DataPropertyName = "BRAND";
            resources.ApplyResources(this.BRAND, "BRAND");
            this.BRAND.Name = "BRAND";
            this.BRAND.ReadOnly = true;
            // 
            // TRADE
            // 
            this.TRADE.DataPropertyName = "TRADE";
            resources.ApplyResources(this.TRADE, "TRADE");
            this.TRADE.Name = "TRADE";
            this.TRADE.ReadOnly = true;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm2BrandSearch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txttenTHE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttenTHC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmaTH);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2BrandSearch";
            this.Load += new System.EventHandler(this.Formtimkiemnhanhieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmaTH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttenTHC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttenTHE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn B_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRADE;
    }
}