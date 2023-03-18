using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class Employee : PersonBase, IEmployee
    {
        public int Id { get; set; }
        public Department department { get; set; }

        public void GetToalWorkingHour()
        {
            Console.WriteLine("Total work of Emp");
        }

        public void GetYearlyPerformance()
        {
            Console.WriteLine("Total performance of Emp");
        }

        public void GetYearlySalary()
        {
            Console.WriteLine("Total Salary of Emp");
        }
    }
}
