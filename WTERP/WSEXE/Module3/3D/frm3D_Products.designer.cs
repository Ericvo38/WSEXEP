
namespace WTERP
{
    partial class frm3D_Products
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm3D_Products));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.DGV3 = new System.Windows.Forms.DataGridView();
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THICK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Name = "label2";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Name = "textBox2";
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // DGV3
            // 
            resources.ApplyResources(this.DGV3, "DGV3");
            this.DGV3.AllowUserToAddRows = false;
            this.DGV3.AllowUserToDeleteRows = false;
            this.DGV3.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OR_NO,
            this.COLOR_C,
            this.COLOR_E,
            this.P_NAME_C,
            this.P_NAME_E,
            this.THICK,
            this.QTY,
            this.K_NO,
            this.WS_DATE,
            this.NR,
            this.C_NO,
            this.C_NAME_C,
            this.C_NAME_E,
            this.BRAND,
            this.MODEL_C,
            this.MODEL_E,
            this.P_NO});
            this.DGV3.Name = "DGV3";
            this.DGV3.ReadOnly = true;
            this.DGV3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV3_CellClick);
            this.DGV3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV3_CellDoubleClick);
            // 
            // OR_NO
            // 
            this.OR_NO.DataPropertyName = "OR_NO";
            resources.ApplyResources(this.OR_NO, "OR_NO");
            this.OR_NO.Name = "OR_NO";
            this.OR_NO.ReadOnly = true;
            // 
            // COLOR_C
            // 
            this.COLOR_C.DataPropertyName = "COLOR_C";
            resources.ApplyResources(this.COLOR_C, "COLOR_C");
            this.COLOR_C.Name = "COLOR_C";
            this.COLOR_C.ReadOnly = true;
            // 
            // COLOR_E
            // 
            this.COLOR_E.DataPropertyName = "COLOR_E";
            resources.ApplyResources(this.COLOR_E, "COLOR_E");
            this.COLOR_E.Name = "COLOR_E";
            this.COLOR_E.ReadOnly = true;
            // 
            // P_NAME_C
            // 
            this.P_NAME_C.DataPropertyName = "P_NAME_C";
            resources.ApplyResources(this.P_NAME_C, "P_NAME_C");
            this.P_NAME_C.Name = "P_NAME_C";
            this.P_NAME_C.ReadOnly = true;
            // 
            // P_NAME_E
            // 
            this.P_NAME_E.DataPropertyName = "P_NAME_E";
            resources.ApplyResources(this.P_NAME_E, "P_NAME_E");
            this.P_NAME_E.Name = "P_NAME_E";
            this.P_NAME_E.ReadOnly = true;
            // 
            // THICK
            // 
            this.THICK.DataPropertyName = "THICK";
            resources.ApplyResources(this.THICK, "THICK");
            this.THICK.Name = "THICK";
            this.THICK.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            resources.ApplyResources(this.QTY, "QTY");
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // K_NO
            // 
            this.K_NO.DataPropertyName = "K_NO";
            resources.ApplyResources(this.K_NO, "K_NO");
            this.K_NO.Name = "K_NO";
            this.K_NO.ReadOnly = true;
            // 
            // WS_DATE
            // 
            this.WS_DATE.DataPropertyName = "WS_DATE";
            resources.ApplyResources(this.WS_DATE, "WS_DATE");
            this.WS_DATE.Name = "WS_DATE";
            this.WS_DATE.ReadOnly = true;
            // 
            // NR
            // 
            this.NR.DataPropertyName = "NR";
            resources.ApplyResources(this.NR, "NR");
            this.NR.Name = "NR";
            this.NR.ReadOnly = true;
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            this.C_NO.ReadOnly = true;
            // 
            // C_NAME_C
            // 
            this.C_NAME_C.DataPropertyName = "C_NAME_C";
            resources.ApplyResources(this.C_NAME_C, "C_NAME_C");
            this.C_NAME_C.Name = "C_NAME_C";
            this.C_NAME_C.ReadOnly = true;
            // 
            // C_NAME_E
            // 
            this.C_NAME_E.DataPropertyName = "C_NAME_E";
            resources.ApplyResources(this.C_NAME_E, "C_NAME_E");
            this.C_NAME_E.Name = "C_NAME_E";
            this.C_NAME_E.ReadOnly = true;
            // 
            // BRAND
            // 
            this.BRAND.DataPropertyName = "BRAND";
            resources.ApplyResources(this.BRAND, "BRAND");
            this.BRAND.Name = "BRAND";
            this.BRAND.ReadOnly = true;
            // 
            // MODEL_C
            // 
            this.MODEL_C.DataPropertyName = "MODEL_C";
            resources.ApplyResources(this.MODEL_C, "MODEL_C");
            this.MODEL_C.Name = "MODEL_C";
            this.MODEL_C.ReadOnly = true;
            // 
            // MODEL_E
            // 
            this.MODEL_E.DataPropertyName = "MODEL_E";
            resources.ApplyResources(this.MODEL_E, "MODEL_E");
            this.MODEL_E.Name = "MODEL_E";
            this.MODEL_E.ReadOnly = true;
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            this.P_NO.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Name = "label3";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Name = "textBox3";
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Name = "label4";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Name = "textBox4";
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Name = "label5";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Name = "textBox5";
            this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyDown);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Name = "label6";
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Name = "textBox6";
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Name = "label7";
            // 
            // textBox7
            // 
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Name = "textBox7";
            this.textBox7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox7_KeyDown);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.ForeColor = System.Drawing.Color.Navy;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.Name = "txtDate";
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // frm3D_Products
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.DGV3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm3D_Products";
            this.Load += new System.EventHandler(this.frm3D_Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView DGV3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn THICK;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn K_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NR;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.MaskedTextBox txtDate;
    }
}