using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP.WSEXE.Module2._2C
{
    public partial class FrmView2C : Form
    {
        public FrmView2C()
        {
            InitializeComponent();
        }

        private void FrmView2C_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
