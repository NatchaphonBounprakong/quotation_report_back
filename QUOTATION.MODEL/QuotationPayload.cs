using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUOTATION.MODEL
{
    public class QuotationPayload
    {
        public int AUTO_ID { get; set; }
        public string NO { get; set; }
        public Nullable<int> TYPE { get; set; }
        public Nullable<decimal> BOSS_RATE { get; set; }
        public Nullable<int> BOSS_SHIFT_1 { get; set; }
        public Nullable<int> BOSS_SHIFT_2 { get; set; }
        public Nullable<decimal> GUARD_MAN_RATE { get; set; }
        public Nullable<int> GUARD_MAN_SHIFT_1 { get; set; }
        public Nullable<int> GUARD_MAN_SHIFT_2 { get; set; }
        public Nullable<decimal> GUARD_WOMAN_RATE { get; set; }
        public Nullable<int> GUARD_WOMAN_SHIFT_1 { get; set; }
        public Nullable<int> GUARD_WOMAN_SHIFT_2 { get; set; }
        public Nullable<decimal> BAIL_RATE { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public int CONTACT_ID { get; set; }
        public int SALE_OFFICE_ID { get; set; }
       
        public int EMPLOYEE_ID { get; set; }
        public string CUSTOMER { get; set; }
        public string CUSTOMER_CONTACT{ get; set; }
        public string CUSTOMER_CONTACT_PHONE { get; set; }
        public List<int> EQUIPMENT_ID { get; set; }
        public List<string> NOTE { get; set; }
        //public list
    }

    public class QuotationNote
    {
        public int ID { get; set; }
        public string DETAIL { get; set; }
    }
}
