using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString();
            //DateTime dtm = new DateTime(2019, 3, 23);
            //Console.WriteLine(dtm.DayOfWeek);
            Console.WriteLine(Enum.GetNames(typeof(FlagStyle)));
        }
        /// <summary>
        /// 枚举
        /// <param name="name"></param>
        /// <returns></returns>
        /// </summary>
        public enum FlagStyle
        {
            Flag1=1,
            Flag2=2,
            Flag3=64
        }
        
    }
}
