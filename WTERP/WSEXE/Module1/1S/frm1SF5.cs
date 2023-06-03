using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form1SF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1SF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(textBox1, tb2,sender,e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb2, textBox1, sender, e);
        }
    }
}
