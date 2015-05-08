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
                    if (x == false)
                        sdnf += "!x";
                    else
                        sdnf += "x";
                    if (y == false)
                        sdnf += "!y";
                    else
                        sdnf += "y";
                    if (z == false)
                        sdnf += "!z";
                    else
                        sdnf += "z";
                    if (lenght == 16)
                    {
                        if (t == false)
                            sdnf += "!t";
                        else
                            sdnf += "t";
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
                    if (x == false)
                        scnf += "x v";
                    else
                        scnf += "!x v";
                    if (y == false)
                        scnf += " y v";
                    else
                        scnf += " !y v";
                    if (z == false)
                        scnf += " z";
                    else
                        scnf += " !z";

                    if (lenght == 16)
                    {
                        if (t == false)
                            scnf += " v t";
                        else
                            scnf += " v !t";
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