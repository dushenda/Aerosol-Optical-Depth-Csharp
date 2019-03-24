using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo0._0
{
    public partial class frmEdit : Form
    {
        public frmEdit()
        {
            InitializeComponent();
        }

        private string OriginContent = "";
        private string _FileName = "";
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
                Text = Path.GetFileName(value) + "--我的记事本";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Open()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    OriginContent = File.ReadAllText(FileName);
                    txtIn.Text = OriginContent;
                }
                catch(Exception)
                {
                    lblInfo.Text = "文件无法打开";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Save()
        {
            bool ShouldSave = false;
            if (FileName != "")
            {
                if (txtIn.Text != OriginContent
                    && MessageBox.Show("文件已经修改，保存吗？", "保存文件",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ShouldSave = true;
                }
            }
            else
            {
                if (txtIn.Text != "" && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                    ShouldSave = true;
                }
            }
            if (ShouldSave)
                {
                    try
                    {
                        File.WriteAllText(FileName, txtIn.Text);
                        OriginContent = txtIn.Text;
                        lblInfo.Text = "已保存";
                    }
                    catch (Exception)
                    {
                        lblInfo.Text = "文件保存失败";
                    }
                } 
                                     
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            lblTime.Text = "";
            lblInfo.Text = "";
            Text = "无标题-我的笔记本";
            saveFileDialog.FileName = Text;
        }

        private void txtIn_TextChanged(object sender, EventArgs e)
        {
            lblInfo.Text = "暂未保存";
        }

        private void frmEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }
    }
}
