﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QUOATATIONEntities : DbContext
    {
        public QUOATATIONEntities()
            : base("name=QUOATATIONEntities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<CUSTOMER_CONTACT> CUSTOMER_CONTACT { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<EQUIPMENT> EQUIPMENT { get; set; }
        public virtual DbSet<NOTE> NOTE { get; set; }
        public virtual DbSet<QUOTATION_EQUIPMENT> QUOTATION_EQUIPMENT { get; set; }
        public virtual DbSet<QUOTATION_NOTE> QUOTATION_NOTE { get; set; }
        public virtual DbSet<SALE_OFFICE> SALE_OFFICE { get; set; }
        public virtual DbSet<QUOTATION> QUOTATION { get; set; }
    }
}
