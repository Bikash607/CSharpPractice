using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal interface IEmployee : IPersonBase
    {
        int Id { get; }
        Department department { get; }

        void GetYearlySalary();
        void GetYearlyPerformance();
        void GetToalWorkingHour();
    }
}
