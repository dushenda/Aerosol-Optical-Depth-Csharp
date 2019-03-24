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
            DataTable.setColumName(dataGridView1);
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
       
    }
    
    
} 
