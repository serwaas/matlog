using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public class Result
    {

        public bool acc;
        public string rest;
       
        public Result(bool v, string r)
        {
            acc = v;
            rest = r;
        }

    }
}