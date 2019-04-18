using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCSV
{
    class AeroOpticalDepth
    {
        public static double[] DN0 = new double[] { 63484, 68577, 61448, 57414, 64450, 61584, 92456, 56643 };//定标系数(可以进行修改)
        //public DateTime[] myDateTime; //时间
        public List<DateTime> myDateTime = new List<DateTime>();
        public List<double> D_D0;         //日地修正因子
        //public double UT;           //通用时间(Universal Time),h/h
        //public double deltaTTUT;    //TT-UT,deltat/s
        public double Lonitude;     //经度,theta/rad,[0,2*pi]
        public double Latitude;     //纬度,phi/rad,[-pi/2,pi/2]
        public List<double> Pressure;     //气压,P/atm
        public List<double> Temperature;  //气温,T/℃
        public List<double> RightAscension;//赤经,alpha/rad,[0,2*pi]
        public List<double> Declination;  //赤纬,delta/rad,[-pi/2,pi/2]
        public List<double> HourAngle;    //时角,H/rad,[-pi,pi]
        public List<double> Zenith;       //天顶角,z/rad,[0,pi]
        public List<double> Azimuth;      //方位角,gamma/rad,[-pi,pi]
        public List<double> AirMass;      //大气质量
        //public double Taug;         //吸收气体透过率，这个二不用考虑
        public List<double> Tautot;       //总的光学厚度
        public List<double> Taur;         //瑞利散射光学厚度
        public List<double> Tauaero;        //气溶胶光学厚度
        


        //计算日-地修正因子
        public void fEarthToSun(List<DateTime> myDateTime)
        {
            List<double> D_D0L = new List<double>();
            foreach (var mydatetime in myDateTime)
            {
                int J = mydatetime.DayOfYear;
                D_D0L.Add(1 + 0.033 * Math.Cos(2 * Math.PI * J / 365));
            }
            D_D0 = D_D0L;
        }

        //时间尺度计算(Time scale computation)
        //返回t
        public List<double> getTimeScale(List<DateTime> dateTimes)
        {
            List<double> t = new List<double>();
            foreach (var dateTime in dateTimes)
            {
                int y = dateTime.Year;
                int m = dateTime.Month;
                if (m <= 2)
                {
                    m = m + 12;
                    y = y - 1;
                }
                double h = dateTime.Hour + (double)dateTime.Minute / 60 + (double)dateTime.Second / (60 * 60);
                double tVal = (int)(365.25 * ((double)y - 2000)) + (int)(30.6001 * (double)(m + 1)) - 
                    (int)(0.01 * (double)y) + (double)dateTime.Day + h / 24 - 21958;
                t.Add(tVal);
            }        
            return t;
        }

        //计算时角 H, 使用算法5
        public List<double> getHourAngle(List<double> ts)
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
            //时角，赤经，赤纬的中间存储变量
            List<double> H = new List<double>();
            List<double> RA = new List<double>();
            List<double> Dec = new List<double>();
            foreach (var t in ts)
            {
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
                if (alpha < 0)
                {
                    alpha = alpha + 2 * Math.PI;
                }
                RA.Add(alpha);
                //Step13
                double delta = Math.Asin(slambda * seplson);
                Dec.Add(delta);
                //Step14
                double HVal = 1.7528311 + 6.300388099 * t + Lonitude - alpha + 0.92 * deltalambda;
                //Step15
                //取余的时候符号与除数要相等
                HVal = (HVal + Math.PI) % (2 * Math.PI);
                while (HVal < 0) { HVal = HVal + 2 * Math.PI; }
                HVal = HVal - Math.PI;
                H.Add(HVal);
                //存储到属性
                RightAscension = RA;
                Declination = Dec;
                HourAngle = H;
            }            
            return H;
        }

        //最后一步，计算天顶角z,方位角gamma
        public List<double> getZenith()
        {
            List<double> zenith = new List<double>();
            List<double> azimuth = new List<double>();
            for (int i = 0; i < myDateTime.Count; i++)
            {
                //step1
                double sphi = Math.Sin(Latitude);
                double cphi = Math.Sqrt(1 - Math.Pow(sphi, 2));
                //step2
                double sdelta = Math.Sin(Declination[i]);
                double cdelta = Math.Sqrt(1 - Math.Pow(sdelta, 2));
                //step3
                double sH = Math.Sin(HourAngle[i]);
                double cH = Math.Cos(HourAngle[i]);
                //step4
                double se0 = sphi * sdelta + cphi * cdelta * cH;
                //setp5
                double ep = Math.Asin(se0) - 4.26 * 10e-5 * Math.Sqrt(1 - Math.Pow(se0, 2));
                //setp6
                double Gamma = Math.Atan2(sH, cH * sphi - sdelta * cphi / cdelta);
                //step7
                double deltare = 0.08422 * Pressure[i] / (273 + Temperature[i]) / Math.Tan(ep + 0.003138 / (ep + 0.08919));
                //step8
                double z = Math.PI / 2 - ep - deltare;
                zenith.Add(z);
                azimuth.Add(Gamma);
                Zenith = zenith;
                Azimuth = azimuth;
            }
           
            return Zenith;
        }

        public void getAirmass()
        {
            List<double> AirMassL = new List<double>();
            foreach (var z in Zenith)
            {                
                double Airmass = Math.Pow(Math.Cos(z) +
                        0.15 * Math.Pow((93.885 - z * 180 / Math.PI), -1.253), -1);
                AirMassL.Add(Airmass);
            }
            AirMass = AirMassL;
        }

        //DN0是定标参数，也就是公式的那个常数，DN就是读取的数据的值，lambda是波长(μm),输入nm
        //Height是海拔(Km)
        public void getTauaero(double DN0,List<double> DNs,double lambda,double Height)
        {
            //计算总的光学厚度
            List<double> TautotL = new List<double>();
            lambda = lambda / 1000;
            for (int i = 0; i < DNs.Count; i++)
            {
                double tautot = (Math.Log(DN0) - Math.Log(DNs[i]/D_D0[i])) / AirMass[i];
                TautotL.Add(tautot);
            }
            Tautot = TautotL;
            //计算瑞利散射光学厚度
            List<double> TaurL = new List<double>();
            foreach (var pre in Pressure)
            {
                double TaurVal = 0.008569 * Math.Pow(lambda, -4) *
                     (1 + 0.0113 * Math.Pow(lambda, -2) + 0.000013 * Math.Pow(lambda, -4)) *
                     ((pre * 1000) / 1013.25) * Math.Exp(-0.125 * Height);
                TaurL.Add(TaurVal);
            }
            Taur = TaurL;
            //计算气溶胶光学厚度，这里不考虑气体吸收
            List<double> TauaeroL = new List<double>();
            for (int i = 0; i < Tautot.Count; i++)
            {
                double TauaeroVal = Tautot[i] - Taur[i];
                TauaeroL.Add(TauaeroVal);
            }
            Tauaero = TauaeroL;
        }
    }
}
