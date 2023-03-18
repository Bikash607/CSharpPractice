using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class Hashing_2
    {

        public static int NoOfRightAngleTrangle(List<int> x, List<int> y) 
        {
            int res = 0;
            HashSet<(int,int)> coordinate = new();
            for(int i=0; i<x.Count; i++)
            {
                coordinate.Add((x[i], y[i]));
            }

            return res;
        }
    }
}
