using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一些气溶胶类方法的测试
{
    class Program
    {
        static void Main(string[] args)
        {
            AeroOpticalDepth aeroOpticalDepth = new AeroOpticalDepth();
            DateTime datetime = new DateTime(2018,8,6);
            aeroOpticalDepth.d_d0 = aeroOpticalDepth.fEarthToSun(datetime);
            Console.WriteLine(aeroOpticalDepth.d_d0);
            Console.ReadLine();
        }
    }
}
