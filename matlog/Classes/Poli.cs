using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public  class Poli
    {
        public string[] polinom ;
        int[] answerJigolo;

        public Poli()
        {
            polinom = new string[8] { "xyz", "xy", "xz", "yz", "x", "y", "z", "1" };
            answerJigolo = new int[8];
        }
        public  string operate(string s)
        {
            var a = new int[8];
            for (int i = 0; i < 8; i++)
                a[i] = Convert.ToInt32(s[i])%2;

            answerJigolo[7] = a[0];
            answerJigolo[6] = answerJigolo[7] + a[1];
            answerJigolo[5] = answerJigolo[7] + a[2];
            answerJigolo[4] = answerJigolo[7] + a[4];
            answerJigolo[3] = answerJigolo[7] + answerJigolo[6] + answerJigolo[5] + a[3];
            answerJigolo[2] = answerJigolo[4] + answerJigolo[6] + a[5];
            answerJigolo[1] = answerJigolo[4] + answerJigolo[5] + a[6];
            answerJigolo[0] = answerJigolo[1] + answerJigolo[2] + answerJigolo[3] + answerJigolo[4] + answerJigolo[5] +
                              answerJigolo[6] + answerJigolo[7] + a[7];


            for (var i = 0; i < 8; i++)
            {
                answerJigolo[i] = (answerJigolo[i] % 2);
            }
            var result = "";
            for (var i = 0; i < 8; i++)
            {
                if (answerJigolo[i] != 0)
                    result += polinom[i] + "+";

            }
            result = result.Length != 0 ? result.Substring(0, result.Length - 1) : "0";
                
            
            return result;
        }
    }
}