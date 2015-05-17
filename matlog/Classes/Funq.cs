using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    
    public class Funq
    {
        public string[] _values;
        public string[] _operations;
        public string _function;


        public Funq(string numOfValues)
        {
            _values = numOfValues =="3" ? new [] { "x", "!z", "!x", "y", "z", "!y" } : new [] { "x",  "!x", "y",  "!y" };
            _operations = new [] { "*", "V", "->", "<->" };
            _function = "";
        }
        
        public Funq(string[] values, string[] operations, string function)
        {
            _values = new string[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                _values[i] = values[i];
            }
            _operations = new string[operations.Length];
            for (var i = 0; i < operations.Length; i++)
            {
                _operations[i] = operations[i];
            }
            _function = function;
        }

        public Funq(Funq other)
        {
            _values = new string[other._values.Length];
            for (var i = 0; i < _values.Length; i++)
            {
                _values[i] = other._values[i];
            }
            _operations = new string[other._operations.Length];
            for (var i = 0; i < _operations.Length; i++)
            {
                _operations[i] = other._operations[i];
            }
            _function = other._function;
        }

        public void DeleteValue(int value)
        {
            var newValues = new string[_values.Length - 1];

            for (int i = 0, j = 0; i < newValues.Length; ++i, ++j)
            {
                if (j == value)
                    ++j;

                newValues[i] = _values[j];
            }
            _values = new string[newValues.Length];
            for (var j = 0; j < _values.Length; j++)
                _values[j] = newValues[j];
           
        }


        public static bool IsEqual(string[] answerOfUser, string[] correctAnswer)
        {
            return answerOfUser.Length == correctAnswer.Length && !answerOfUser.Any(s => correctAnswer.All(w => s != w));
        }
    }
}