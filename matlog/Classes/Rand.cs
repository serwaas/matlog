using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public static class Rand
    {

        
        /// </summary>
        /// Создание рандомной функции
        /// <param name="valO">Число операций</param>
        /// <param name="valP">Число переменных</param>
        /// <returns></returns>
        public static string operat(string valO,string valP)
        {
            Funq func = new Funq(valP);
            Random rnd = new Random();
            int indP;
            int indO1, indO2, indO3;
            
            indP = rnd.Next(func.perem.Length);

            indO1 = rnd.Next() % (func.oper.Length);
            indO2 = rnd.Next() % (func.oper.Length);
            indO3 = rnd.Next() % (func.oper.Length);
            func.funq += func.perem[indP] + func.oper[indO1];
            //func.delOp(indO);
            func.delPer(indP);
            indP = rnd.Next(func.perem.Length);
            //if (func.funq[func.funq.Length - 1] == '*')
            func.funq += func.perem[indP];
            if (rnd.Next(3) == 1)
                func.funq = "!(" + func.funq + ")";
            func.delPer(indP);
            if ((valO == "2")||(valO=="3"))
            {
                int ind;
                // rnd = new Random();
                
                ind = rnd.Next(1, 3);
                if (ind == 1)
                    func = op1(func,indO2);
                else
                    if (ind == 2)
                        func = op2(func,indO2);
                    else
                        func = op2(func,indO2);
                //rnd = new Random();
                if (valO == "3")
                {
                    ind = rnd.Next(1, 3);
                    if (ind == 1)
                        func = op1(func,indO3);
                    else
                        if (ind == 2)
                            func = op2(func,indO3);
                        else
                            func = op2(func,indO3);

                }
            }
            return func.funq;
        }
        private static Funq op1(Funq fu,int indO)
        {

            Random rnd = new Random();
            int indP;
            //int indP2;
            
            //int indO2;
            indP = rnd.Next(fu.perem.Length);

           
            fu.funq = "(" + fu.funq + ")";
            fu.funq += fu.oper[indO] + fu.perem[indP];
           // fu.delOp(indO);
            fu.delPer(indP);
            return fu;

        }
        private static Funq op2(Funq fu,int indO)
        {

            Random rnd = new Random();
            int indP;
            // indP2;
            
            //int indO2;
            indP = rnd.Next(fu.perem.Length);

            

            fu.funq = fu.perem[indP] + fu.oper[indO] + fu.funq;
            //fu.delOp(indO);
            fu.delPer(indP);
            return fu;

        }
        private static Funq op3(Funq fu,int indO)
        {

            Random rnd = new Random();
            int indP;

            

            indP = rnd.Next(fu.perem.Length);
            
            // rnd = new Random();

            fu.funq = "(" + fu + ")";

            fu.funq += fu.oper[indO];
            //fu.delPer(indO);
            indO = rnd.Next(fu.oper.Length);
            if (fu.oper[indO] != "*")
                fu.funq += "(" + fu.perem[indP] + fu.oper[indO];
            else
                fu.funq += fu.perem[indP] + fu.oper[indO];
            fu.delPer(indP);
           // fu.delPer(indO);
            indP = rnd.Next(fu.perem.Length);

            if (fu.funq[fu.funq.Length - 1] != '*')
                fu.funq += fu.perem[indP] + ")";
            else
                fu.funq += fu.perem[indP];



            return fu;

        }

    }
}