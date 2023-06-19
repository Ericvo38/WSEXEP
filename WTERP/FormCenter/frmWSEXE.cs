using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using WTERP.Config;
using WTERP.WSEXE;

namespace WTERP
{
    public partial class frmWSEXE : Form
    {
        DataProvider con = new DataProvider();
        public frmWSEXE()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        string language = "";
        string txtThongBao = "";
        public void setLanguage()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                language = "Bạn không có quyền truy cập";
                txtThongBao = "Thông báo";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                language = "Bạn không có quyền truy cập";
                txtThongBao = "Thông báo";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                language = "You do not have access";
                txtThongBao = "Nofication";
            }
            if (DataProvider.LG.rdChina == true)
            {
                language = "您無權訪問";
                txtThongBao = "通知";
            }
        }
        #region Modun1
        // ************* Modun1 ******************

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1A;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1A fr = new Form1A();
                fr.ShowDialog();
            }
        }
        private void bThôngTinDoanhNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1B;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1B fr = new Form1B();
                fr.ShowDialog();
            }
        }

        private void cQuảnLýDữLiệuSảnPhẩmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1C;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1C fr = new Form1C();
                fr.ShowDialog();
            }

        }
        private void dQuảnLýDữLiệuSảnPhẩmDoanhNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1D;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1D fr = new Form1D();
                fr.ShowDialog();
            }
        }

        private void eCơSởDanhMụcSảnPhẩmKháchHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1E;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1E fr = new Form1E();
                fr.ShowDialog();
            }

        }
        private void fCơSởDanhMụcSảnPhẩmDoanhNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1F;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1F fr = new Form1F();
                fr.ShowDialog();
            }
        }
        private void gQuảnLýDữLiệuCụmTừToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1G;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1G fr = new Form1G();
                fr.ShowDialog();
            }
        }
        private void hQuảnLýDữLiệuKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1H;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1H fr = new Form1H();
                fr.ShowDialog();
            }
        }
        private void iQuảnLýBáoGiáKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1I;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1I fr = new Form1I();
                fr.ShowDialog();
            }

        }
        private void jQuảnLýThôngTinGiáCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1J;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1J fr = new Form1J();
                fr.ShowDialog();
            }
        }
        private void kQuảnLýThôngTinThươngHiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1K;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1K fr = new Form1K();
                fr.ShowDialog();
            }
        }
        private void lQuảnLýDữLiệuCôngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1L;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1L fr = new Form1L();
                fr.ShowDialog();
            }
        }
        private void mQuảnLýThôngTinĐangChờXửLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1M;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1M fr = new Form1M();
                fr.ShowDialog();
            }
        }
        private void nQuảnLýMứcThànhPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1N;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1N fr = new Form1N();
                fr.ShowDialog();
            }
        }
        private void oQuảnLýĐộDàyVậtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1N;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1O fr = new Form1O();
                fr.ShowDialog();
            }
        }
        private void pQuảnLýDữLiệuPCNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1P;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1P fr = new Form1P();
                fr.ShowDialog();
            }
        }
        private void qQuảnLýTỷGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1Q;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1Q fr = new Form1Q();
                fr.ShowDialog();
            }
        }
        private void rQuảnLýDữLiệuKếtCấuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1R;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1R fr = new Form1R();
                fr.ShowDialog();
            }
        }
        private void sKhoHóaChấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room1S;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1S fr = new Form1S();
                fr.ShowDialog();
            }
        }
        private void tQuảnLýTồnKhoThànhPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            Form1T fr = new Form1T();
            fr.ShowDialog();
        }
        #endregion
        #region Mondun2
        // ****************** Modun2 *********************

        public class ID_FORM
        {
            public static string STR;
        }
        private void aTruyVấnThôngTinĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            ID_FORM.STR = "F1";
            Form2AB fr = new Form2AB();
            fr.ShowDialog();



        }
        private void bQuảnLýThôngTinĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            ID_FORM.STR = "F2";
            string ID = SetDataRoomID.Room2B;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form2AB fr = new Form2AB();
                fr.ShowDialog();
            }
        }
        private void cQuảnLýDữLiệuVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2C;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2C_1 fm = new frm2C_1();
                fm.ShowDialog();
            }

        }
        private void dQuảnLýĐiêuTraLôHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2D;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form2D fm = new Form2D();
                
                fm.ShowDialog();
            }

        }
        private void eQuảnLýTrảLạiLôHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2E;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Form2E fm = new Form2E();
                WSEXE.Module2._2E.FrmMain2E fm = new WSEXE.Module2._2E.FrmMain2E();
                fm.ShowDialog();
            }

        }
        private void fQuảnLýDữLiệuKhôngNhậnĐượcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2F;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2F fm = new frm2F();
                fm.ShowDialog();
            }
        }
        private void gBáoCáoThốngKêĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2G;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2G fm = new frm2G();
                fm.ShowDialog();
            }
        }
        private void hQuảnLýĐăngKýHiệuSuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2H;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2H f2h = new frm2H();
                f2h.ShowDialog();
            }

        }
        private void iQuảnLýPhátHànhHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2I;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2I fr2i = new frm2I();
                fr2i.ShowDialog();
            }

        }
        private void jChuyểnĐổiDữLiệuExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2J;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2J frf2j = new frm2J();
                frf2j.ShowDialog();
            }

        }

        private void kCácKhoảnPhảiThuBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2K;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2K f2k = new frm2K();
                f2k.ShowDialog();
            }

        }
        private void lQuảnLýBổSungChênhLệchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2L;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2L fr2l = new frm2L();
                fr2l.ShowDialog();
            }

        }
        private void mQuảnLýGiữaCácTàiKhoảnPhảiThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2M;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2M fr2M = new frm2M();
                fr2M.ShowDialog();
            }

        }
        private void nĐặtHàngThôngTinKiểmSoátLôHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2N;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2N fr2m = new frm2N();
                fr2m.ShowDialog();
            }
        }
        private void pCácKhoảnPhảiThuVậtLiệuQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2P;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2P fr2P = new frm2P();
                fr2P.ShowDialog();
            }
        }

        #endregion
        #region Mondun3
        // **************** Modun 3 *********************
        private void dQuảnLýĐơnĐặtHàngMẫuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3D;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3D op3d = new frm3D();
                op3d.ShowDialog();
            }

        }
        private void eQuảnLýLệnhSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3E;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form3E fr = new Form3E();
                fr.ShowDialog();
            }

        }
        private void fXửLýĐơnHàngQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3F;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3F fm = new frm3F();
                fm.ShowDialog();
            }

        }

        private void hSảnXuấtBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3H;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3H fm = new frm3H();
                fm.ShowDialog();
            }

        }
        private void iQuảnLýHưHỏngLĩnhVựcNướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3I;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3I fm = new frm3I();
                fm.ShowDialog();
            }
        }
        private void jQuảnLýNguồnDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3J;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3J fm = new frm3J();
                fm.ShowDialog();
            }
        }
        private void kSửDụngHiểuQuảQuảnLýSựPhongPhúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3K;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3K fm = new frm3K();
                fm.ShowDialog();
            }

        }
        #endregion
        #region Modun4
        // ****************** Modun 4 *********************
        private void bChuyểnGiaoQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room4B;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form4B fr1 = new Form4B();
                fr1.ShowDialog();
            }
        }
        private void cQuảnLýMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room4C;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form4C fr2 = new Form4C();
                fr2.ShowDialog();
            }

        }
        private void dQuảnLýMuaHàngVàXuấtCảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room4D;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form4D fr3 = new Form4D();
                fr3.ShowDialog();
            }

        }
        private void eQuảnLýGhiNhậnCácKhoảnPhảiTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room4E;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form4E fr4 = new Form4E();
                fr4.ShowDialog();
            }

        }
        private void fQuảnLýMuaSắmPhíaĐámMâyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room4F;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form4F fr5 = new Form4F();
                fr5.ShowDialog();
            }

        }
        #endregion
        #region Modun6
        // *********************** Modun 6 ****************
        private void aCàiĐặtQuyềnHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6A;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6A fr1 = new Form6A();
                fr1.ShowDialog();
            }

        }
        private void bCàiĐặtMậtKhẩuHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6B;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6B fr2 = new Form6B();
                fr2.ShowDialog();
            }

        }
        private void cThiếtĐặtTênCôngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6C;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6C fr3 = new Form6C();
                fr3.ShowDialog();
            }

        }
        private void dCàiĐặtThôngSốHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6D;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6D fr4 = new Form6D();
                fr4.ShowDialog();
            }
        }
        private void eCàiĐặtThôngSốBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6E;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6E fr5 = new Form6E();
                fr5.ShowDialog();
            }
        }
        private void fChuyểnĐổiMãKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6F;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6F fr6 = new Form6F();
                fr6.ShowDialog();
            }
        }
        private void gChuyểnĐổiMãSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6G;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6G fr7 = new Form6G();
                fr7.ShowDialog();
            }
        }
        private void hTạoSốLôHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6H;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6H fr8 = new Form6H();
                fr8.ShowDialog();
            }

        }
        private void iĐiềuChỉnhKhoảngKhôngQuảngCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room6I;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form6I fr9 = new Form6I();
                fr9.ShowDialog();
            }

        }
        #endregion
        #region Modun8
        // *********************** Modun 8 ****************
        private void aQuảnLýNguyênVậtLiệuHóaChấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room8A;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form8A fr1 = new Form8A();
                fr1.ShowDialog();
            }
        }
        private void bQuảnLýDữLiệuPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room8B;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form8B fr2 = new Form8B();
                fr2.ShowDialog();
            }

        }
        private void cQuảnLýDữLiệuQuốcGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room8C;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form8C fr3 = new Form8C();
                fr3.ShowDialog();
            }
        }
        #endregion
        // ******************* Modun 9 *************************
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // **************** Function **************************
        private void frmQuanLyBanHang_Load(object sender, EventArgs e)
        {
            Module1.ShortcutKeys = Keys.F1;
            string UID = frmLogin.ID_USER;
            lbUserName.Text = con.getUser(UID);
            getIP();
            lbNamePC.Text = System.Environment.MachineName;

            // Check vesion product
            lbVesion.Text = "VS: " + Application.ProductVersion;
        }

        public void getIP()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void Module8_Click(object sender, EventArgs e)
        {
        }

        private void frmWSEXE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Module1.ShowDropDown();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                Module1.ShowDropDown();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                Module2.ShowDropDown();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                Module3.ShowDropDown();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                Module4.ShowDropDown();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                Module6.ShowDropDown();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                Module8.ShowDropDown();
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                Module9.ShowDropDown();
            }
        }
        private void bẢNGSỐTÊNVẬTLIỆUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3J;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2Q fr = new frm2Q();
                fr.Show();
            }
        }
        private void xUẤTPACKINGLISTINVOICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3L;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3L fr1 = new frm3L();
                fr1.ShowDialog();
            }

        }

        private void Module10_Click(object sender, EventArgs e)
        {
            Language language = new Language();
            language.ShowDialog();
        }

        private void Module1_Click(object sender, EventArgs e)
        {

        }

        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3M;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3M fr1 = new frm3M();
                fr1.ShowDialog();
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3N;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3N fr1 = new frm3N();
                fr1.ShowDialog();
            }

        }

        private void Module2R_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room2R;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm2R fr1 = new frm2R();
                fr1.ShowDialog();
            }
        }

        //private void PACKINGLISTToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    setLanguage();
        //    string ID = SetDataRoomID.Room3O;
        //    if (con.Check_Decentralization(ID) == true)
        //    {
        //        MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else
        //    {
        //        frm3O fr1 = new frm3O();
        //        fr1.ShowDialog();
        //    }
        //}

        private void pACKINGLIST2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLanguage();
            string ID = SetDataRoomID.Room3P;
            if (con.Check_Decentralization(ID) == true)
            {
                MessageBox.Show("" + language + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm3P fr1 = new frm3P();
                fr1.ShowDialog();
            }
        }
    }
}

