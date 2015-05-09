using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    static public class DNF
    {
        static public string SDNF(int lenght, string vector)
        {
            var sdnf = "";

            var x = false;
            var y = false;
            var z = false;
            var t = false;
            for (var i = 0; i < lenght; i++)
            {
                if (vector[i] == '1')
                {
                    sdnf += x == false ? "!x" : "x";
                    sdnf += y == false ? "!y" : "y";
                    sdnf += z == false ? "!z" : "z";
                    if (lenght == 16)
                    {
                        sdnf += t == false ? "!t" : "t";
                    }

                    sdnf += " v ";
                }
                if (lenght == 8)
                    {
                        if (i == 3)
                            x = !x;
                        if ((i % 2 == 1) && (i != 0))
                            y = !y;
                        z = !z;
                    }
                    if (lenght == 16)
                    {
                        if (i == 7)
                            x = !x;
                        if ((i % 4 == 3) && (i != 0))
                            y = !y;
                        if ((i % 2 == 1) && (i != 0))
                            z = !z;
                        t = !t;
                    }
                }

            return sdnf.Substring(0, sdnf.Length - 3);
        }

        static public string SCNF(int lenght, string vector)
        {
            var scnf = "";

            var x = false;
            var y = false;
            var z = false;
            var t = false;
            for (var i = 0; i < lenght; i++)
            {
                if (vector[i] == '0')
                {
                    scnf += "(";
                    scnf += x == false ? "x v" : "!x v";
                    scnf += y == false ? " y v" : " !y v";
                    scnf += z == false ? " z" : " !z";

                    if (lenght == 16)
                    {
                        scnf += t == false ? " v t" : " v !t";
                    }


                    scnf += ")";
                }
                if (lenght == 8)
                    {
                        if (i == 3)
                            x = !x;
                        if ((i % 2 == 1) && (i != 0))
                            y = !y;
                        z = !z;
                    }
                    if (lenght == 16)
                    {
                        if (i == 7)
                            x = !x;
                        if ((i % 4 == 3) && (i != 0))
                            y = !y;
                        if ((i % 2 == 1) && (i != 0))
                            z = !z;
                        t = !t;
                    }
            }
            return scnf;
        }
    }
}