using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public  class Poli
    {
        public string[] polinom;
        

        public Poli()
        {
            polinom = new string[8] { "xyz", "xy", "xz", "yz", "x", "y", "z", "1" };
           
        }
        public  string Operate(string vector)
        {
            var сoefficients = CalculateCoefficients(vector);
            var result = "";
            for (var i = 0; i < 8; i++)
                if (сoefficients[i] != 0)
                    result += polinom[i] + "+";

            return result.Length != 0 ? result.Substring(0, result.Length - 1) : "0";
        }

        private int[] CalculateCoefficients(string s)
        {
            var a = s.Select(w => Convert.ToInt32(w)%2).ToArray();
            //for (var i = 0; i < 8; i++)
            //    a[i] = Convert.ToInt32(s[i])%2;

            var coeff = new int[8];
            coeff[7] = a[0];
            coeff[6] = coeff[7] + a[1];
            coeff[5] = coeff[7] + a[2];
            coeff[4] = coeff[7] + a[4];
            coeff[3] = coeff[7] + coeff[6] + coeff[5] + a[3];
            coeff[2] = coeff[4] + coeff[6] + a[5];
            coeff[1] = coeff[4] + coeff[5] + a[6];
            coeff[0] = coeff[1] + coeff[2] + coeff[3] + coeff[4] + coeff[5] +
                             coeff[6] + coeff[7] + a[7];

            return coeff.Select(c => c%2).ToArray();
            
        }
    }
}