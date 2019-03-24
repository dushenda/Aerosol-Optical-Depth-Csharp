using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCSV
{
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
