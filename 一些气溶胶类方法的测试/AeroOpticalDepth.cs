using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一些气溶胶类方法的测试
{
    class AeroOpticalDepth
    {
        public static double[] DN0 = new double[] { 63484, 68577, 61448, 57414, 64450, 61584, 92456, 56643 };
        public DateTime myDateTime; //时间
        public double d_d0;         //日地修正因子
        public double Lonitude;     //经度
        public double Latitude;     //纬度
        public double zAngle;       //天顶角
        public double taug;         //吸收气体透过率
        public double taur;         //瑞利散射光学厚度
        public double taero;        //气溶胶光学厚度


        //计算日-地修正因子
        public double fEarthToSun(DateTime myDateTime)
        {
            int J = myDateTime.DayOfYear;
            d_d0 = 1 + 0.033 * Math.Cos(2 * Math.PI * J / 365);
            return d_d0;
        }


        //计算天顶角

        //
    }
}
