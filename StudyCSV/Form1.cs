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
using CsvHelper;
using CsvHelper.Configuration;

namespace StudyCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            setColumName(dataGridView1);
            using (var reader = new StreamReader("20180602.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<DataTableMap>();
                var records = csv.GetRecords<DataTable>();                              
                ///<summary>
                ///读取数据
                ///</summary>           
                foreach (var record in records)
                {
                    dataGridView1.Rows.Add(record.Time, record.Channel1, record.Channel2, record.Channel3,
                        record.Channel4, record.Channel5, record.Channel6, record.Channel7, record.Channel8,
                        record.ConTem, record.CPUTem, record.EnvTem, record.EnvWet, record.AirPre);
                }

            }
        }
        /// <summary>
        /// 设置列名称
        /// </summary>
        /// <param name="obj"></param>
        private void setColumName(DataGridView obj)
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
    }
    /// <summary>
    /// 设置顺序映射表
    /// </summary>
    public sealed class DataTableMap : ClassMap<DataTable>
    {
        public DataTableMap()
        {
            AutoMap();
            Map(m => m.Time).Name("测量时间");
            Map(m => m.Channel1).Name("通道1");
            Map(m => m.Channel2).Name("通道2");
            Map(m => m.Channel3).Name("通道3");
            Map(m => m.Channel4).Name("通道4");
            Map(m => m.Channel5).Name("通道5");
            Map(m => m.Channel6).Name("通道6");
            Map(m => m.Channel7).Name("通道7");
            Map(m => m.Channel8).Name("通道8");
            Map(m => m.ConTem).Name("控温");
            Map(m => m.CPUTem).Name("CPU温");
            Map(m => m.EnvTem).Name("环温");
            Map(m => m.EnvWet).Name("环湿");
            Map(m => m.AirPre).Name("压强");
        }
    }
}
