
using System;
using System.Windows.Forms;

namespace WTERP
{
    partial class Form3EF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3EF5));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataForm3EF5 = new WTERP.WSEXE.CustomDGV();
            this.WS_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb4 = new System.Windows.Forms.MaskedTextBox();
            this.btdong = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataForm3EF5)).BeginInit();
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
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.tb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.tb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb3.Name = "tb3";
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Name = "label4";
            // 
            // tb5
            // 
            resources.ApplyResources(this.tb5, "tb5");
            this.tb5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb5.Name = "tb5";
            this.tb5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb5_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Name = "label5";
            // 
            // dataForm3EF5
            // 
            resources.ApplyResources(this.dataForm3EF5, "dataForm3EF5");
            this.dataForm3EF5.AllowUserToAddRows = false;
            this.dataForm3EF5.AllowUserToDeleteRows = false;
            this.dataForm3EF5.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataForm3EF5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataForm3EF5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WS_NO,
            this.WS_DATE,
            this.C_NAME,
            this.P_NAME});
            this.dataForm3EF5.Name = "dataForm3EF5";
            this.dataForm3EF5.ReadOnly = true;
            this.dataForm3EF5.RowTemplate.Height = 28;
            this.dataForm3EF5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataForm3EF5.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataForm3EF5_CellMouseDoubleClick);
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
            // C_NAME
            // 
            this.C_NAME.DataPropertyName = "C_NAME";
            resources.ApplyResources(this.C_NAME, "C_NAME");
            this.C_NAME.Name = "C_NAME";
            this.C_NAME.ReadOnly = true;
            // 
            // P_NAME
            // 
            this.P_NAME.DataPropertyName = "P_NAME";
            resources.ApplyResources(this.P_NAME, "P_NAME");
            this.P_NAME.Name = "P_NAME";
            this.P_NAME.ReadOnly = true;
            // 
            // tb4
            // 
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb4.Name = "tb4";
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            this.tb4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tb4_MouseDoubleClick);
            // 
            // btdong
            // 
            resources.ApplyResources(this.btdong, "btdong");
            this.btdong.Name = "btdong";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // btok
            // 
            resources.ApplyResources(this.btok, "btok");
            this.btok.ForeColor = System.Drawing.Color.Black;
            this.btok.Name = "btok";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // Form3EF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.dataForm3EF5);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3EF5";
            this.Load += new System.EventHandler(this.Form3F5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataForm3EF5)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btdong;
        //private System.Windows.Forms.DataGridView dataForm3EF5;
        //this.dataForm3EF5 = new WTERP.WSEXE.CustomDGV(); 
        private WTERP.WSEXE.CustomDGV dataForm3EF5;
        private System.Windows.Forms.MaskedTextBox tb4;
        private DataGridViewTextBoxColumn WS_NO;
        private DataGridViewTextBoxColumn WS_DATE;
        private DataGridViewTextBoxColumn C_NAME;
        private DataGridViewTextBoxColumn P_NAME;
    }
}