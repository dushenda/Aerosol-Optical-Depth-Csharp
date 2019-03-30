using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCSV
{
    class AerosolOpticalDepth
    {
        public static double[] DN0 = new double[] { 63484, 68577, 61448, 57414, 64450, 61584, 92456, 56643 };
        public DateTime myDateTime;
        public double d_d0;
        public double zAngle;

        public double fEartoSun(DateTime dateTime)
        {
            return 0.0;
        }
    }
}
