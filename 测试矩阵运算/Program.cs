using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试矩阵运算
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] { 3.33024e-2, 3.512e-4, 5.2e-6 };
            var b = new[] { -2.0582e-3, -4.07e-5, -9e-7 };
            Console.WriteLine(a[1]+b[1]);
            Console.ReadLine();
        }
    }
}
