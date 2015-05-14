using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public static class Polinom
    {

        public static string[] Operate(string vector, string[] components)
        {
            var polinom = GePolinom(components);

            var сoefficients = components.Length == 2 ? CalculateCoefficientsTwo(vector) : CalculateCoefficients(vector);
            var result = new string[8];
            var j = 0;
            for (var i = 0; i < polinom.Length; i++)
                if (сoefficients[i] != 0)
                {
                    result[j] = polinom[i];
                    j++;
                }
           
            return j!=0 ? result.Where(w => !string.IsNullOrEmpty(w)).ToArray() : new [] {"0"};
            
        }

        private static string[] GePolinom(string[] components)
        {
            if (components.Length == 3) return new[] {"xyz", "xy", "xz", "yz", "x", "y", "z", "1"};
            components = components.OrderBy(w => w).ToArray();
            var polinom = new string[4];
            polinom[0] = components[0] + "" + components[1];
            polinom[1] = components[0];
            polinom[2] = components[1];
            polinom[3] = "1";
            return polinom;
        }
        private static int[] CalculateCoefficients(string vector)
        {
            var a = vector.Select(w => Convert.ToInt32(w) % 2).ToArray();
            var coeff = new int[8];
            coeff[7] = a[0];
            coeff[6] = coeff[7] + a[1];
            coeff[5] = coeff[7] + a[2];
            coeff[4] = coeff[7] + a[4];
            coeff[3] = coeff[7] + coeff[6] + coeff[5] + a[3];
            coeff[2] = coeff[4] + coeff[6] + coeff[7] + a[5];
            coeff[1] = coeff[4] + coeff[5] + coeff[7] + a[6];
            coeff[0] = coeff[1] + coeff[2] + coeff[3] + coeff[4] + coeff[5] +
                             coeff[6] + coeff[7] + a[7];

            return coeff.Select(c => c % 2).ToArray();

        }
        private static int[] CalculateCoefficientsTwo(string vector)
        {
            var a = vector.Select(w => Convert.ToInt32(w) % 2).ToArray();
            var coeff = new int[4];

            coeff[3] = a[0];
            coeff[2] = coeff[3] + a[1];
            coeff[1] = coeff[3] + a[2];
            coeff[0] = coeff[3] + coeff[1] + coeff[2] + a[3];

            return coeff.Select(c => c % 2).ToArray();
        }
 
    }

    //public class Poli
    //{
    //    public string[] polinom;


    //    public Poli()
    //    {
    //        polinom = new string[8] { "xyz", "xy", "xz", "yz", "x", "y", "z", "1" };

    //    }
    //    public string Operate(string vector)
    //    {
    //        var сoefficients = CalculateCoefficients(vector);
    //        var result = "";
    //        for (var i = 0; i < 8; i++)
    //            if (сoefficients[i] != 0)
    //                result += polinom[i] + "+";

    //        return result.Length != 0 ? result.Substring(0, result.Length - 1) : "0";
    //    }

    //    private int[] CalculateCoefficients(string s)
    //    {
    //        var a = s.Select(w => Convert.ToInt32(w) % 2).ToArray();
    //        //for (var i = 0; i < 8; i++)
    //        //    a[i] = Convert.ToInt32(s[i])%2;

    //        var coeff = new int[8];
    //        coeff[7] = a[0];
    //        coeff[6] = coeff[7] + a[1];
    //        coeff[5] = coeff[7] + a[2];
    //        coeff[4] = coeff[7] + a[4];
    //        coeff[3] = coeff[7] + coeff[6] + coeff[5] + a[3];
    //        coeff[2] = coeff[4] + coeff[6] + a[5];
    //        coeff[1] = coeff[4] + coeff[5] + a[6];
    //        coeff[0] = coeff[1] + coeff[2] + coeff[3] + coeff[4] + coeff[5] +
    //                         coeff[6] + coeff[7] + a[7];

    //        return coeff.Select(c => c % 2).ToArray();

    //    }
    //}
}