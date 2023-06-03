
namespace WTERP
{
    partial class Form6EF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6EF5));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.dataF6EF5 = new System.Windows.Forms.DataGridView();
            this.WS_KD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_KIND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btdong = new System.Windows.Forms.Button();
            this.bttk = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataF6EF5)).BeginInit();
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
            this.tb1.TextChanged += new System.EventHandler(this.tb1_TextChanged);
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.TextChanged += new System.EventHandler(this.tb2_TextChanged);
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // dataF6EF5
            // 
            resources.ApplyResources(this.dataF6EF5, "dataF6EF5");
            this.dataF6EF5.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataF6EF5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataF6EF5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WS_KD,
            this.WS_KIND,
            this.T_NAME});
            this.dataF6EF5.Name = "dataF6EF5";
            this.dataF6EF5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataF6EF5.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataF6EF5_CellDoubleClick);
            // 
            // WS_KD
            // 
            this.WS_KD.DataPropertyName = "WS_KD";
            resources.ApplyResources(this.WS_KD, "WS_KD");
            this.WS_KD.Name = "WS_KD";
            // 
            // WS_KIND
            // 
            this.WS_KIND.DataPropertyName = "WS_KIND";
            resources.ApplyResources(this.WS_KIND, "WS_KIND");
            this.WS_KIND.Name = "WS_KIND";
            // 
            // T_NAME
            // 
            this.T_NAME.DataPropertyName = "T_NAME";
            resources.ApplyResources(this.T_NAME, "T_NAME");
            this.T_NAME.Name = "T_NAME";
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
            // btok
            // 
            resources.ApplyResources(this.btok, "btok");
            this.btok.Name = "btok";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // Form6EF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.dataF6EF5);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.Name = "Form6EF5";
            this.Load += new System.EventHandler(this.Form6EF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataF6EF5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.DataGridView dataF6EF5;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_KD;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_KIND;
        private System.Windows.Forms.DataGridViewTextBoxColumn T_NAME;
    }
}