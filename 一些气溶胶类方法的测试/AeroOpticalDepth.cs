using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一些气溶胶类方法的测试
{
    class AeroOpticalDepth
    {
        public static double[] DN0 = new double[] { 63484, 68577, 61448, 57414, 64450, 61584, 92456, 56643 };//定标系数(可以进行修改)
        public DateTime myDateTime; //时间
        public double D_D0;         //日地修正因子
        //public double UT;           //通用时间(Universal Time),h/h
        //public double deltaTTUT;    //TT-UT,deltat/s
        public double Lonitude;     //经度,theta/rad,[0,2*pi]
        public double Latitude;     //纬度,phi/rad,[-pi/2,pi/2]
        public double Pressure;     //气压,P/atm
        public double Temperature;  //气温,T/℃
        public double RightAscension;//赤经,alpha/rad,[0,2*pi]
        public double Declination;  //赤纬,delta/rad,[-pi/2,pi/2]
        public double HourAngle;    //时角,H/rad,[-pi,pi]
        public double Zenith;       //天顶角,z/rad,[0,pi]
        public double Azimuth;      //方位角,gamma/rad,[-pi,pi]
        public double AirMass;      //大气质量
        public double Taug;         //吸收气体透过率
        public double Taur;         //瑞利散射光学厚度
        public double Taero;        //气溶胶光学厚度


        //计算日-地修正因子
        public double fEarthToSun(DateTime myDateTime)
        {
            int J = myDateTime.DayOfYear;
            D_D0 = 1 + 0.033 * Math.Cos(2 * Math.PI * J / 365);
            return D_D0;
        }

        //时间尺度计算(Time scale computation)
        //返回t
        public double getTimeScale(DateTime dateTime)
        {
            int y = dateTime.Year;
            int m = dateTime.Month;
            if (m<=2)
            {
                m = m + 12;
                y = y - 1;
            }
            double t = (int)(365.25 * (y - 2000)) + (int)(30.6001 * (m + 1)) - (int)(0.01 * y) +
                (double)dateTime.Day + (double)dateTime.Hour / 24 + (double)dateTime.Minute / (24 * 60) +
                (double)dateTime.Second / (21 * 60 * 60) - 21958;
            return t;
        }

        //计算时角 H, 使用算法5
        public double getAzenith(double t)
        {
            //常数赋值
            const double L0 = 1.7527901;
            const double L1 = 1.7202792159e-2;
            const double omegaa = 0.0172019715;
            const double beta = 2.92e-5;
            const double omegan = 9.282e-4;
            const double dbeta = -8.23e-5;
            var omega = new[] {1.49e-3, 4.31e-3, 1.076e-2, 1.575e-2,
                                2.152e-2, 3.152e-2, 2.1277e-1 };
            var a = new[] { 3.33024e-2, 3.512e-4, 5.2e-6 };            
            var d = new[] { 1.27e-5, 1.21e-5, 2.33e-5, 3.49e-5, 2.67e-5, 1.28e-5, 3.14e-5 };
            var b = new[] { -2.0582e-3, -4.07e-5, -9e-7 };
            var Phi = new[] { -2.337, 3.065, -1.533, -2.358, 0.074, 1.547, -0.488 };
            double deltatau = 96.4 + 0.00158 * t;
            double te = t + 1.1574e-5 * deltatau;
            //Step1
            double s1 = Math.Sin(omegaa * te);
            double c1 = Math.Cos(omegaa * te);
            //Step2
            double s2 = 2 * s1 * c1;
            double c2 = (c1 + s1) * (c1 - s1);
            //Step3
            double s3 = s2 * c1 + c2 * s1;
            double c3 = c2 * c1 - s2 * s1;
            //Step4
            //sum为7个累加和
            double sum = 0;
            for (int i = 0; i < 7; i++)
            {
                sum = sum + d[i] * Math.Sin(omega[i] * te + Phi[i]);
            }
            double L = L0 + L1 * te + (a[0] * s1 + a[1] * s2 + a[2] * s3) + 
                dbeta * s1 * Math.Sin(beta * te) + sum;
            //Step5
            double niu = omegan * te - 0.8;
            //Step6
            double deltalambda = 8.34e-5 * Math.Sin(niu);
            //Step7
            double lambda = L + Math.PI + deltalambda;
            //Step8
            double eplson = 4.089567e-1 - 6.19e-9 * te + 4.46e-5 * Math.Cos(niu);
            //Step9
            double slambda = Math.Sin(lambda);
            double clambda = Math.Cos(lambda);
            //Step10
            double seplson = Math.Sin(eplson);
            double ceplson = Math.Sqrt(1 - Math.Pow(seplson, 2));
            //Step11
            double alpha = Math.Atan2(slambda * ceplson, clambda);
            //Step12
            if (alpha<0)
            {
                alpha = alpha + 2 * Math.PI;
            }
            RightAscension=alpha;
            //Step13
            double delta = Math.Asin(slambda * seplson);
            Declination = delta;
            //Step14
            double H = 1.7528311 + 6.300388099 * t + Lonitude - alpha + 0.92 * deltalambda;
            //Step15
            //取余的时候符号与除数要相等
            H = (H + Math.PI) % (2 * Math.PI);
            while (H < 0) { H = H + 2 * Math.PI; }
            H = H - Math.PI;
            HourAngle = H;
            return H;
        }

        //最后一步，计算天顶角z,方位角gamma
        public double getZenith()
        {
            //step1
            double sphi = Math.Sin(Latitude);
            double cphi = Math.Sqrt(1 - Math.Pow(sphi, 2));
            //step2
            double sdelta = Math.Sin(Declination);
            double cdelta = Math.Sqrt(1 - Math.Pow(sdelta, 2));
            //step3
            double sH = Math.Sin(HourAngle);
            double cH = Math.Cos(HourAngle);
            //step4
            double se0 = sphi * sdelta + cphi * cdelta * cH;
            //setp5
            double ep = Math.Asin(se0) - 4.26 * 10e-5 * Math.Sqrt(1 - Math.Pow(se0,2));
            //setp6
            double Gamma = Math.Atan2(sH, cH * sphi - sdelta * cphi / cdelta);
            //step7
            double deltare = 0.08422 * Pressure / (273 + Temperature) / Math.Tan(ep + 0.003138 / (ep + 0.08919));
            //step8
            double z = Math.PI / 2 - ep - deltare;
            Zenith = z;
            Azimuth = Gamma;
            return Zenith;
        }

        public double getAirmass()
        {
            double Airmass = Math.Pow(Math.Cos(Zenith) +
                0.15 * Math.Pow((93.885 - Zenith * 180 / Math.PI), -1.253), -1);
            AirMass = Airmass;
            return Airmass;
        }

        double getTauaero(double DN,double DN0,double m,double D0_D)
        {
            
            return 0.0;
        }
    }
}
