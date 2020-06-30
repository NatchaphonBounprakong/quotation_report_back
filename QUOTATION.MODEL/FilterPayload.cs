using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUOTATION.MODEL
{
    public class FilterPayload
    {
        public string no { get; set; }
        public string customer { get; set; }
        public string customer_contact { get; set; }
        public DateTime create_date_to { get; set; }
        public DateTime create_date_from { get; set; }
        public string create_by { get; set; }
        public string office { get; set; }
    }
}
