using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class PersonBase : IPersonBase
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public void Eat()
        {
            Console.WriteLine("Base person is eatting");
        }
        public void Run()
        {
            Console.WriteLine("Base person is running");
        }

        public void Sleeep()
        {
            Console.WriteLine("Base person is sleeping");
        }

        public void Work()
        {
            Console.WriteLine("Base person is working");
        }
    }
}
