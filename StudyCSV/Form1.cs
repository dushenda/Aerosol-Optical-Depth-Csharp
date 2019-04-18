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
            //打开文件
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] arrAllFiles = openFileDialog1.FileNames;
                foreach (var file in arrAllFiles)
                {

                    //读入数据并且显示，也就是判断是否是这个数据
                    DataTable.setColumName(dataGridView1);
                    using (var reader = new StreamReader(file))
                    using (var csv = new CsvReader(reader))
                    {
                        string FileName = Path.GetFileNameWithoutExtension(file);
                        DateTime Date = DateTime.ParseExact(FileName, "yyyyMMdd",
                                        System.Globalization.CultureInfo.InvariantCulture);
                        csv.Configuration.RegisterClassMap<DataTableMap>();
                        var records = csv.GetRecords<DataTable>();
                        //读取数据    
                        //这部分先使用 List 读取出数据，再使用 ToArray 转化到属性数组
                        //List<DateTime> TimesList = new List<DateTime>();
                        List<double> Channel1 = new List<double>();//365
                        List<double> Channel2 = new List<double>();//412
                        List<double> Channel3 = new List<double>();//500
                        List<double> Channel4 = new List<double>();//610
                        List<double> Channel5 = new List<double>();//675
                        List<double> Channel6 = new List<double>();//862，在2018/8/8这个数据表现最好，用来测试
                        List<double> Channel7 = new List<double>();//940
                        List<double> Channel8 = new List<double>();//1024
                        List<double> EnvTem = new List<double>();
                        List<double> AirPre = new List<double>();
                        const double LonVal = 94.01 * Math.PI / 180;
                        const double LatVal = 40.09 * Math.PI / 180;
                        AeroOpticalDepth aeroOpticalDepth = new AeroOpticalDepth();
                        foreach (var record in records)
                        {
                            var Time = TimeSpan.Parse(record.Time);
                            var myDateTime = Date.Date.Add(Time);                            
                            dataGridView1.Rows.Add(myDateTime, record.Channel1, record.Channel2, record.Channel3,
                                record.Channel4, record.Channel5, record.Channel6, record.Channel7, record.Channel8,
                                record.ConTem, record.CPUTem, record.EnvTem, record.EnvWet, record.AirPre);
                            //从东八区（北京时间）转到世界协调时（UTC）
                            aeroOpticalDepth.myDateTime.Add(myDateTime.AddHours(-8));
                            Channel1.Add(record.Channel1);
                            Channel2.Add(record.Channel2);
                            Channel3.Add(record.Channel3);
                            Channel4.Add(record.Channel4);
                            Channel5.Add(record.Channel5);
                            Channel6.Add(record.Channel6);
                            Channel7.Add(record.Channel7);
                            Channel8.Add(record.Channel8);
                            EnvTem.Add(record.EnvTem);
                            AirPre.Add(record.AirPre / 1000);
                        }
                        //接收一些方法的返回值
                        List<double> t = new List<double>();
                        List<double> zenith = new List<double>();
                        aeroOpticalDepth.Lonitude = LonVal;
                        aeroOpticalDepth.Latitude = LatVal;
                        aeroOpticalDepth.Temperature = EnvTem;
                        aeroOpticalDepth.Pressure = AirPre;
                        aeroOpticalDepth.fEarthToSun(aeroOpticalDepth.myDateTime);
                        t = aeroOpticalDepth.getTimeScale(aeroOpticalDepth.myDateTime);
                        aeroOpticalDepth.getHourAngle(t);
                        zenith = aeroOpticalDepth.getZenith();
                        aeroOpticalDepth.getAirmass();
                        aeroOpticalDepth.getTauaero(61584, Channel6, 862, 1.2);
                    }

                }
            }
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
        }


    }
    
    
} 
