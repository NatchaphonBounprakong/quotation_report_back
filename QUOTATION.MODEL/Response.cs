using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUOTATION.MODEL
{
    public class Response
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object result { get; set; }
    }
}
