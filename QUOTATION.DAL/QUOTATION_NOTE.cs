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
    
    public partial class QUOTATION_NOTE
    {
        public int AUTO_ID { get; set; }
        public int QUOTATION_ID { get; set; }
        public int NOTE_ID { get; set; }
    
        public virtual NOTE NOTE { get; set; }
        public virtual QUOTATION QUOTATION { get; set; }
    }
}
