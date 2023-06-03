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
    public partial class Form1JF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1JF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
    }
}
