
namespace WTERP.WSEXE
{
    partial class frm2R
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2R));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CHECK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THICK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.f2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.Location = new System.Drawing.Point(1039, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "圓";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(927, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại Giản ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK,
            this.WS_DATE,
            this.OR_NO,
            this.NR,
            this.K_NO,
            this.C_NO,
            this.C_NAME_E,
            this.T_NAME,
            this.P_NO,
            this.P_NAME_E,
            this.COLOR_E,
            this.THICK});
            this.dataGridView1.Location = new System.Drawing.Point(10, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1556, 707);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // CHECK
            // 
            this.CHECK.DataPropertyName = "CHECK";
            this.CHECK.HeaderText = "CHỌN";
            this.CHECK.MinimumWidth = 6;
            this.CHECK.Name = "CHECK";
            this.CHECK.ReadOnly = true;
            this.CHECK.Width = 125;
            // 
            // WS_DATE
            // 
            this.WS_DATE.DataPropertyName = "WS_DATE";
            this.WS_DATE.HeaderText = "NGÀY NHẬP ĐƠN";
            this.WS_DATE.MinimumWidth = 6;
            this.WS_DATE.Name = "WS_DATE";
            this.WS_DATE.ReadOnly = true;
            this.WS_DATE.Width = 125;
            // 
            // OR_NO
            // 
            this.OR_NO.DataPropertyName = "OR_NO";
            this.OR_NO.HeaderText = "MÃ SẢN PHẨM";
            this.OR_NO.MinimumWidth = 6;
            this.OR_NO.Name = "OR_NO";
            this.OR_NO.ReadOnly = true;
            this.OR_NO.Width = 125;
            // 
            // NR
            // 
            this.NR.DataPropertyName = "NR";
            this.NR.HeaderText = "STT";
            this.NR.MinimumWidth = 6;
            this.NR.Name = "NR";
            this.NR.ReadOnly = true;
            this.NR.Width = 125;
            // 
            // K_NO
            // 
            this.K_NO.DataPropertyName = "K_NO";
            this.K_NO.HeaderText = "LOẠI DA";
            this.K_NO.MinimumWidth = 6;
            this.K_NO.Name = "K_NO";
            this.K_NO.ReadOnly = true;
            this.K_NO.Width = 125;
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            this.C_NO.HeaderText = "MÃ KHÁCH HÀNG";
            this.C_NO.MinimumWidth = 6;
            this.C_NO.Name = "C_NO";
            this.C_NO.ReadOnly = true;
            this.C_NO.Width = 125;
            // 
            // C_NAME_E
            // 
            this.C_NAME_E.DataPropertyName = "C_NAME_E";
            this.C_NAME_E.HeaderText = "TÊN KHÁCH HÀNG";
            this.C_NAME_E.MinimumWidth = 6;
            this.C_NAME_E.Name = "C_NAME_E";
            this.C_NAME_E.ReadOnly = true;
            this.C_NAME_E.Width = 125;
            // 
            // T_NAME
            // 
            this.T_NAME.DataPropertyName = "T_NAME";
            this.T_NAME.HeaderText = "NHÃN HIỆU";
            this.T_NAME.MinimumWidth = 6;
            this.T_NAME.Name = "T_NAME";
            this.T_NAME.ReadOnly = true;
            this.T_NAME.Width = 125;
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            this.P_NO.HeaderText = "MÃ SẢN PHẨM";
            this.P_NO.MinimumWidth = 6;
            this.P_NO.Name = "P_NO";
            this.P_NO.ReadOnly = true;
            this.P_NO.Width = 125;
            // 
            // P_NAME_E
            // 
            this.P_NAME_E.DataPropertyName = "P_NAME_E";
            this.P_NAME_E.HeaderText = "TÊN SẢN PHẨM";
            this.P_NAME_E.MinimumWidth = 6;
            this.P_NAME_E.Name = "P_NAME_E";
            this.P_NAME_E.ReadOnly = true;
            this.P_NAME_E.Width = 125;
            // 
            // COLOR_E
            // 
            this.COLOR_E.DataPropertyName = "COLOR_E";
            this.COLOR_E.HeaderText = "TÊN MÀU SẮC";
            this.COLOR_E.MinimumWidth = 6;
            this.COLOR_E.Name = "COLOR_E";
            this.COLOR_E.ReadOnly = true;
            this.COLOR_E.Width = 125;
            // 
            // THICK
            // 
            this.THICK.DataPropertyName = "THICK";
            this.THICK.HeaderText = "DỘ DÀY";
            this.THICK.MinimumWidth = 6;
            this.THICK.Name = "THICK";
            this.THICK.ReadOnly = true;
            this.THICK.Width = 125;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedTextBox1.Location = new System.Drawing.Point(105, 54);
            this.maskedTextBox1.Mask = "00/00/00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(335, 30);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedTextBox2.Location = new System.Drawing.Point(551, 54);
            this.maskedTextBox2.Mask = "00/00/00";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(349, 30);
            this.maskedTextBox2.TabIndex = 4;
            this.maskedTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ Ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(446, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đến Ngày";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Location = new System.Drawing.Point(1215, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 43);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.ForeColor = System.Drawing.Color.Brown;
            this.button2.Location = new System.Drawing.Point(1398, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 43);
            this.button2.TabIndex = 8;
            this.button2.Text = "ĐÓNG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBox1.Location = new System.Drawing.Point(12, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 24);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Chọn tất cả";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.f2ToolStripMenuItem,
            this.f12ToolStripMenuItem,
            this.f1ToolStripMenuItem,
            this.f3ToolStripMenuItem,
            this.f4ToolStripMenuItem,
            this.f5ToolStripMenuItem,
            this.f6ToolStripMenuItem,
            this.f7ToolStripMenuItem,
            this.f9ToolStripMenuItem,
            this.f10ToolStripMenuItem,
            this.f11ToolStripMenuItem,
            this.f8ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1580, 32);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // f2ToolStripMenuItem
            // 
            this.f2ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f2ToolStripMenuItem.Image")));
            this.f2ToolStripMenuItem.Name = "f2ToolStripMenuItem";
            this.f2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.f2ToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.f2ToolStripMenuItem.Text = "F2. Thêm";
            this.f2ToolStripMenuItem.Click += new System.EventHandler(this.f2ToolStripMenuItem_Click);
            // 
            // f12ToolStripMenuItem
            // 
            this.f12ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f12ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f12ToolStripMenuItem.Image")));
            this.f12ToolStripMenuItem.Name = "f12ToolStripMenuItem";
            this.f12ToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.f12ToolStripMenuItem.Text = "F12. Kết thúc";
            this.f12ToolStripMenuItem.Click += new System.EventHandler(this.f12ToolStripMenuItem_Click);
            // 
            // f1ToolStripMenuItem
            // 
            this.f1ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f1ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f1ToolStripMenuItem.Image")));
            this.f1ToolStripMenuItem.Name = "f1ToolStripMenuItem";
            this.f1ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.f1ToolStripMenuItem.Size = new System.Drawing.Size(134, 28);
            this.f1ToolStripMenuItem.Text = "F1. Kiểm Tra";
            this.f1ToolStripMenuItem.Visible = false;
            // 
            // f3ToolStripMenuItem
            // 
            this.f3ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f3ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f3ToolStripMenuItem.Image")));
            this.f3ToolStripMenuItem.Name = "f3ToolStripMenuItem";
            this.f3ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.f3ToolStripMenuItem.Size = new System.Drawing.Size(99, 28);
            this.f3ToolStripMenuItem.Text = "F3. Xóa";
            this.f3ToolStripMenuItem.Visible = false;
            // 
            // f4ToolStripMenuItem
            // 
            this.f4ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f4ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f4ToolStripMenuItem.Image")));
            this.f4ToolStripMenuItem.Name = "f4ToolStripMenuItem";
            this.f4ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.f4ToolStripMenuItem.Text = "F4. Sửa";
            this.f4ToolStripMenuItem.Visible = false;
            // 
            // f5ToolStripMenuItem
            // 
            this.f5ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f5ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f5ToolStripMenuItem.Image")));
            this.f5ToolStripMenuItem.Name = "f5ToolStripMenuItem";
            this.f5ToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.f5ToolStripMenuItem.Text = "F5. Tìm Kiếm";
            this.f5ToolStripMenuItem.Visible = false;
            // 
            // f6ToolStripMenuItem
            // 
            this.f6ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f6ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f6ToolStripMenuItem.Image")));
            this.f6ToolStripMenuItem.Name = "f6ToolStripMenuItem";
            this.f6ToolStripMenuItem.Size = new System.Drawing.Size(107, 28);
            this.f6ToolStripMenuItem.Text = "F6. Copy";
            this.f6ToolStripMenuItem.Visible = false;
            // 
            // f7ToolStripMenuItem
            // 
            this.f7ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f7ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f7ToolStripMenuItem.Image")));
            this.f7ToolStripMenuItem.Name = "f7ToolStripMenuItem";
            this.f7ToolStripMenuItem.Size = new System.Drawing.Size(86, 28);
            this.f7ToolStripMenuItem.Text = "F7. In";
            this.f7ToolStripMenuItem.Visible = false;
            // 
            // f9ToolStripMenuItem
            // 
            this.f9ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f9ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f9ToolStripMenuItem.Image")));
            this.f9ToolStripMenuItem.Name = "f9ToolStripMenuItem";
            this.f9ToolStripMenuItem.Size = new System.Drawing.Size(108, 28);
            this.f9ToolStripMenuItem.Text = "F9. Chọn";
            this.f9ToolStripMenuItem.Visible = false;
            // 
            // f10ToolStripMenuItem
            // 
            this.f10ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f10ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f10ToolStripMenuItem.Image")));
            this.f10ToolStripMenuItem.Name = "f10ToolStripMenuItem";
            this.f10ToolStripMenuItem.Size = new System.Drawing.Size(108, 28);
            this.f10ToolStripMenuItem.Text = "F10. Lưu";
            this.f10ToolStripMenuItem.Visible = false;
            // 
            // f11ToolStripMenuItem
            // 
            this.f11ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f11ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f11ToolStripMenuItem.Image")));
            this.f11ToolStripMenuItem.Name = "f11ToolStripMenuItem";
            this.f11ToolStripMenuItem.Size = new System.Drawing.Size(119, 28);
            this.f11ToolStripMenuItem.Text = "F11. Đóng";
            this.f11ToolStripMenuItem.Visible = false;
            // 
            // f8ToolStripMenuItem
            // 
            this.f8ToolStripMenuItem.Name = "f8ToolStripMenuItem";
            this.f8ToolStripMenuItem.Size = new System.Drawing.Size(38, 28);
            this.f8ToolStripMenuItem.Text = "F8";
            this.f8ToolStripMenuItem.Visible = false;
            // 
            // frm2R
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1580, 849);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2R";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yuan Đơn";
            this.Load += new System.EventHandler(this.frm2R_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NR;
        private System.Windows.Forms.DataGridViewTextBoxColumn K_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn T_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn THICK;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem f1ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f2ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f3ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f4ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f5ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f6ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f7ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f9ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f11ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem f12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f8ToolStripMenuItem;
    }
}