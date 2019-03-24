using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCSV
{
    /// <summary>
    /// 设置属性值
    /// </summary>
    public class DataTable
    {
        public string Time { get; set; }
        public double Channel1 { get; set; }
        public double Channel2 { get; set; }
        public double Channel3 { get; set; }
        public double Channel4 { get; set; }
        public double Channel5 { get; set; }
        public double Channel6 { get; set; }
        public double Channel7 { get; set; }
        public double Channel8 { get; set; }
        public double ConTem { get; set; }
        public double CPUTem { get; set; }
        public double EnvTem { get; set; }
        public double EnvWet { get; set; }
        public double AirPre { get; set; }

        /// <summary>
        /// 设置列名称
        /// </summary>
        /// <param name="obj"></param>
        public static void setColumName(DataGridView obj)
        {
            obj.ColumnCount = 14;
            obj.Columns[0].Name = "时间";
            obj.Columns[1].Name = "通道1";
            obj.Columns[2].Name = "通道2";
            obj.Columns[3].Name = "通道3";
            obj.Columns[4].Name = "通道4";
            obj.Columns[5].Name = "通道5";
            obj.Columns[6].Name = "通道6";
            obj.Columns[7].Name = "通道7";
            obj.Columns[8].Name = "通道8";
            obj.Columns[9].Name = "控温";
            obj.Columns[10].Name = "CPU温度";
            obj.Columns[11].Name = "环境温度";
            obj.Columns[12].Name = "环境湿度";
            obj.Columns[13].Name = "大气压强";
        }
    }

}
