using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public class Funq
    {
        public string[] perem;
        public string[] oper;
        public string funq;
        public Funq(string valP)
        {
            perem = valP =="3" ? new [] { "x", "!z", "!x", "y", "z", "!y" } : new [] { "x",  "!x", "y",  "!y" };
            oper = new [] { "*", "V", "->", "<->" };
            funq = "";
        }
        
        public Funq(string[] p, string[] o, string f)
        {
            perem = new string[p.Length];
            for (var i = 0; i < p.Length; i++)
            {
                perem[i] = p[i];
            }
            oper = new string[o.Length];
            for (var i = 0; i < o.Length; i++)
            {
                oper[i] = o[i];
            }
            funq = f;
        }

        public Funq(Funq other)
        {
            perem = new string[other.perem.Length];
            for (var i = 0; i < perem.Length; i++)
            {
                perem[i] = other.perem[i];
            }
            oper = new string[other.oper.Length];
            for (var i = 0; i < oper.Length; i++)
            {
                oper[i] = other.oper[i];
            }
            funq = other.funq;
        }

        public void DelPer(int p)
        {
            var newPerem = new string[perem.Length - 1];

            for (int i = 0, j = 0; i < newPerem.Length; ++i, ++j)
            {
                if (j == p)
                    ++j;

                newPerem[i] = perem[j];
            }
            perem = new string[newPerem.Length];
            for (var j = 0; j < perem.Length; j++)
                perem[j] = newPerem[j];
            //Funq result = new Funq(newPerem, oper, funq);
            //return result;

        }
        /*public void delOp(int o)
        {
            string[] newOper = new string[oper.Length - 1];
            for (int i = 0, j = 0; i < newOper.Length; ++i, ++j)
            {
                if (j == o)
                    ++j;

                newOper[i] = oper[j];
            }
            oper = new string[newOper.Length];
            for (int i = 0; i < newOper.Length; ++i)
            {
                oper[i] = newOper[i];
            }

        }*/
    }
}