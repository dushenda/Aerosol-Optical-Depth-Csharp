using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class CalendarEntry
        {
            // private field
            private DateTime date;

            // public field (Generally not recommended.)
            public string day;

            // Public property exposes date field safely.
            public DateTime Date
            {
                get
                {
                    return date;
                }
                set
                {
                    // Set some reasonable boundaries for likely birth dates.
                    if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
                    {
                        date = value;
                    }
                    else
                        throw new ArgumentOutOfRangeException();
                }

            }

            // Public method also exposes date field safely.
            // Example call: birthday.SetDate("1975, 6, 30");
            public void SetDate(string dateString)
            {
                DateTime dt = Convert.ToDateTime(dateString);

                // Set some reasonable boundaries for likely birth dates.
                if (dt.Year > 1900 && dt.Year <= DateTime.Today.Year)
                {
                    date = dt;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }

            public TimeSpan GetTimeSpan(string dateString)
            {
                DateTime dt = Convert.ToDateTime(dateString);

                if (dt != null && dt.Ticks < date.Ticks)
                {
                    return date - dt;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //说明这个字段确实是使用Date公共属性访问到了date私有变量
            CalendarEntry calendarEntry = new CalendarEntry();
            calendarEntry.Date = Convert.ToDateTime("1996,11,11");
            lblTest.Text = calendarEntry.Date.ToString();
            CalendarEntry calendar = new CalendarEntry();
            calendar.SetDate("1988,6,7");
            lblSet.Text = calendar.Date.ToString();
            CalendarEntry birthday = new CalendarEntry();
            birthday.day = "Saturday";
        }
    }
}
