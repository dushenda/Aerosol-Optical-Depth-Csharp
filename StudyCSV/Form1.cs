using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using CsvHelper;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace StudyCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<double> Tauaero_365 = new List<double>();
        List<double> Tauaero_412 = new List<double>();
        List<double> Tauaero_500 = new List<double>();
        List<double> Tauaero_610 = new List<double>();
        List<double> Tauaero_675 = new List<double>();
        List<double> Tauaero_862 = new List<double>();
        List<double> Tauaero_940 = new List<double>();
        List<double> Tauaero_1024 = new List<double>();
        AeroOpticalDepth aeroOpticalDepth = new AeroOpticalDepth();

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
                        //AeroOpticalDepth aeroOpticalDepth = new AeroOpticalDepth();
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
                        Tauaero_365 = aeroOpticalDepth.getTauaero(63484, Channel1, 365, 1.2);
                        Tauaero_412 = aeroOpticalDepth.getTauaero(68577, Channel2, 412, 1.2);
                        Tauaero_500 = aeroOpticalDepth.getTauaero(61448, Channel3, 500, 1.2);
                        Tauaero_610 = aeroOpticalDepth.getTauaero(57414, Channel4, 610, 1.2);
                        Tauaero_675 = aeroOpticalDepth.getTauaero(64450, Channel5, 675, 1.2);
                        Tauaero_862 = aeroOpticalDepth.getTauaero(61584, Channel6, 862, 1.2);
                        Tauaero_940 = aeroOpticalDepth.getTauaero(92457, Channel7, 940, 1.2);
                        Tauaero_1024 = aeroOpticalDepth.getTauaero(56643, Channel8, 1024, 1.2);
                    }

                }
            }
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < aeroOpticalDepth.myDateTime.Count; i++)
            {
                myChart.Series["λ=365nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_365[i]);
                myChart.Series["λ=412nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_412[i]);
                myChart.Series["λ=500nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_500[i]);
                myChart.Series["λ=610nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_610[i]);
                myChart.Series["λ=675nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_675[i]);
                myChart.Series["λ=864nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_862[i]);
                myChart.Series["λ=940nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_940[i]);
                myChart.Series["λ=1024nm"].Points.AddXY(aeroOpticalDepth.myDateTime[i].ToString(), Tauaero_1024[i]);

            }
            myChart.Titles.Add("气溶胶结果反演");
        }
    }

}
    
    
