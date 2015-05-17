using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public static class RandFunq
    {

        public static string Operate(string numOfOperations, string numOfValues)
        {
            var func = new Funq(numOfValues);
            var rnd = new Random();
           
            var indP = rnd.Next(func._values.Length);

            var indO1 = rnd.Next() % (func._operations.Length);
            var indO2 = rnd.Next() % (func._operations.Length);
            var indO3 = rnd.Next() % (func._operations.Length);
            func._function += func._values[indP] + func._operations[indO1];
            
            func.DeleteValue(indP);
            indP = rnd.Next(func._values.Length);

            func._function += func._values[indP];
            if (rnd.Next(3) == 1)
                func._function = "!(" + func._function + ")";
            func.DeleteValue(indP);
            if ((numOfOperations == "2")||(numOfOperations=="3"))
            {
                var ind = rnd.Next(1, 3);
               
                switch (ind)
                {
                    case 1:
                        func = Op1(func,indO2);
                        break;
                    case 2:
                        func = Op2(func,indO2);
                        break;
                    default:
                        func = Op3(func,indO2);
                        break;
                }

                if (numOfOperations == "3")
                {
                    ind = rnd.Next(1, 3);
                    switch (ind)
                    {
                        case 1:
                            func = Op1(func,indO3);
                            break;
                        case 2:
                            func = Op2(func,indO3);
                            break;
                        default:
                            func = Op3(func,indO3);
                            break;
                    }
                }
            }
            return func._function;
        }

        private static Funq Op1(Funq fu,int indOperation)
        {
            var rnd = new Random();
            var indValue = rnd.Next(fu._values.Length);
           
            fu._function = "(" + fu._function + ")";
            fu._function += fu._operations[indOperation] + fu._values[indValue];
            fu.DeleteValue(indValue);
            return fu;

        }
        private static Funq Op2(Funq fu,int indOperation)
        {

            var rnd = new Random();

            var indValue = rnd.Next(fu._values.Length);

            fu._function = fu._values[indValue] + fu._operations[indOperation] + fu._function;
            
            fu.DeleteValue(indValue);
            return fu;

        }
        private static Funq Op3(Funq fu,int indOperation)
        {

            var rnd = new Random();
            var indValue = rnd.Next(fu._values.Length);
            
            fu._function = "(" + fu + ")";

            fu._function += fu._operations[indOperation];

            indOperation = rnd.Next(fu._operations.Length);
            fu._function += fu._operations[indOperation] != "*" ? "(" + fu._values[indValue] + fu._operations[indOperation] : fu._values[indValue] + fu._operations[indOperation];
            fu.DeleteValue(indValue);

            indValue = rnd.Next(fu._values.Length);

            fu._function += fu._function[fu._function.Length - 1] != '*' ? fu._values[indValue] + ")" : fu._values[indValue];


            return fu;

        }

    }
}