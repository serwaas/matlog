using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public static class RandFunq
    {

        
        /// </summary>
        /// Создание рандомной функции
        /// <param name="valO">Число операций</param>
        /// <param name="valP">Число переменных</param>
        /// <returns></returns>
        public static string Operate(string valO,string valP)
        {
            var func = new Funq(valP);
            var rnd = new Random();
           // int indP;
            //int indO1, indO2, indO3;
            
            var indP = rnd.Next(func.perem.Length);

            var indO1 = rnd.Next() % (func.oper.Length);
            var indO2 = rnd.Next() % (func.oper.Length);
            var indO3 = rnd.Next() % (func.oper.Length);
            func.funq += func.perem[indP] + func.oper[indO1];
            //func.delOp(indO);
            func.DelPer(indP);
            indP = rnd.Next(func.perem.Length);
            //if (func.funq[func.funq.Length - 1] == '*')
            func.funq += func.perem[indP];
            if (rnd.Next(3) == 1)
                func.funq = "!(" + func.funq + ")";
            func.DelPer(indP);
            if ((valO == "2")||(valO=="3"))
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
                        func = Op3(func,indO2);//был оп2
                        break;
                }
                //rnd = new Random();
                if (valO == "3")
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
                            func = Op3(func,indO3);//2
                            break;
                    }
                }
            }
            return func.funq;
        }
        private static Funq Op1(Funq fu,int indO)
        {

            var rnd = new Random();
            //int indP;
            //int indP2;
            
            //int indO2;
           var indP = rnd.Next(fu.perem.Length);

           
            fu.funq = "(" + fu.funq + ")";
            fu.funq += fu.oper[indO] + fu.perem[indP];
           // fu.delOp(indO);
            fu.DelPer(indP);
            return fu;

        }
        private static Funq Op2(Funq fu,int indO)
        {

            var rnd = new Random();
            //int indP;
            // indP2;
            
            //int indO2;
            var indP = rnd.Next(fu.perem.Length);

            

            fu.funq = fu.perem[indP] + fu.oper[indO] + fu.funq;
            //fu.delOp(indO);
            fu.DelPer(indP);
            return fu;

        }
        private static Funq Op3(Funq fu,int indO)
        {

            var rnd = new Random();
            var indP = rnd.Next(fu.perem.Length);
            
            // rnd = new Random();

            fu.funq = "(" + fu + ")";

            fu.funq += fu.oper[indO];
            //fu.delPer(indO);
            indO = rnd.Next(fu.oper.Length);
            fu.funq += fu.oper[indO] != "*" ? "(" + fu.perem[indP] + fu.oper[indO] : fu.perem[indP] + fu.oper[indO];
            fu.DelPer(indP);
           // fu.delPer(indO);
            indP = rnd.Next(fu.perem.Length);

            fu.funq += fu.funq[fu.funq.Length - 1] != '*' ? fu.perem[indP] + ")" : fu.perem[indP];


            return fu;

        }

    }
}