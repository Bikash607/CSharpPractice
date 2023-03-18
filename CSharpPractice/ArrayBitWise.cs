using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class ArrayBitWise
    {
        public static int[] Decode(int[] encoded, int first)
        {
            int[] res = new int[encoded.Length + 1];
            res[0] = first;
            for (int i = 0; i < encoded.Length; i++)
            {
                res[i + 1] = encoded[i] ^ res[i];
            }
            return res;
        }
    }
}
