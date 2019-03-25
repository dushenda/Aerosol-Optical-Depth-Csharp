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

        //string[] arrAllFiles;

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //打开文件
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] arrAllFiles = openFileDialog1.FileNames;
                foreach (var file in arrAllFiles)
                {

                    //读入数据
                    DataTable.setColumName(dataGridView1);
                    using (var reader = new StreamReader(file))
                    using (var csv = new CsvReader(reader))
                    {
                        string FileName = Path.GetFileNameWithoutExtension(file);
                        DateTime Date = DateTime.ParseExact(FileName, "yyyyMMdd",
                                        System.Globalization.CultureInfo.InvariantCulture);
                        csv.Configuration.RegisterClassMap<DataTableMap>();
                        var records = csv.GetRecords<DataTable>();
                        ///<summary>
                        ///读取数据
                        ///</summary>           
                        foreach (var record in records)
                        {
                            var Time = TimeSpan.Parse(record.Time);
                            var myDateTime = Date.Date.Add(Time);
                            //DateTime Time = DateTime.ParseExact(record.Time, "HH:mm:ss",
                            //            System.Globalization.CultureInfo.InvariantCulture);
                            //DateTime myDateTime = new DateTime();
                            //myDateTime = Date.Date.Add(Time.TimeOfDay);

                            dataGridView1.Rows.Add(myDateTime, record.Channel1, record.Channel2, record.Channel3,
                                record.Channel4, record.Channel5, record.Channel6, record.Channel7, record.Channel8,
                                record.ConTem, record.CPUTem, record.EnvTem, record.EnvWet, record.AirPre);
                        }

                    }

                }
            }
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //string sFileName = choofdlog.FileName;
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true    
                //string sFileName = openFileDialog1.FileName;     

                string[] arrAllFiles = openFileDialog1.FileNames;
                foreach (var file in arrAllFiles)
                {
                    Console.WriteLine(file);
                    string pathName = Path.GetFileNameWithoutExtension(file);
                    Console.WriteLine(pathName);
                }

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string date = "20090508";
            DateTime myDate = DateTime.ParseExact(date, "yyyyMMdd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("before:\t"+myDate.ToString());
            string time = "18:00:45";
            DateTime myTime = DateTime.ParseExact(time, "HH:mm:ss",
                                        System.Globalization.CultureInfo.InvariantCulture);
            DateTime myDateTime = new DateTime();
            myDateTime = myDate.Date.Add(myTime.TimeOfDay);
            Console.WriteLine("after:\t"+myDateTime);
        }
    }
    
    
} 
