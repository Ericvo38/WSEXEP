
namespace WTERP.WSEXE.Module3._3D
{
    partial class FrmChoiceType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoiceType));
            this.btnS = new System.Windows.Forms.Button();
            this.btnL = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnLOI = new System.Windows.Forms.Button();
            this.btnWT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnS
            // 
            this.btnS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.ForeColor = System.Drawing.Color.Maroon;
            this.btnS.Location = new System.Drawing.Point(106, 71);
            this.btnS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(284, 62);
            this.btnS.TabIndex = 0;
            this.btnS.Text = "S 樣品";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnL
            // 
            this.btnL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnL.ForeColor = System.Drawing.Color.Maroon;
            this.btnL.Location = new System.Drawing.Point(106, 145);
            this.btnL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnL.Name = "btnL";
            this.btnL.Size = new System.Drawing.Size(284, 62);
            this.btnL.TabIndex = 1;
            this.btnL.Text = "L  量產";
            this.btnL.UseVisualStyleBackColor = true;
            this.btnL.Click += new System.EventHandler(this.btnL_Click);
            // 
            // btnD
            // 
            this.btnD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnD.ForeColor = System.Drawing.Color.Maroon;
            this.btnD.Location = new System.Drawing.Point(106, 292);
            this.btnD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(284, 62);
            this.btnD.TabIndex = 3;
            this.btnD.Text = "D  開發 展覽";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // btnLOI
            // 
            this.btnLOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLOI.ForeColor = System.Drawing.Color.Maroon;
            this.btnLOI.Location = new System.Drawing.Point(106, 218);
            this.btnLOI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLOI.Name = "btnLOI";
            this.btnLOI.Size = new System.Drawing.Size(284, 62);
            this.btnLOI.TabIndex = 2;
            this.btnLOI.Text = "LOI  預做";
            this.btnLOI.UseVisualStyleBackColor = true;
            this.btnLOI.Click += new System.EventHandler(this.btnLOI_Click);
            // 
            // btnWT
            // 
            this.btnWT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWT.ForeColor = System.Drawing.Color.Maroon;
            this.btnWT.Location = new System.Drawing.Point(106, 366);
            this.btnWT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWT.Name = "btnWT";
            this.btnWT.Size = new System.Drawing.Size(284, 62);
            this.btnWT.TabIndex = 4;
            this.btnWT.Text = "WT  本廠皮胚";
            this.btnWT.UseVisualStyleBackColor = true;
            this.btnWT.Click += new System.EventHandler(this.btnWT_Click);
            // 
            // FrmChoiceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 515);
            this.Controls.Add(this.btnWT);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnLOI);
            this.Controls.Add(this.btnL);
            this.Controls.Add(this.btnS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChoiceType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Type";
            this.Load += new System.EventHandler(this.FrmChoiceType_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnL;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnLOI;
        private System.Windows.Forms.Button btnWT;
    }
}