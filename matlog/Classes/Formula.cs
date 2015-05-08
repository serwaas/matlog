using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public class Formula
    {
        private Dictionary<string, bool> variables;
        public int error;


        public Formula()
        {
            variables = new Dictionary<string, bool>();
            error = 0;

        }

        public void SetVariable(string Name, bool Value)
        {
            variables.Add(Name, Value);
        }



        public Result Operate(string s)
        {

            Result result = Equiv(s);
            variables.Remove("X");
            variables.Remove("Y");
            variables.Remove("Z");
            variables.Remove("x");
            variables.Remove("y");
            variables.Remove("z");
            return result;

        }

        /// ///////////////////////////////////////////////////////////////////////////////

        private Result Equiv(string s)
        {
            var current = Implic(s);
            var acc = current.acc;

            while (current.rest.Length > 2)
            {
                if (!((current.rest[0] == '<') && (current.rest[1] == '-') && (current.rest[2] == '>'))) break;

                var next = current.rest.Substring(3);

                current = Implic(next);
                acc = acc == current.acc;

            }
            return new Result(acc, current.rest);
        }


        /// ///////////////////////////////////////////////////////////////////////////////

        private Result Bracket(string s)
        {

            if ((s.Length != 0) && (s[0] == '('))
            {

                var r = Equiv(s.Substring(1));
                if ((r.rest.Length != 0) && (r.rest[0] == ')'))
                {
                    r.rest = r.rest.Substring(1);
                }
                else
                {
                    error = 1;
                    r = new Result(false, "");
                }
                return r;
            }
            return Variable(s);
        }

        /// ///////////////////////////////////////////////////////////////////////////////

        private Result Variable(string s)
        {
            string f = "";

            // ищем название функции или переменной
            // имя обязательно должна начинаться с буквы
            if ((s.Length != 0) && (Char.IsLetter(s[0])))
            {
                f += s[0];
                bool value;
                if (variables.TryGetValue(f, out value) == true)
                    return new Result(variables[f], s.Substring(1));
                else
                {
                    error = 2;
                    return new Result(false, "");
                }
            }
            ////////////////////////////////////////////////////////////////////////////////
            else
            {
                error = 3;
                return new Result(false, "");
            }
            /* error = true;
             return new Result(false, "");*/
        }

        /// ///////////////////////////////////////////////////////////////////////////////

        private Result Implic(string s)
        {
            //Result current = Bracket(s);
            Result current = Or(s);
            bool acc = current.acc;

            while (current.rest.Length > 1)
            {
                if (!((current.rest[0] == '-') && (current.rest[1] == '>'))) break;


                string next = current.rest.Substring(2);

                current = Or(next);
                if ((acc == true) && (current.acc == false))
                    acc = false;
                else
                    acc = true;

            }
            return new Result(acc, current.rest);
        }

        /// ///////////////////////////////////////////////////////////////////////////////

        private Result Or(string s)
        {
            //Result current = Bracket(s);
            var current = And(s);
            var acc = current.acc;

            while (current.rest.Length > 0)
            {
                if (current.rest[0] != 'V') break;



                var next = current.rest.Substring(1);

                current = And(next);
                acc = acc || current.acc;

            }
            return new Result(acc, current.rest);
        }

        /// ///////////////////////////////////////////////////////////////////////////////

        private Result And(string s)
        {
            //Result current = Bracket(s);
            var current = No(s);
            var acc = current.acc;

            while (current.rest.Length > 0)
            {
                if (current.rest[0] != '*') break;

                var next = current.rest.Substring(1);

                current = No(next);
                acc = acc && current.acc;

            }
            return new Result(acc, current.rest);
        }

        /// ///////////////////////////////////////////////////////////////////////////////

        private Result No(string s)
        {
            Result current; //= Bracket(s);
            //Result current = and(s);
            if (s[0] == '!')
            {
                current = Bracket(s.Substring(1));
                current.acc = !current.acc;
            }
            else
                current = Bracket(s);


            var acc = current.acc;

            while (true)
            {
                if (current.rest.Length == 0)
                    return current;

                if (current.rest[0] != '!')
                    return current;

                var next = current.rest.Substring(1);
                current = Bracket(next);
                acc = !current.acc;
                current = new Result(acc, current.rest);

            }

        }

    }
}