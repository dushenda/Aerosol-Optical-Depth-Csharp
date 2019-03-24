using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepByStep
{
    class Person
    {
        private string Firstname { set; get; }
        private string Lastname { set; get; }

        public Person(string first,string last)
        {
            Firstname = first;
            Lastname = last;
        }

        public void displayName()
        {
            allCaps();
        }

        // public override string ToString() => Firstname + " " + Lastname;

        public override string ToString()
        {
            return Firstname+Lastname;
        }

        public string allCaps()
        {
            Firstname = Firstname.ToUpper();
            Lastname = Lastname.ToUpper();
            return ToString();
        }

    }
}
