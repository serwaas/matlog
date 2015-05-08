using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matlog
{
    public class Result
    {

        public bool acc;
        public String rest;
        //public bool err;

        public Result(bool v, String r)
        {
            this.acc = v;
            this.rest = r;
            // this.err = false;
        }

    }
}