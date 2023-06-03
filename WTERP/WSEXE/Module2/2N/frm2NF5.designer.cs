
namespace WTERP
{
    partial class frm2NF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2NF5));
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.WS_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updatekind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsoVB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtngayKS = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WS_NO,
            this.WS_DATE,
            this.USER_NAME,
            this.Updatekind});
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowTemplate.Height = 28;
            this.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV2.DoubleClick += new System.EventHandler(this.DGV2_DoubleClick);
            // 
            // WS_NO
            // 
            this.WS_NO.DataPropertyName = "WS_NO";
            resources.ApplyResources(this.WS_NO, "WS_NO");
            this.WS_NO.Name = "WS_NO";
            this.WS_NO.ReadOnly = true;
            // 
            // WS_DATE
            // 
            this.WS_DATE.DataPropertyName = "WS_DATE";
            resources.ApplyResources(this.WS_DATE, "WS_DATE");
            this.WS_DATE.Name = "WS_DATE";
            this.WS_DATE.ReadOnly = true;
            // 
            // USER_NAME
            // 
            this.USER_NAME.DataPropertyName = "USER_NAME";
            resources.ApplyResources(this.USER_NAME, "USER_NAME");
            this.USER_NAME.Name = "USER_NAME";
            this.USER_NAME.ReadOnly = true;
            // 
            // Updatekind
            // 
            this.Updatekind.DataPropertyName = "UPDATEKIND";
            resources.ApplyResources(this.Updatekind, "Updatekind");
            this.Updatekind.Name = "Updatekind";
            this.Updatekind.ReadOnly = true;
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // txtngayKS
            // 
            resources.ApplyResources(this.txtngayKS, "txtngayKS");
            this.txtngayKS.Name = "txtngayKS";
            this.txtngayKS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtngayKS_KeyDown);
            this.txtngayKS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtngayKS_MouseDoubleClick);
            // 
            // frm2NF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ControlBox = false;
            this.Controls.Add(this.txtngayKS);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtsoVB);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2NF5";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsoVB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.MaskedTextBox txtngayKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updatekind;
    }
}