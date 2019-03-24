﻿using System;
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
           
        }
    }
    
    
} 
