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

        public string GetVector(string formula, string[] vars)
        {
            var res = "";
            if (vars.Length < 2 || vars.Length > 3) return res;
            if (vars.Length == 3)
                for (var x = 0; x < 2; x++)
                    for (var y = 0; y < 2; y++)
                        for (var z = 0; z < 2; z++)
                        {
                            SetVariable(vars[0], x != 0);
                            SetVariable(vars[1], y != 0);
                            SetVariable(vars[2], z != 0);

                            res += Operate(formula).acc == false ? "0" : "1";
                        }
            else
                for (var x = 0; x < 2; x++)
                    for (var y = 0; y < 2; y++)
                    {
                        SetVariable(vars[0], x != 0);
                        SetVariable(vars[1], y != 0);

                        res += Operate(formula).acc == false ? "0" : "1";
                    }
            return res;
        }

        public void SetVariable(string name, bool value)
        {
            variables.Add(name, value);
        }

        public Result Operate(string s)
        {
            var result = Equiv(s);

            variables.Remove("x");
            variables.Remove("y");
            variables.Remove("z");
            return result;
        }

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

        private Result Variable(string s)
        {
            var f = "";

            // ищем название переменной
            // имя обязательно должна начинаться с буквы
            if ((s.Length != 0) && (Char.IsLetter(s[0])))
            {
                f += s[0];
                bool value;
                if (variables.TryGetValue(f, out value))
                    return new Result(variables[f], s.Substring(1));
                error = 2;
                return new Result(false, "");
            }

            error = 3;
            return new Result(false, "");
            
        }

        private Result Implic(string s)
        {
            var current = Or(s);
            var acc = current.acc;

            while (current.rest.Length > 1)
            {
                if (!((current.rest[0] == '-') && (current.rest[1] == '>'))) break;

                var next = current.rest.Substring(2);

                current = Or(next);
                if (acc && !current.acc)
                    acc = false;
                else
                    acc = true;
            }
            return new Result(acc, current.rest);
        }

        private Result Or(string s)
        {

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

        private Result And(string s)
        {

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

        private Result No(string s)
        {
            Result current;
            if (s[0] == '!')
            {
                current = Bracket(s.Substring(1));
                current.acc = !current.acc;
            }
            else
                current = Bracket(s);

            var newAcc = current.acc;

            while (true)
            {
                if (current.rest.Length == 0)
                    return current;

                if (current.rest[0] != '!')
                    return current;

                var next = current.rest.Substring(1);
                current = Bracket(next);
                newAcc = current.acc = !current.acc;
                current = new Result(newAcc = current.acc, current.rest);
            }
        }
    }
}