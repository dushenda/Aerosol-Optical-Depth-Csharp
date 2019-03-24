using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace TestCSV
{
    class Program
    {
        static void Main(string []args)
        {
            using (var reader = new StreamReader("20180808.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<FooMap>();
                var records = csv.GetRecords<Foo>();
                foreach (var record in records)
                {
                    Console.WriteLine(record.Time + "\t \t" + record.Channel1 + "\t \t" + record.Channel2);
                }
                Console.ReadLine();
            }

            using (var readerTest = new StreamReader("test.csv"))
                using(var csv=new CsvReader(readerTest))
            {
                csv.Configuration.RegisterClassMap<testMap>();
                var tests = csv.GetRecords<test>();
                foreach (var test in tests)
                {
                    Console.WriteLine(test.Id+"\t"+test.Name+"\t"+test.Time);
                }
                Console.ReadLine();
            }
        }

        public class Foo
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

        public sealed class FooMap : ClassMap<Foo>
        {
            public FooMap()
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

        public class test
        {
            public int Id { set; get; }
            public string Name { set; get; }
            public string Time { set; get; }
        }

        public sealed class testMap:ClassMap<test>
        {
            public testMap()
            {
                AutoMap();
                Map(m => m.Id).Name("编号");
                Map(m => m.Name).Name("名字");
                Map(m => m.Time).Name("测量时间");
            }
        }
    }
}

