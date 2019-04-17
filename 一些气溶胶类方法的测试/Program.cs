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
            DateTime dateTime = new DateTime(2018, 8, 7, 5, 14, 0);
            aeroOpticalDepth.Lonitude = 94.01 * Math.PI / 180;
            aeroOpticalDepth.myDateTime = dateTime; 
            aeroOpticalDepth.Latitude = 40.09 * Math.PI / 180;
            aeroOpticalDepth.Pressure = 0.87;
            aeroOpticalDepth.Temperature = 25;
            double t = aeroOpticalDepth.getTimeScale(dateTime);
            double H = aeroOpticalDepth.getAzenith(t);
            aeroOpticalDepth.getZenith();
            aeroOpticalDepth.getAirmass();
            Console.WriteLine("赤经:"+aeroOpticalDepth.RightAscension*180/Math.PI);
            Console.WriteLine("赤纬:"+aeroOpticalDepth.Declination*180/Math.PI);
            Console.WriteLine("时角:"+H*180/Math.PI);
            Console.WriteLine("天顶角:"+aeroOpticalDepth.Zenith*180/Math.PI);
            Console.WriteLine("方位角:"+aeroOpticalDepth.Azimuth*180/Math.PI);
            Console.WriteLine("大气质量:"+aeroOpticalDepth.AirMass);
        }
    }
}
