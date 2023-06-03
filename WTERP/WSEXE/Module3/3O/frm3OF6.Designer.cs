
namespace WTERP.WSEXE
{
    partial class frm3OF6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm3OF6));
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtC_NO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOke = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.DATECREATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.CNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THICKNESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInvoice
            // 
            this.txtInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtInvoice.Location = new System.Drawing.Point(139, 26);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(285, 30);
            this.txtInvoice.TabIndex = 0;
            this.txtInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoice_KeyDown);
            // 
            // txtC_NO
            // 
            this.txtC_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtC_NO.Location = new System.Drawing.Point(595, 16);
            this.txtC_NO.Name = "txtC_NO";
            this.txtC_NO.Size = new System.Drawing.Size(322, 30);
            this.txtC_NO.TabIndex = 1;
            this.txtC_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtC_NO_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "INVOICE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(430, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(462, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày Xuất";
            // 
            // btnOke
            // 
            this.btnOke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnOke.ForeColor = System.Drawing.Color.Red;
            this.btnOke.Location = new System.Drawing.Point(923, 15);
            this.btnOke.Name = "btnOke";
            this.btnOke.Size = new System.Drawing.Size(207, 34);
            this.btnOke.TabIndex = 6;
            this.btnOke.Text = "OK";
            this.btnOke.UseVisualStyleBackColor = true;
            this.btnOke.Click += new System.EventHandler(this.btnOke_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.Red;
            this.btnHuy.Location = new System.Drawing.Point(923, 61);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(207, 34);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "CANCEL";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DATECREATE,
            this.INVOICE,
            this.C_NO});
            this.DGV1.Location = new System.Drawing.Point(25, 110);
            this.DGV1.Name = "DGV1";
            this.DGV1.RowHeadersWidth = 51;
            this.DGV1.RowTemplate.Height = 24;
            this.DGV1.Size = new System.Drawing.Size(1105, 208);
            this.DGV1.TabIndex = 8;
            this.DGV1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellDoubleClick);
            this.DGV1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV1_CellMouseClick);
            // 
            // DATECREATE
            // 
            this.DATECREATE.DataPropertyName = "DATECREATE";
            this.DATECREATE.HeaderText = "Ngày Xuất";
            this.DATECREATE.MinimumWidth = 6;
            this.DATECREATE.Name = "DATECREATE";
            this.DATECREATE.ReadOnly = true;
            // 
            // INVOICE
            // 
            this.INVOICE.DataPropertyName = "INVOICE";
            this.INVOICE.HeaderText = "INVOICE";
            this.INVOICE.MinimumWidth = 6;
            this.INVOICE.Name = "INVOICE";
            this.INVOICE.ReadOnly = true;
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            this.C_NO.HeaderText = "Mã Khách Hàng";
            this.C_NO.MinimumWidth = 6;
            this.C_NO.Name = "C_NO";
            this.C_NO.ReadOnly = true;
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNO,
            this.OR_NO,
            this.DESCRIPTION,
            this.THICKNESS,
            this.QTY,
            this.NW,
            this.GW});
            this.DGV2.Location = new System.Drawing.Point(24, 324);
            this.DGV2.Name = "DGV2";
            this.DGV2.RowHeadersWidth = 51;
            this.DGV2.RowTemplate.Height = 24;
            this.DGV2.Size = new System.Drawing.Size(1105, 402);
            this.DGV2.TabIndex = 9;
            // 
            // CNO
            // 
            this.CNO.HeaderText = "NO";
            this.CNO.MinimumWidth = 6;
            this.CNO.Name = "CNO";
            // 
            // OR_NO
            // 
            this.OR_NO.DataPropertyName = "OR_NO";
            this.OR_NO.HeaderText = "MÃ ĐƠN HÀNG";
            this.OR_NO.MinimumWidth = 6;
            this.OR_NO.Name = "OR_NO";
            this.OR_NO.ReadOnly = true;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.DataPropertyName = "DESCRIPTION";
            this.DESCRIPTION.HeaderText = "MÔ TẢ";
            this.DESCRIPTION.MinimumWidth = 6;
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.ReadOnly = true;
            // 
            // THICKNESS
            // 
            this.THICKNESS.DataPropertyName = "THICKNESS";
            this.THICKNESS.HeaderText = "ĐỘ DÀY";
            this.THICKNESS.MinimumWidth = 6;
            this.THICKNESS.Name = "THICKNESS";
            this.THICKNESS.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "SỐ LƯỢNG";
            this.QTY.MinimumWidth = 6;
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // NW
            // 
            this.NW.DataPropertyName = "NW";
            this.NW.HeaderText = "NW";
            this.NW.MinimumWidth = 6;
            this.NW.Name = "NW";
            this.NW.ReadOnly = true;
            // 
            // GW
            // 
            this.GW.DataPropertyName = "GW";
            this.GW.HeaderText = "GW";
            this.GW.MinimumWidth = 6;
            this.GW.Name = "GW";
            this.GW.ReadOnly = true;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtDate.Location = new System.Drawing.Point(586, 59);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(329, 30);
            this.txtDate.TabIndex = 10;
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            this.txtDate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDate_MouseDoubleClick);
            // 
            // frm3OF6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1165, 756);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtC_NO);
            this.Controls.Add(this.txtInvoice);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm3OF6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM INVOICE";
            this.Load += new System.EventHandler(this.frm3NF6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtC_NO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOke;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATECREATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn THICKNESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn NW;
        private System.Windows.Forms.DataGridViewTextBoxColumn GW;
    }
}