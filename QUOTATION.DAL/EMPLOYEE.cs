//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QUOTATION.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            this.QUOTATION = new HashSet<QUOTATION>();
        }
    
        public int AUTO_ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public string SALE_OFFICE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUOTATION> QUOTATION { get; set; }
    }
}
