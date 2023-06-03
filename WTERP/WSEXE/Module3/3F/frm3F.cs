using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WTERP.WSEXE;

namespace WTERP
{
    public partial class frm3F : Form
    {
        DataProvider data = new DataProvider();
        BindingSource source;
        BindingSource bindingSource;
        public frm3F()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }
        private void Form3F_Load(object sender, EventArgs e)
        {
            data.CheckLoad(menuStrip1);
            loadInfo();
            
            f1ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            LoadData();
            btok.Hide();
            btdong.Hide();
            //load date time
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();

        }
        private void LoadData()
        {
            string sql = "";
            if (f5ToolStripMenuItem.Checked == false)
            {
                sql = "SELECT * FROM PRDMK3";
                DataTable data1 = new DataTable();
                data1 = data.readdata(sql);
                source = new BindingSource();
                source.DataSource = data1;
                if (source.Count > 0)
                {
                    //ShowText();
                }
                else
                {
                    ResetText2();
                }
            }
            else
            {
                source.DataSource = frm3FF5.get3FF5.getWS_NO;
                    ShowText();
                //trả lại trạng thái
                f5ToolStripMenuItem.Checked = false;
            }
            
        }
        private void ShowText()
        {
            try
            {
        
                textBox5.Text = currenRow["C_NAME"].ToString();
                textBox6.Text = currenRow["C_ANAME"].ToString();
                textBox7.Text = currenRow["P_NAME"].ToString();
                textBox8.Text = currenRow["MEMO01"].ToString();
                textBox9.Text = string.Format("{0:#,##0.00}", double.Parse(currenRow["BQTY"].ToString()));
                textBox10.Text = currenRow["MEMO02"].ToString();
                textBox11.Text = currenRow["MEMO05"].ToString();
                textBox12.Text = data.formatstr2(currenRow["FOB_DATE"].ToString());
                textBox13.Text = currenRow["MEMO03"].ToString();
                textBox14.Text = currenRow["MEMO04"].ToString();
                textBox18.Text = currenRow["USR_NAME"].ToString();
                textBox19.Text = currenRow["MEMO08"].ToString();
                textBox20.Text = currenRow["PG_NO"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ResetTextbox()
        {
            try
            {
                textBox1.Text = DateTime.Now.ToString("yyyy/MM/dd");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox18.Text = lbUserName.Text;
                textBox19.Text = "";
                textBox20.Text = "NO: TD-QR-20";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ResetText2()
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ResetText_tb3Click()
        {
            try
            {
                string text = (frm3F_Products.Get_WS_DATE);
                textBox1.Text = DateTime.Now.ToString("yyyy/MM/dd");
                textBox2.Text = data.formatstr1(text) + "-" + frm3F_Products.Get_NR;
                textBox3.Text = frm3F_Products.getOR_NO;
                textBox4.Text = frm3F_Products.Get_C_NO;
                textBox5.Text = frm3F_Products.Get_C_NAME_C;
                textBox6.Text = "";
                textBox7.Text = frm3F_Products.Get_P_NAME;
                textBox8.Text = frm3F_Products.Get_THICK;
                textBox9.Text = frm3F_Products.Get_QTY;
                textBox10.Text = "";
                textBox11.Text = frm3F_Products.Get_T_NAME;
                textBox12.Text = data.formatstr2(frm3F_Products.Get_WS_DATE1);
                textBox13.Text = frm3F_Products.Get_COLOR_C;
                textBox14.Text = "";
                textBox18.Text = lbUserName.Text;
                textBox19.Text = "";
                textBox20.Text = "NO: TD-QR-20";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private DataRow currenRow
        {
            get
            {
                    if (f5ToolStripMenuItem.Checked == false)
                    {
                        int position = this.BindingContext[source].Position;
                        if (position > -1)

                        {
                            return ((DataRowView)source.Current).Row;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        int index = source.Find("WS_NO", frm3FF5.get3FF5.getC_NO);
                        if (index >= 0)
                        {
                            source.Position = index;
                            return ((DataRowView)source.Current).Row;
                        }
                        else
                        {
                            return null;
                        }
                    }
             }
          }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaKH = textBox4.Text;
            /// mở tool
            f5ToolStripMenuItem.Checked = true;
            frm3FF5 frm3FF51 = new frm3FF5();
            frm3FF51.ShowDialog();
            LoadData();
        }
        void loadInfo()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER;
            lbUserName.Text = data.getUser(UID);
            lbNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = data.getDateNow();
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox1, textBox2, sender, e);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox1, textBox3, sender, e);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox2, textBox4, sender, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox3, textBox5, sender, e);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox4, textBox6, sender, e);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox5, textBox7, sender, e);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox6, textBox8, sender, e);
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox7, textBox9, sender, e);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox8, textBox10, sender, e);
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox9, textBox11, sender, e);
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox10, textBox12, sender, e);
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox11, textBox13, sender, e);
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox12, textBox14, sender, e);
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox13, textBox18, sender, e);
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox14, textBox19, sender, e);
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox18, textBox20, sender, e);
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox19, textBox20, sender, e);
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check true
            f2ToolStripMenuItem.Checked = true;
            //khóa
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
            //khoas nuts 

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            //resset
            ResetTextbox();
            btok.Show();
            btdong.Show();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            source.MoveFirst();
            ShowText();
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
            ShowText();
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            source.MoveNext();
            ShowText();
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            source.MoveLast();
            ShowText();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;

            btok.Hide();
            btdong.Hide();
            ReturnFunction();
            LoadData();
            ShowText();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                InsertIntoData();
            }
            if (f3ToolStripMenuItem.Checked == true)
            {
                DeleteData();
            }
            if (f4ToolStripMenuItem.Checked == true)
            {
                UpdateData();
            }    
        }
        private void UpdateData()
        {
            try
            {
                string SQLUPDATE = "UPDATE PRDMK3 SET WS_DATE = '" + data.formatstr2(textBox1.Text) + "',WS_NO = '" + textBox2.Text + "',OR_NO = '" + textBox3.Text + "',C_NO = '" + textBox4.Text + "',C_ANAME = '" + textBox6.Text + "',P_NAME = '" + textBox7.Text + "',MEMO01 = '" + textBox8.Text + "'" +
                ",MEMO02 = '" + textBox10.Text + "',MEMO05 = '" + textBox11.Text + "',FOB_DATE = '" + data.formatstr2(textBox12.Text) + "',MEMO03 = '" + textBox13.Text + "',MEMO04 = '" + textBox14.Text + "',USR_NAME = '" + textBox18.Text + "',MEMO08 = '" + textBox19.Text + "'," +
                "PG_NO = '" + textBox20.Text + "',C_NAME = '" + textBox5.Text + "',BQTY = '" + string.Format("{0}", double.Parse(textBox9.Text)) + "' from PRDMK3 where WS_NO = '" + textBox2.Text + "'";
                  bool a = data.exedata(SQLUPDATE);
                if (a == true)
                {
                    MessageBox.Show("Sửa " + textBox2.Text + " Thành Công");
                    ReturnFunction();
                    LoadData();
                    //trả lại
                    f4ToolStripMenuItem.Checked = false;
                    //readonly
                    textBox2.ReadOnly = false;

                }
                else
                {
                    MessageBox.Show("Sửa " + textBox2.Text + " Thất Bại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteData()
        {
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn có xóa " + textBox2.Text + " không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (textBox2.Text != "")
                    {
                        string sql = "DELETE dbo.PRDMK3 WHERE WS_NO = '" + textBox2.Text + "'";
                        bool a = data.exedata(sql);
                        if (a == true)
                        {
                            MessageBox.Show("Xóa Thành Công");
                            LoadData();
                            
                            ReturnFunction();
                            //trả lại
                            f3ToolStripMenuItem.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Xóa Thất Bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng kiểm tra số đơn hàng");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void InsertIntoData()
        {
            try
            {
                
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    string sql1 = "SELECT TOP 1 * FROM ORDB WHERE C_NO = '" + textBox4.Text + "' AND OR_NO = '" + textBox3.Text + "' and NR = '" + frm3F_Products.Get_NR + "'";
                    DataTable dataTable = new DataTable();
                    dataTable = data.readdata(sql1);
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;

                    string sql = "INSERT INTO PRDMK3 (WS_NO,WS_DATE,C_NO,C_NAME,C_ANAME,ADDR,OR_NO,C_OR_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,FOB_DATE,BQTY,MODEL_C,MODEL_E,MEMO01,MEMO02,MEMO03,MEMO04,MEMO05,MEMO06,MEMO07,MEMO08,USR_NAME,OVER0,PG_NO,WS_DATE1,K_NO,NR,WS_ORNO)" +
                        "SELECT '" + textBox2.Text + "','" + data.formatstr2(textBox1.Text) + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','','" + textBox3.Text + "','','" + currenRow2["P_NO"].ToString() + "','" + textBox7.Text + "','" + currenRow2["P_NAME_E"].ToString() + "'" +
                        ",'','','','"+textBox9.Text+"','','','"+textBox8.Text+ "','" + textBox10.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox11.Text + "','','','','"+lbUserName+ "','"+currenRow2["OVER0"].ToString()+"','"+textBox20.Text+"','"+data.formatstr2(textBox12.Text)+"'," +
                        "'"+ currenRow2["K_NO"].ToString() + "','" + currenRow2["NR"].ToString() + "','" + currenRow2["WS_RNO"].ToString() + "'";                  
                    bool a = data.exedata(sql);
                    if (a == true)
                    {
                        MessageBox.Show("Thêm Thành Công");
                        ReturnFunction();
                        //trả lại
                        f2ToolStripMenuItem.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }    
                }
                else
                {
                    MessageBox.Show("Đơn Hàng Không Được Để Trống");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void ReturnFunction()
        {
            f2ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;
            f1ToolStripMenuItem.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            btdong.Hide();
            btok.Hide();
        }
        private DataRow currenRow2
        {
            get
            {

                int position = this.BindingContext[bindingSource].Position;
                if (position > -1)
                {
                    return ((DataRowView)bindingSource.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
           if (f2ToolStripMenuItem.Checked == true)
            {
                frm3F_Products fr = new frm3F_Products();
                fr.ShowDialog();
                MaKH = textBox4.Text;
                ResetText_tb3Click();
            }    
        }
        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch fr = new frm2CustSearch();
                fr.ShowDialog();
                textBox4.Text = frm2CustSearch.ID.ID_CUST;
                textBox5.Text = frm2CustSearch.ID.C_ANAME2;
                ResetText_tb3Click();
            }    
        }
        public static string MaKH;

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check true
            f3ToolStripMenuItem.Checked = true;
            //khóa
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
            //khoas nuts F

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            btok.Show();
            btdong.Show();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check true
            f4ToolStripMenuItem.Checked = true;
            //khóa
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
            //khoas nuts 

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            btok.Show();
            btdong.Show();
            //readonly
            textBox2.ReadOnly = true;
        }
        public static string WS_NO;
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WS_NO = textBox2.Text;
            frm3FF7 frm3FF7 = new frm3FF7();
            frm3FF7.ShowDialog();
        }
    }
}
