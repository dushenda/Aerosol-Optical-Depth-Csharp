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

namespace FileSystemDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tvwFileSystem.BeginUpdate();
            this.Cursor = Cursors.WaitCursor;
            tvwFileSystem.Nodes.Clear();
            foreach(DriveInfo d in DriveInfo.GetDrives())
            {
                TreeNode rootNode = CreateDirectotryNode(d.RootDirectory);
                tvwFileSystem.Nodes.Add(rootNode);
            }
            tvwFileSystem.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        private object loadingFlag = new object();

        private TreeNode CreateDirectotryNode(DirectoryInfo dir)
        {
            TreeNode node = new TreeNode(dir.Name);
            node.Tag = dir;
            TreeNode node2 = new TreeNode("正在加载...");
            node2.Tag = loadingFlag;
            node.Nodes.Add(node2);
            return node;
            //throw new NotImplementedException();
        }
    }
}
