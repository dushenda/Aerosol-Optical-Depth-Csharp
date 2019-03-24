using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int counter = 0;

        private void btnNum_Click(object sender, EventArgs e)
        {
            counter++;
            showInfo();
        }
        private void showInfo()
        {
            lblNum.Text = string.Format("你已经点击了{0}次按钮", counter);
        }
    }
}
