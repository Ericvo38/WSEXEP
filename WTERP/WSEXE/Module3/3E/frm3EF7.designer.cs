
using WTERP;

namespace WTERP
{
    partial class Form3EF7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3EF7));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.f1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb4 = new System.Windows.Forms.MaskedTextBox();
            this.tb3 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdMau_New = new System.Windows.Forms.RadioButton();
            this.radio_barcode = new System.Windows.Forms.RadioButton();
            this.radio_mau = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dsForm3EF71 = new WTERP.DsForm3EF7();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm3EF71)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.f1ToolStripMenuItem,
            this.f2ToolStripMenuItem,
            this.f9ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // f1ToolStripMenuItem
            // 
            resources.ApplyResources(this.f1ToolStripMenuItem, "f1ToolStripMenuItem");
            this.f1ToolStripMenuItem.Name = "f1ToolStripMenuItem";
            this.f1ToolStripMenuItem.Click += new System.EventHandler(this.f1ToolStripMenuItem_Click);
            // 
            // f2ToolStripMenuItem
            // 
            resources.ApplyResources(this.f2ToolStripMenuItem, "f2ToolStripMenuItem");
            this.f2ToolStripMenuItem.Name = "f2ToolStripMenuItem";
            this.f2ToolStripMenuItem.Click += new System.EventHandler(this.f2ToolStripMenuItem_Click);
            // 
            // f9ToolStripMenuItem
            // 
            resources.ApplyResources(this.f9ToolStripMenuItem, "f9ToolStripMenuItem");
            this.f9ToolStripMenuItem.Name = "f9ToolStripMenuItem";
            this.f9ToolStripMenuItem.Click += new System.EventHandler(this.f9ToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.Brown;
            this.textBox1.Name = "textBox1";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.tb4);
            this.tabPage1.Controls.Add(this.tb3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tb2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tb1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ForeColor = System.Drawing.Color.Brown;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb4
            // 
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb4.Name = "tb4";
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            this.tb4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tb4_MouseDoubleClick);
            // 
            // tb3
            // 
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb3.Name = "tb3";
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            this.tb3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tb3_MouseDoubleClick);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rdMau_New);
            this.groupBox1.Controls.Add(this.radio_barcode);
            this.groupBox1.Controls.Add(this.radio_mau);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdMau_New
            // 
            resources.ApplyResources(this.rdMau_New, "rdMau_New");
            this.rdMau_New.ForeColor = System.Drawing.Color.Black;
            this.rdMau_New.Name = "rdMau_New";
            this.rdMau_New.UseVisualStyleBackColor = true;
            // 
            // radio_barcode
            // 
            resources.ApplyResources(this.radio_barcode, "radio_barcode");
            this.radio_barcode.ForeColor = System.Drawing.Color.Black;
            this.radio_barcode.Name = "radio_barcode";
            this.radio_barcode.UseVisualStyleBackColor = true;
            // 
            // radio_mau
            // 
            resources.ApplyResources(this.radio_mau, "radio_mau");
            this.radio_mau.Checked = true;
            this.radio_mau.ForeColor = System.Drawing.Color.Black;
            this.radio_mau.Name = "radio_mau";
            this.radio_mau.TabStop = true;
            this.radio_mau.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Name = "label3";
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb2.Name = "tb2";
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            this.tb2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tb2_MouseDoubleClick);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Name = "label2";
            // 
            // tb1
            // 
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb1.Name = "tb1";
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            this.tb1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tb1_MouseDoubleClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Name = "label1";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.Color.ForestGreen;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dsForm3EF71
            // 
            this.dsForm3EF71.DataSetName = "DsForm3EF7";
            this.dsForm3EF71.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form3EF7
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3EF7";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm3EF71)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem f1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f9ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_mau;
        private System.Windows.Forms.RadioButton radio_barcode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private DsForm3EF7 dsForm3EF71;
        private System.Windows.Forms.RadioButton rdMau_New;
        private System.Windows.Forms.MaskedTextBox tb4;
        private System.Windows.Forms.MaskedTextBox tb3;
        public System.Windows.Forms.TextBox tb2;
        public System.Windows.Forms.TextBox tb1;
    }
}