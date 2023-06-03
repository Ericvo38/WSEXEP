
namespace WTERP
{
    partial class FormSearhWH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearhWH));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewkho = new System.Windows.Forms.DataGridView();
            this.M_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewkho)).BeginInit();
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
            // t1
            // 
            resources.ApplyResources(this.t1, "t1");
            this.t1.Name = "t1";
            this.t1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t1_KeyDown);
            // 
            // t2
            // 
            resources.ApplyResources(this.t2, "t2");
            this.t2.Name = "t2";
            this.t2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t2_KeyDown);
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
            // dataGridViewkho
            // 
            this.dataGridViewkho.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewkho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M_NO,
            this.M_NAME});
            resources.ApplyResources(this.dataGridViewkho, "dataGridViewkho");
            this.dataGridViewkho.Name = "dataGridViewkho";
            this.dataGridViewkho.RowTemplate.Height = 28;
            this.dataGridViewkho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewkho.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewkho_CellMouseDoubleClick);
            // 
            // M_NO
            // 
            this.M_NO.DataPropertyName = "M_NO";
            resources.ApplyResources(this.M_NO, "M_NO");
            this.M_NO.Name = "M_NO";
            // 
            // M_NAME
            // 
            this.M_NAME.DataPropertyName = "M_NAME";
            resources.ApplyResources(this.M_NAME, "M_NAME");
            this.M_NAME.Name = "M_NAME";
            // 
            // FormSearhWH
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewkho);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearhWH";
            this.Load += new System.EventHandler(this.FormSearhWH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewkho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.TextBox t2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewkho;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_NAME;
    }
}