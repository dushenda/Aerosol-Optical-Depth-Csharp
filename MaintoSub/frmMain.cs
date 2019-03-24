using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintoSub
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //frm = new frmSub();       //创建从窗体
        }

        //private frmSub frm = null; //用于引用从窗体对象

        private void btnTran_Click(object sender, EventArgs e)
        {
            //sendMessageViaPublicProperity();
            //sendMessageViaPublicMeyhods();  
            frmSub frm = new frmSub();
            //frm.Show();               //显示从窗体
            DialogResult k = frm.ShowDialog();
           if (k == DialogResult.OK)
            {
                if (frm.UserInput == "")
                {
                    MessageBox.Show("输入不能为空", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                else
                {
                    lblInfo.Text = frm.UserInput;
                }               
            }
            else
            {
                lblInfo.Text = "你已经输入了取消";
            }
            
        }
            
  
        //private void sendMessageViaPublicProperity()
        //{
        //    if (textBox1.Text == "")
        //    {
        //        MessageBox.Show("输入字符！","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        //        textBox1.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        frm.Info = textBox1.Text;
        //    }

        //}

        //private void sendMessageViaPublicMeyhods()
        //{
        //    frm.Recieve(textBox1.Text);
        //}
    }
}
