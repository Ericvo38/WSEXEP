
namespace WTERP
{
    partial class frm3DF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm3DF5));
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV3 = new System.Windows.Forms.DataGridView();
            this.WS_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDate1 = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyDown);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Name = "label2";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Name = "label3";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Name = "label1";
            // 
            // DGV3
            // 
            this.DGV3.AllowUserToAddRows = false;
            this.DGV3.AllowUserToDeleteRows = false;
            this.DGV3.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WS_NO,
            this.WS_DATE,
            this.C_NO,
            this.C_NAME,
            this.P_NAME1,
            this.OR_NO});
            resources.ApplyResources(this.DGV3, "DGV3");
            this.DGV3.Name = "DGV3";
            this.DGV3.ReadOnly = true;
            this.DGV3.RowTemplate.Height = 28;
            this.DGV3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV3_CellDoubleClick);
            this.DGV3.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV3_CellMouseClick);
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
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            this.C_NO.ReadOnly = true;
            // 
            // C_NAME
            // 
            this.C_NAME.DataPropertyName = "C_NAME";
            resources.ApplyResources(this.C_NAME, "C_NAME");
            this.C_NAME.Name = "C_NAME";
            this.C_NAME.ReadOnly = true;
            // 
            // P_NAME1
            // 
            this.P_NAME1.DataPropertyName = "P_NAME1";
            resources.ApplyResources(this.P_NAME1, "P_NAME1");
            this.P_NAME1.Name = "P_NAME1";
            this.P_NAME1.ReadOnly = true;
            // 
            // OR_NO
            // 
            this.OR_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OR_NO.DataPropertyName = "OR_NO";
            resources.ApplyResources(this.OR_NO, "OR_NO");
            this.OR_NO.Name = "OR_NO";
            this.OR_NO.ReadOnly = true;
            // 
            // txtDate1
            // 
            resources.ApplyResources(this.txtDate1, "txtDate1");
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.ValidatingType = typeof(System.DateTime);
            this.txtDate1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate1_KeyDown);
            this.txtDate1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDate1_MouseDoubleClick);
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
            // frm3DF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDate1);
            this.Controls.Add(this.DGV3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm3DF5";
            this.Load += new System.EventHandler(this.frm3DF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGV3;
        private System.Windows.Forms.MaskedTextBox txtDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
    }
}