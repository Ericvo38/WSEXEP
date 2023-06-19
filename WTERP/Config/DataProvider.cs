using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;
using WTERP.Properties;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    class DataProvider
    {
        public string LinkTemplate = @"\\192.168.0.5\Data weitai\IT\Hoang\Long\Template\";
        public string LinkTemplate_SAVE = @"C:\Template_Save\";
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        SqlTransaction transaction1;
        SqlCommand command1;
        public string user_id = "";
        public int RowIndexs;
        public void OpentTransaction()
        {
            if (connect.State == ConnectionState.Closed)
            {
                Openconnect();
                //////bắt đầu quá trình quản lý transaction
                command1 = connect.CreateCommand();
                transaction1 = connect.BeginTransaction();
                command1.Connection = connect;
                command1.Transaction = transaction1;
            }
        }
        public Boolean ExecuteTransaction(string cmd)
        {
            Boolean check = false;
            try
            {
                command1.CommandText = cmd;
                command1.ExecuteNonQuery();
                check = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("Lỗi trong lúc thực thi câu lệnh kiểm tra lại");
                check = false;
            }
            return check;
        }
        public bool Transaction(string Sql1, string Sql2)
        {
            Openconnect();
            bool chek = false;
            SqlTransaction transaction = connect.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql1, connect, transaction);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(Sql2, connect, transaction);
                cmd.ExecuteNonQuery();
                transaction.Commit();
                chek = true;
            }
            catch (Exception err)
            {
                transaction.Rollback();
                chek = false;
                MessageBox.Show(err.Message);
            }
            Closeconnect();
            return chek;
        }
        public bool CloseTransaction(bool check)
        {
            bool check1 = false;
            try
            {
                if (check == false)
                {
                    transaction1.Rollback();
                    check1 = false;
                }
                else
                {
                    transaction1.Commit();
                    check1 = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Closeconnect();
            return check1;
        }
        public DataTable ReaddataTransaction(string cmd) // fill DataTable
        {
            DataTable da = new DataTable();
            try
            {
                try
                {
                    SqlCommand sc = new SqlCommand(cmd, connect);
                    sc.Transaction = transaction1;
                    SqlDataAdapter sda = new SqlDataAdapter(sc);
                    sda.Fill(da);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    da = null;
                }
                return da;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                da = null;
            }
            return da;
        }      
        public void Openconnect() // Open Connect SQL 
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
        }
        public void Closeconnect() // Close Connect SQL 
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
        public Boolean exedata(string cmd) // Check static UPDATE, INSERT , DELETE 
        {
            Openconnect();
            //SqlTransaction transaction;
            //////bắt đầu quá trình quản lý transaction
            //transaction = connect.BeginTransaction();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connect);
                //gắn transaction với đối tượng cmd
                //sc.Transaction = transaction;
                sc.ExecuteNonQuery();
                check = true;
                //transaction.Commit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //transaction.Rollback(); //quay lùi
                check = false;
            }
            Closeconnect();
            return check;
        }

        public DataTable readdata(string cmd) // fill DataTable
        {
            Openconnect();
            DataTable da = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connect);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(da);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da = null;
            }
            Closeconnect();
            return da;
        }
        public string ExecuteScalar(string cmd) // Result a string
        {
            Openconnect();
            string Result = "";
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connect);
                if (!string.IsNullOrEmpty(sc.ExecuteScalar() + ""))
                    Result = sc.ExecuteScalar().ToString();
                //Result = (string)sc.ExecuteScalar();
            }
            catch (Exception err)
            {
                Result = string.Empty;
                MessageBox.Show("Error loi:\n" + err,"Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            Closeconnect();
            return Result;
        }
        public string getID(string username, string pass) // Login And get ID Use 
        {
            string id = "";
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM USRH WHERE USER_ID ='" + username + "' and PAS_WORD='" + pass + "'", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["USER_ID"].ToString().Trim();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                connect.Close();
            }
            return id;
        }

        public string getUser(string ID) // get User Name 
        {
            string USER = "";
            try
            {
                connect.Open();
                DataTable data = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * FROM USRH WHERE USER_ID ='" + ID + "'", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        USER = dr["NAME"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                connect.Close();
            }
            return USER;
        }
        
        public string ID(string SQL, string ID) // get User Name 
        {
            string Result = "";
            try
            {
                connect.Open();
                DataTable data = new DataTable();
                SqlCommand cmd = new SqlCommand(SQL, connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Result = dr[ID].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                connect.Close();
            }
            return Result;
        }
        public bool IsNumber(string pValue) // Kiem Tra Số hay Không 
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public String getDateNow() // Get Date Now 
        {
            string today = "Year: " + DateTime.Now.Year.ToString() + " Month: " + DateTime.Now.Month.ToString() + " Day: " + DateTime.Now.Day.ToString();
            if (GetLangdefaul() == 0)
            {
                today = "Năm: " + DateTime.Now.Year.ToString() + " Tháng: " + DateTime.Now.Month.ToString() + " Ngày: " + DateTime.Now.Day.ToString();
            }
            else if (GetLangdefaul() == 1)
            {
                today = "Year: " + DateTime.Now.Year.ToString() + " Month: " + DateTime.Now.Month.ToString() + " Day: " + DateTime.Now.Day.ToString();
            }
            else if (GetLangdefaul() == 2)
            {
                today = "五: " + DateTime.Now.Year.ToString() + " 月: " + DateTime.Now.Month.ToString() + " 日: " + DateTime.Now.Day.ToString();
            }
            else
            {
                today = "Năm: " + DateTime.Now.Year.ToString() + " Tháng: " + DateTime.Now.Month.ToString() + " Ngày: " + DateTime.Now.Day.ToString();
            }
            return today;
        }
        public string getTimeNow() //Get Time Now
        {
            string timenow = "Now: " + DateTime.Now.Year.ToString() + " Minute: " + DateTime.Now.Month.ToString() + " Seconds: " + DateTime.Now.Day.ToString();
            if (GetLangdefaul() == 0)
            {
                timenow = "Bây Giờ: " + DateTime.Now.Hour.ToString() + " Phút: " + DateTime.Now.Minute.ToString() + " Giây: " + DateTime.Now.Second.ToString();
            }
            else if (GetLangdefaul() == 1)
            {
                timenow = "Now: " + DateTime.Now.Year.ToString() + " Minute: " + DateTime.Now.Month.ToString() + " Seconds: " + DateTime.Now.Day.ToString();
            }
            else if (GetLangdefaul() == 2)
            {
                timenow = "現在: " + DateTime.Now.Year.ToString() + " 分鐘: " + DateTime.Now.Month.ToString() + " 第二: " + DateTime.Now.Day.ToString();
            }
            else
            {
                timenow = "Bây Giờ: " + DateTime.Now.Hour.ToString() + " Phút: " + DateTime.Now.Minute.ToString() + " Giây: " + DateTime.Now.Second.ToString();
            }
            return timenow;
        }
        public string GetIPAddrees()// Get Ip Address Local 
        {
            string IP = "";
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    IP = address.ToString();
            }
            return IP;
        }
        public string formatstr1(string str1) // Format YY  
        {
            string Result = str1;
            if (str1 == string.Empty)
            {
                return Result;
            }
            else if (Result.Length == 5)
            {
                //Format String yy/MM to yyMM
                Result = Result.Remove(Result.Length - 3, 1);
                return Result;
            }
            else if (Result.Length == 4)
            {
                //Format String yyMM to yy/MM
                Result = Result.Insert(Result.Length - 2, "/");
                return Result;
            }
            else if (Result.Length == 6)
            {
                //Format String yyMMdd to yyyy/MM/dd
                Result = Result.Insert(Result.Length - 2, "/");
                Result = Result.Insert(Result.Length - 5, "/");
                return Result;
            }
            else if (Result.Length == 8)
            {
                //Format String yy/MM/dd to yyMMdd
                Result = Result.Remove(Result.Length - 3, 1);
                Result = Result.Remove(Result.Length - 5, 1);
                return Result;
            }


            else
            {
                //essageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return Result = "";
            }
            //return Result;
        }
        public string formatstr2(string str1) // Format YYYY  
        {
            string Result = str1;
            if (str1 == string.Empty)
            {
                return Result = "";
            }
            else if (Result.Length == 6)
            {
                //Format String yyyyMM= to yyyy/MM
                Result = Result.Insert(Result.Length - 2, "/");
                return Result;
            }
            else if (Result.Length == 7)
            {
                //Format String yyyy/MM to yyyyMM
                Result = Result.Remove(Result.Length - 3, 1);
                return Result;
            }
            else if (Result.Length == 8)
            {
                //Format String yyMMyyyyMMdd to yyyy/MM/dd
                Result = Result.Insert(Result.Length - 2, "/");
                Result = Result.Insert(Result.Length - 5, "/");
                return Result;
            }
            else if (Result.Length == 10)
            {
                //Format String yyyy/MM/dd to yyyyMMdd
                Result = Result.Remove(Result.Length - 3, 1);
                Result = Result.Remove(Result.Length - 5, 1);
                return Result;
            }
            else
            {
                // MessageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại","Thông Báo",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return Result = str1;
            }
            // return Result;
        }
        public string formatstr3(string str1) // Format MM/dd
        {
            string Result = str1;
            if (str1 == string.Empty)
            {
                return Result = "";
            }
            else if (Result.Length > 4)
            {
                Result = Result.Substring(Result.Length - 4, 4);
                Result = Result.Insert(Result.Length - 2, "/");
                return Result;
            }
            else
            {
                // MessageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại","Thông Báo",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return Result = str1;
            }
            // return Result;
        }
        public void DGV(DataGridView NameDGV)
        {
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);
            // NameDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void FormatDGV(DataGridView NameDGV, DataTable dt)
        {
            NameDGV.DataSource = dt;
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);
        }
        public void FormatDGVbindingsource(DataGridView NameDGV, BindingSource dt)
        {
            NameDGV.DataSource = dt;
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);
        }
        public void DGV1(DataGridView NameDGV)
        {
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);

        }
        public string Moneys(string n)
        {
            if (n == "EUR")
                n = "歐元";
            if (n == "NTD")
                n = "台幣";
            if (n == "USD")
                n = "美元";
            if (n == "VND")
                n = "越南盾";
            return n;
        }
        public string FormatNumber(string Number)
        {
            Number = string.Format("{0:#,##0.00}", Number);
            return Number;
        }
        public void tab_Combobox(TextBox txtUp, ComboBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }    
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }    
                
        }
        public void tab_Button(TextBox txtUp, Button txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtDown.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }    
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        public void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }    
            if (e.KeyCode == Keys.Right)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }    
        }
        public void tab_UP(MaskedTextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Right)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }
        }
        public void tab_DOWN(TextBox txtUp, MaskedTextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Right)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }
        }
        public void tab_UP_DOWN(MaskedTextBox txtUp, MaskedTextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Right)
            {
                txtDown.Focus();
                txtDown.SelectAll();
            }
        }

        public bool Check_MaskedText(MaskedTextBox maskedTextBox)
        {
            // string a = "";
            if (maskedTextBox.MaskFull)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Check_Decentralization(string cmd)
        {
            bool check = false;
            string ID_USER = frmLogin.ID_USER;
            string SQL = "SELECT TOP 1 case when USRH.SUPER = 0 " +
                " THEN(case when P_USE = 1 then 'True' else 'False' end) " +
                " ELSE 'True' end as PUSE from USRB_NEW " +
                " INNER join USRH on USRH.USER_ID = USRB_NEW.USER_ID" +
                " INNER JOIN FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                " WHERE USRH.USER_ID = '" + ID_USER + "' and Name_From = '" + cmd + "'";
            try
            {
                DataTable dataTable = readdata(SQL);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow data in dataTable.Rows)
                    {
                        if (data["PUSE"].ToString() == "False")
                        {
                            // bị khóa
                            check = true;
                        }
                    }
                }
                else
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }
        public class LG
        {
            public static bool rdVietNam;
            public static bool rdEnglish;
            public static bool rdChina;
        }
        public void choose_languege()
        {
            LG.rdVietNam = false;
            LG.rdEnglish = false;
            LG.rdChina = false;
            if (GetLangdefaul()==0)
            {
                LG.rdVietNam = true;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
            }
            else if (GetLangdefaul()==1)
            {
                LG.rdEnglish = true;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            else if (GetLangdefaul()==2)
            {
                LG.rdChina = true;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-TW");
            }
            else
            {
                LG.rdVietNam = true;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
            }
        }

        public int GetLangdefaul()
        {
            string FileName = "Langdefaul.Text", User = ""; ;
            string filePath = Environment.CurrentDirectory + "\\Log\\";
            if (!File.Exists(filePath + FileName))
            {
                Directory.CreateDirectory(filePath);
            }
            else
            {
                StreamReader read = new StreamReader(filePath + FileName, true);
                User = read.ReadToEnd().Trim();
                read.Close();
            }
            int x = 0;
            int.TryParse(User, out x);

            return x;
        }

        public void choose_languege1()
        {
            string User = frmLogin.ID_USER;
            string sql = "SELECT LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = readdata(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["LANGUAGE"].ToString() == "1")
                {
                    LG.rdVietNam = true;
                    LG.rdEnglish = false;
                    LG.rdChina = false;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
                }
                else if (dataRow["LANGUAGE"].ToString() == "2")
                {
                    LG.rdVietNam = false;
                    LG.rdEnglish = true;
                    LG.rdChina = false;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                }
                else if (dataRow["LANGUAGE"].ToString() == "3")
                {
                    LG.rdVietNam = false;
                    LG.rdEnglish = false;
                    LG.rdChina = true;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-TW");
                }
                else if (dataRow["LANGUAGE"].ToString() == string.Empty || dataRow["LANGUAGE"].ToString() == "")
                {
                    LG.rdVietNam = true;
                    LG.rdEnglish = false;
                    LG.rdChina = false;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
                }
            }
        }
        public void Mousewheelscroll(DataGridView dataGridView, MouseEventArgs e)
        {
            int rowindex_New;
            int rowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
            if (rowIndex != 0)
            {
                dataGridView.ClearSelection();
            }
            HandledMouseEventArgs handledE = (HandledMouseEventArgs)e;
            handledE.Handled = true;

            if (e.Delta < 0)
            {
                rowindex_New = dataGridView.CurrentRow.Index + 1;
            }
            else
            {
                rowindex_New = dataGridView.CurrentRow.Index - 1;
            }
            if (rowindex_New >= 0 && rowindex_New <= dataGridView.Rows.Count)
            {
                if (rowindex_New == dataGridView.Rows.Count)
                {
                    rowindex_New = rowindex_New - 1;
                    dataGridView.CurrentCell = dataGridView[dataGridView.CurrentCell.ColumnIndex, rowindex_New];
                }
                else
                {
                    dataGridView.CurrentCell = dataGridView[dataGridView.CurrentCell.ColumnIndex, rowindex_New];
                }
                //dataGridView.Rows[rowindex_New].Selected = true;
                RowIndexs = rowindex_New;
            }

        }
        // create MenuStrip
        public DataGridView gridView;
        bool Stts;
        public void CreateMenuStrip(MouseEventArgs e, DataGridView DGV, ToolStripItemClickedEventHandler Menu_ItemClicked)
        {
            gridView = DGV;
            if (e.Button == MouseButtons.Left)
            {
                // MessageBox.Show("left");
            }
            else
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Insert").Name = "Insert";
                menu.Items.Add("Delele").Name = "Delele";
                menu.Items.Add("Edit").Name = "Edit";
                menu.Show(gridView, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
        public void CreateMenuStrip(MouseEventArgs e, DataGridView DGV, bool stt)
        {
            Stts = stt;
            gridView = DGV;
            if (e.Button == MouseButtons.Left)
            {
                // MessageBox.Show("left");
            }
            else
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                int position_xy_mouse_row = gridView.HitTest(e.X, e.Y).RowIndex;

                if (position_xy_mouse_row >= 0)
                {
                    menu.Items.Add("Delele").Name = "Delele";
                    menu.Items.Add("Insert").Name = "Insert";
                    menu.Items.Add("Edit").Name = "Edit";
                }
                menu.Show(gridView, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    MessageBox.Show(e.ClickedItem.Name.ToString());
                    break;
                case "Delele":
                    //DialogResult dr = MessageBox.Show("Bạn có chắc muốn xoá item này?", "Thong báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
                    //switch (dr)
                    //{
                    //    case DialogResult.Yes:
                    foreach (DataGridViewCell oneCell in gridView.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            gridView.Rows.RemoveAt(oneCell.RowIndex);
                            //listdel.Add(new KeyValuePair<string, string>(txtWS_NO.Text, itemdel.ToString()));
                            if (Stts == true)
                            {
                                int NR = 1;
                                for (int i = 0; i < gridView.Rows.Count - 1; i++)
                                {
                                    gridView[0, i].Value = NR.ToString("D" + 3);
                                    NR++;
                                }
                            }
                        }
                    }
                    //        break;
                    //    case DialogResult.No:
                    //        break;
                    //}
                    break;
            }
        }
        public void MouseButtonsRightSelectDGV(DataGridViewCellMouseEventArgs e, DataGridView DGV)
        {
            DGV.ClearSelection();
            int rowIndex = e.RowIndex;
            DGV.Rows[rowIndex].Selected = true;
        }

        public void CheckPriceLock(string form_name, TextBox textBox)
        {
            string sql = "SELECT P_PRICE FROM dbo.USRB_NEW JOIN dbo.FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                    " WHERE [USER_ID] = '" + frmLogin.ID_USER + "' AND Name_From = '" + form_name + "'";
            DataTable dt = new DataTable();
            dt = readdata(sql);
            if (dt.Rows[0]["P_PRICE"].ToString() == "True")
            {
                textBox.Enabled = true;
            }
            else
            {
                textBox.Enabled = false;
            }
        }
        public void CheckLoad(MenuStrip menuStrip)
        {
            try
            {
                string form_name = "";
                var names = Application.OpenForms.Cast<Form>().Select(f => f.Name).ToList();
                for (int i = 0; i < names.Count; i++)
                {
                    if (i == names.Count - 1)
                    {
                        form_name = names[i].ToString();
                    }
                }
                string sql = "SELECT * FROM dbo.USRB_NEW JOIN dbo.FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                    " WHERE [USER_ID] = '" + frmLogin.ID_USER + "' AND Name_From = '" + form_name + "'";
                DataTable dt = new DataTable();
                dt = readdata(sql);

                //DataTable dt1 = dt.AsEnumerable().Where(x => x.Field<string>("Name_From").Contains(form_name)).CopyToDataTable();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SUPER"].ToString() == "True")
                    {
                        menuStrip.Items["f1ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f2ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f3ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f4ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f5ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f6ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f7ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f8ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f9ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f10ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f11ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f12ToolStripMenuItem"].Enabled = true;

                    }
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["F1"].ToString() == "False")
                            {
                                menuStrip.Items["f1ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f1ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F2"].ToString() == "False")
                            {
                                menuStrip.Items["f2ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f2ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F3"].ToString() == "False")
                            {
                                menuStrip.Items["f3ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f3ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F4"].ToString() == "False")
                            {
                                menuStrip.Items["f4ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f4ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F5"].ToString() == "False")
                            {
                                menuStrip.Items["f5ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f5ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F6"].ToString() == "False")
                            {
                                menuStrip.Items["f6ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f6ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F7"].ToString() == "False")
                            {
                                menuStrip.Items["f7ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f7ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F8"].ToString() == "False")
                            {
                                menuStrip.Items["f8ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f8ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F9"].ToString() == "False")
                            {
                                menuStrip.Items["f9ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f9ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F10"].ToString() == "False")
                            {
                                menuStrip.Items["f10ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f10ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F11"].ToString() == "False")
                            {
                                menuStrip.Items["f11ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f11ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F12"].ToString() == "False")
                            {
                                menuStrip.Items["f12ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f12ToolStripMenuItem"].Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public string CreateFilexcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel file |*.xls;*.xlsx;*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                var app1 = new Microsoft.Office.Interop.Excel.Application();
                var wb = app1.Workbooks.Add();
                wb.SaveAs(sfd.FileName);
                wb.Close();
            }
            return sfd.FileName;
        }

        public void BorderAround(Microsoft.Office.Interop.Excel.Range range) // Create Boder style Excel File  
        {
            Microsoft.Office.Interop.Excel.Borders borders = range.Borders;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            //range.EntireColumn.AutoFit = true;
        }
        public void releaseObject(object obj) // Clear COM Memory  
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }
        public void CreateStripButton(ReportViewer ReportViewer, EventHandler Print_Click, string ToolTip, int Itemindex, Image img)
        {
            ToolStrip toolStrip = (ToolStrip)ReportViewer.Controls.Find("toolStrip1", true)[0];
            ToolStripButton btn = new ToolStripButton();
            btn.Image = img;
            btn.ToolTipText = ToolTip;
            btn.Click += new EventHandler(Print_Click);
            toolStrip.Items.Insert(Itemindex, btn);
        }
        public void CreateButtonToolTipReport(CrystalDecisions.Windows.Forms.CrystalReportViewer crystal, EventHandler ExportExcel_Click)
        {
            foreach (Control control in crystal.Controls)
            {
                if (control is System.Windows.Forms.ToolStrip)
                {
                    //Default Print Button
                    //ToolStripItem tsItem = ((ToolStrip)control).Items[1];
                    //tsItem.Click += new EventHandler(tsItem_Click);

                    //Custom Button
                    ToolStripItem tsNewItem = ((ToolStrip)control).Items.Add("");
                    tsNewItem.ToolTipText = "Export Excel";
                    tsNewItem.Image = Resources.excelconvert;
                    tsNewItem.Tag = "99";
                    ((ToolStrip)control).Items.Insert(0, tsNewItem);
                    tsNewItem.Click += new EventHandler(ExportExcel_Click);
                }
            }
        }
        public void CreateButtonToolTipReport2(CrystalDecisions.Windows.Forms.CrystalReportViewer crystal, EventHandler Print_Click)
        {
            foreach (Control control in crystal.Controls)
            {
                if (control is System.Windows.Forms.ToolStrip)
                {
                    ToolStripItem tsNewItem = ((ToolStrip)control).Items.Add("");
                    tsNewItem.ToolTipText = "PRINT";
                    tsNewItem.Image = Resources.printing;
                    tsNewItem.Tag = "99";
                    ((ToolStrip)control).Items.Insert(1, tsNewItem);
                    tsNewItem.Click += new EventHandler(Print_Click);
                }
            }
        }
        public string CopyTemplateExcel(string link)
        {
            string workbookPath = LinkTemplate + link;
            string w_Path = CreateFilexcel();
            try
            {
                if (!string.IsNullOrEmpty(w_Path))
                {
                    File.Copy(workbookPath, w_Path, true);
                }
                else
                {
                    MessageBox.Show("Bạn chưa lưu file excel");
                    return "";
                }
                return w_Path;
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
                return "";
            }
        }
        public bool checkExists(string sql)
        {
            DataTable dataTable = new DataTable();
            dataTable = readdata(sql);
            if (dataTable.Rows.Count > 0)
            {
                //có trùng mã
                return true;
            }
            else
            {
                // khong trung mã
                return false;
            }
        }
        //chỉ áp dụng khi column liền nhau
        public DataTable Comlumn_Excel(string star, string end)
        {
            DataTable dataTable = new DataTable();
            dataTable = readdata("Exec sp_ColumnExcelList '" + star + "','" + end + "'");
            return dataTable;
        }
        public bool CheckFileOpen(string path)
        {
            FileStream stream = null;
            try
            {
                stream = File.Open(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("being used by another process"))
                    return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }
        public string CutString(TextBox text)
        {
            string key = "";
            if (text.Text.Length > 8)
            {
                key = text.Text.Substring(0, 8);
            }
            else
            {
                key = text.Text;
            }
            return key;
        }
        public string MessaTitle()
        {
            string Result = string.Empty;
            if (frmLogin.Lang_ID == 1) Result = "Thông Báo";
            if (frmLogin.Lang_ID == 2) Result = "Notifications";
            if (frmLogin.Lang_ID == 3) Result = "通知";
            return Result;
        }
        public string MessaError()
        {
            string Result = string.Empty;
            if (frmLogin.Lang_ID == 1) Result = "Lỗi";
            if (frmLogin.Lang_ID == 2) Result = "Error";
            if (frmLogin.Lang_ID == 3) Result = "錯誤";
            return Result;
        }
    }
}
