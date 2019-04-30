using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Subject
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Subject[] _subjects = new Subject[]
            {
                new Subject {Name = "algoritmy", Value = 100, Time = 3},
              new Subject {Name = "architektura", Value = 20, Time = 2},
              new Subject {Name = "databazy", Value = 60, Time = 4},
              new Subject {Name = "krypto", Value = 40, Time = 1}
            };
            



        }
    }
}
