using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP.FormCenter
{
    public partial class BackUpDatabase : Form
    {
        DataProvider conn = new DataProvider();
        string fileName;
        public BackUpDatabase()
        {
            InitializeComponent();
        }
        DataProvider data = new DataProvider();
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "data files (*.bak)|*.bak|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                textBox3.Text = fileName;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string index = comboBox1.SelectedIndex.ToString();
            if (index == "0")
            {
                getNameID();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phần mềm!");
            }
        }
        void getNameID()
        {
            if (textBox4.Text != "")
            {
                string str = "Select USER_ID,NAME,PAS_WORD FROM USRH WHERE USER_ID ='" + textBox4.Text + "' and PAS_WORD = '" + textBox1.Text + "'";
                DataTable dt1 = conn.readdata(str);
                if (dt1.Rows.Count > 0)
                    foreach (DataRow dr in dt1.Rows)
                    {
                        label7.Text = "User: " + dr["NAME"].ToString();
                        textBox4.Text = dr["USER_ID"].ToString();
                        textBox1.Text = dr["PAS_WORD"].ToString();
                    }
                else
                {
                    textBox4.Focus();
                    textBox1.Text = "";
                    label7.Text = "";
                    MessageBox.Show("Vui lòng kiểm tra lại tài khoản mật khẩu!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tài khoản mật khẩu!");
            }
        }
        private void BackUpDatabase_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            comboBox1.Focus();
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox4, textBox1, sender, e);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }

        }
        int count = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                progressBar1.Value = 0;
                count = 0;
                try
                {
                    timer1.Start();
                    button2.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không được để trống thông tin");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            try
            {
                if (count >= 0 && count < 100)
                {
                    progressBar1.Value = count;
                    label4.Text = progressBar1.Value.ToString() + "%";
                    count++;
                }
                else if (count == 100)
                {
                    timer1.Stop();
                    progressBar1.Value = count;
                    label4.Text = progressBar1.Value.ToString() + "%";

                    string query = "Backup database J2BKPV to disk='" + fileName + "'";
                    bool a = conn.exedata(query);
                    if (a == true)
                    {
                        MessageBox.Show("Thành công!!");
                        SaveHistory();
                        button2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveHistory()
        {
            string sql = "";
            try
            {
                sql = "INSERT INTO dbo.tblHistory_BackUp(USER_ID,Program,LinkDownload,ToDay) " +
                "Select '" + textBox4.Text + "','" + comboBox1.Text.ToString() + "','" + fileName + "',GETDATE()";
                bool a = conn.exedata(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
