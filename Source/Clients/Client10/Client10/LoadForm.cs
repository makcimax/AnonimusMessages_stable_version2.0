using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinForm
{
    public partial class LoadForm : Form
    {
        public int  MyProgressBar 
        {
            get
            {
                return LoadBar.Value;
            }
            set
            {
                LoadBar.Value = value;
            }
        }
        public void GrowValue(int val = 1)
        {
            MyProgressBar += val;
        }
        public LoadForm()
        {
            InitializeComponent();
            while (MyProgressBar < 100)
            {
                GrowValue(3);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
