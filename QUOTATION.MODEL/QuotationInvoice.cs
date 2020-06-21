using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUOTATION.MODEL
{
    public class QuotationInvoice
    {
        public string no { get; set; }
        public string create_date { get; set; }
        public string sale_name { get; set; }
        public string sale_phone { get; set; }
        public string customer_contact { get; set; }
        public string customer_contact_phone { get; set; }
        public string customer_office { get; set; }
        public int guard_boss_amount1 { get; set; }
        public int guard_boss_amount2 { get; set; }
        public string guard_boss_rate { get; set; }
        public string guard_boss_total { get; set; }
        public int guard_man_amount1 { get; set; }
        public int guard_man_amount2 { get; set; }
        public string guard_man_rate { get; set; }
        public string guard_man_total { get; set; }
        public int guard_woman_amount1 { get; set; }
        public int guard_woman_amount2 { get; set; }
        public string guard_woman_rate { get; set; }
        public string guard_woman_total { get; set; }
        public string bali_rate { get; set; }
        public string total { get; set; }
        public string vat { get; set; }
        public string total_vat { get; set; }
        public List<NameVal> equipment_set_1 { get; set; }
        public List<NameVal> equipment_set_2 { get; set; }
        public List<NameVal> note { get; set; }
    }

    public class NameVal
    {
        public NameVal()
        {
            no = 0;
            name = "";
        }
        public string name { get; set; }
        public int no { get; set; }
    }
}
