
namespace WTERP
{
    partial class frm2IF1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2IF1));
            this.button2 = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.txtP_NAME_E = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtP_NAME_C = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBRAND = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOR_NO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtC_NO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV1 = new WTERP.WSEXE.CustomDGV();
            this.K_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATT_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THICK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWS_DATE = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btok
            // 
            resources.ApplyResources(this.btok, "btok");
            this.btok.Name = "btok";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // txtP_NAME_E
            // 
            resources.ApplyResources(this.txtP_NAME_E, "txtP_NAME_E");
            this.txtP_NAME_E.Name = "txtP_NAME_E";
            this.txtP_NAME_E.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP_NAME_E_KeyDown);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Name = "label7";
            // 
            // txtP_NAME_C
            // 
            resources.ApplyResources(this.txtP_NAME_C, "txtP_NAME_C");
            this.txtP_NAME_C.Name = "txtP_NAME_C";
            this.txtP_NAME_C.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP_NAME_C_KeyDown);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Name = "label6";
            // 
            // txtBRAND
            // 
            resources.ApplyResources(this.txtBRAND, "txtBRAND");
            this.txtBRAND.Name = "txtBRAND";
            this.txtBRAND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBRAND_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Name = "label5";
            // 
            // txtOR_NO
            // 
            resources.ApplyResources(this.txtOR_NO, "txtOR_NO");
            this.txtOR_NO.Name = "txtOR_NO";
            this.txtOR_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOR_NO_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // txtC_NO
            // 
            resources.ApplyResources(this.txtC_NO, "txtC_NO");
            this.txtC_NO.Name = "txtC_NO";
            this.txtC_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtC_NO_KeyDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.K_NO,
            this.WS_DATE,
            this.NR,
            this.OR_NO,
            this.C_NO,
            this.C_NAME_C,
            this.C_NAME_E,
            this.BRAND,
            this.MODEL_C,
            this.MODEL_E,
            this.P_NO,
            this.P_NAME_C,
            this.P_NAME_E,
            this.PATT_C,
            this.PATT_E,
            this.COLOR_C,
            this.COLOR_E,
            this.THICK,
            this.QTY});
            resources.ApplyResources(this.DGV1, "DGV1");
            this.DGV1.Name = "DGV1";
            this.DGV1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV1_CellMouseDoubleClick);
            // 
            // K_NO
            // 
            this.K_NO.DataPropertyName = "K_NO";
            resources.ApplyResources(this.K_NO, "K_NO");
            this.K_NO.Name = "K_NO";
            // 
            // WS_DATE
            // 
            this.WS_DATE.DataPropertyName = "WS_DATE";
            resources.ApplyResources(this.WS_DATE, "WS_DATE");
            this.WS_DATE.Name = "WS_DATE";
            // 
            // NR
            // 
            this.NR.DataPropertyName = "NR";
            resources.ApplyResources(this.NR, "NR");
            this.NR.Name = "NR";
            // 
            // OR_NO
            // 
            this.OR_NO.DataPropertyName = "OR_NO";
            resources.ApplyResources(this.OR_NO, "OR_NO");
            this.OR_NO.Name = "OR_NO";
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            // 
            // C_NAME_C
            // 
            this.C_NAME_C.DataPropertyName = "C_NAME_C";
            resources.ApplyResources(this.C_NAME_C, "C_NAME_C");
            this.C_NAME_C.Name = "C_NAME_C";
            // 
            // C_NAME_E
            // 
            this.C_NAME_E.DataPropertyName = "C_NAME_E";
            resources.ApplyResources(this.C_NAME_E, "C_NAME_E");
            this.C_NAME_E.Name = "C_NAME_E";
            // 
            // BRAND
            // 
            this.BRAND.DataPropertyName = "BRAND";
            resources.ApplyResources(this.BRAND, "BRAND");
            this.BRAND.Name = "BRAND";
            // 
            // MODEL_C
            // 
            this.MODEL_C.DataPropertyName = "MODEL_C";
            resources.ApplyResources(this.MODEL_C, "MODEL_C");
            this.MODEL_C.Name = "MODEL_C";
            // 
            // MODEL_E
            // 
            this.MODEL_E.DataPropertyName = "MODEL_E";
            resources.ApplyResources(this.MODEL_E, "MODEL_E");
            this.MODEL_E.Name = "MODEL_E";
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            // 
            // P_NAME_C
            // 
            this.P_NAME_C.DataPropertyName = "P_NAME_C";
            resources.ApplyResources(this.P_NAME_C, "P_NAME_C");
            this.P_NAME_C.Name = "P_NAME_C";
            // 
            // P_NAME_E
            // 
            this.P_NAME_E.DataPropertyName = "P_NAME_E";
            resources.ApplyResources(this.P_NAME_E, "P_NAME_E");
            this.P_NAME_E.Name = "P_NAME_E";
            // 
            // PATT_C
            // 
            this.PATT_C.DataPropertyName = "PATT_C";
            resources.ApplyResources(this.PATT_C, "PATT_C");
            this.PATT_C.Name = "PATT_C";
            // 
            // PATT_E
            // 
            resources.ApplyResources(this.PATT_E, "PATT_E");
            this.PATT_E.Name = "PATT_E";
            // 
            // COLOR_C
            // 
            this.COLOR_C.DataPropertyName = "COLOR_C";
            resources.ApplyResources(this.COLOR_C, "COLOR_C");
            this.COLOR_C.Name = "COLOR_C";
            // 
            // COLOR_E
            // 
            this.COLOR_E.DataPropertyName = "COLOR_E";
            resources.ApplyResources(this.COLOR_E, "COLOR_E");
            this.COLOR_E.Name = "COLOR_E";
            // 
            // THICK
            // 
            this.THICK.DataPropertyName = "THICK";
            resources.ApplyResources(this.THICK, "THICK");
            this.THICK.Name = "THICK";
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            resources.ApplyResources(this.QTY, "QTY");
            this.QTY.Name = "QTY";
            // 
            // txtWS_DATE
            // 
            resources.ApplyResources(this.txtWS_DATE, "txtWS_DATE");
            this.txtWS_DATE.Name = "txtWS_DATE";
            this.txtWS_DATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWS_DATE_KeyDown);
            this.txtWS_DATE.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtWS_DATE_MouseDoubleClick);
            // 
            // frm2IF1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtWS_DATE);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.txtP_NAME_E);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtP_NAME_C);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBRAND);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOR_NO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtC_NO);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2IF1";
            this.Load += new System.EventHandler(this.frm2IF1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.TextBox txtP_NAME_E;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtP_NAME_C;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBRAND;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOR_NO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtC_NO;
        private System.Windows.Forms.Label label1;
        private WTERP.WSEXE.CustomDGV DGV1;
        private System.Windows.Forms.MaskedTextBox txtWS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn K_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NR;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATT_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn THICK;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
    }
}