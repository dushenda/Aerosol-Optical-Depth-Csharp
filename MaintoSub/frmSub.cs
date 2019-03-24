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
    public partial class frmSub : Form
    {
        public frmSub()
        {
            InitializeComponent();

        }
        public string UserInput
        {
            get
            {
                return txtSub.Text;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); 
        }

        //public string Info
        //{
        //    set
        //    {
        //        lblInfo.Text = "老大说:" + value;
        //    }
        //}

        //public void Recieve(string Info)
        //{
        //    lblInfo.Text = "老大说:" + Info;
        //}

    }
}
