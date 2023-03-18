using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public interface IPersonBase
    {
        string Name { get; }
        string FatherName { get; }
        string MotherName { get; }
        void Eat()
        {
            Console.WriteLine("Default eatting");
        }

        void Sleeep();
        void Run();
        void Work();
    }
}
