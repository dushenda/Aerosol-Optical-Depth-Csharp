using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepByStep
{
    class Program
    {       
        static void Main(string[] args)
        {
            Person person1 =new Person("Bill", "Wagner");
            Console.WriteLine(person1.allCaps());
            Console.ReadLine();
        }
    }
}
