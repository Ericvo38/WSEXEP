using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form8AF5 : Form
    {
        DataProvider conn = new DataProvider();

        public Form8AF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
      
        private void button5_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Không Có Dữ Liệu!");
            //this.Hide();
            //this.Close();
        }

        private void Form8AF5_Load(object sender, EventArgs e)
        {
            conn.DGV(dataGridView2);
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //this.Hide();
            //this.Close();
        }
    }
}
