
namespace WTERP
{
    partial class frm2QF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2QF5));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtP_WT = new System.Windows.Forms.TextBox();
            this.txtP_WTI = new System.Windows.Forms.TextBox();
            this.txtP_NAME1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.P_WT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_WTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // txtP_WT
            // 
            resources.ApplyResources(this.txtP_WT, "txtP_WT");
            this.txtP_WT.Name = "txtP_WT";
            this.txtP_WT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP_WT_KeyDown);
            // 
            // txtP_WTI
            // 
            resources.ApplyResources(this.txtP_WTI, "txtP_WTI");
            this.txtP_WTI.Name = "txtP_WTI";
            this.txtP_WTI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP_WTI_KeyDown);
            // 
            // txtP_NAME1
            // 
            resources.ApplyResources(this.txtP_NAME1, "txtP_NAME1");
            this.txtP_NAME1.Name = "txtP_NAME1";
            this.txtP_NAME1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP_NAME1_KeyDown);
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
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_WT,
            this.P_WTI,
            this.P_NAME1,
            this.P_NAME2});
            resources.ApplyResources(this.DGV1, "DGV1");
            this.DGV1.Name = "DGV1";
            this.DGV1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellDoubleClick);
            // 
            // P_WT
            // 
            this.P_WT.DataPropertyName = "P_WT";
            resources.ApplyResources(this.P_WT, "P_WT");
            this.P_WT.Name = "P_WT";
            // 
            // P_WTI
            // 
            this.P_WTI.DataPropertyName = "P_WTI";
            resources.ApplyResources(this.P_WTI, "P_WTI");
            this.P_WTI.Name = "P_WTI";
            // 
            // P_NAME1
            // 
            this.P_NAME1.DataPropertyName = "P_NAME1";
            resources.ApplyResources(this.P_NAME1, "P_NAME1");
            this.P_NAME1.Name = "P_NAME1";
            // 
            // P_NAME2
            // 
            this.P_NAME2.DataPropertyName = "P_NAME2";
            resources.ApplyResources(this.P_NAME2, "P_NAME2");
            this.P_NAME2.Name = "P_NAME2";
            // 
            // frm2QF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtP_NAME1);
            this.Controls.Add(this.txtP_WTI);
            this.Controls.Add(this.txtP_WT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2QF5";
            this.Load += new System.EventHandler(this.frm2QF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtP_WT;
        private System.Windows.Forms.TextBox txtP_WTI;
        private System.Windows.Forms.TextBox txtP_NAME1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_WT;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_WTI;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME2;
    }
}