﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineAdmissionSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SmartAdmissionSystemDataEntities : DbContext
    {
        public SmartAdmissionSystemDataEntities()
            : base("name=SmartAdmissionSystemDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<tbl_courses> tbl_courses { get; set; }
        public virtual DbSet<tbl_department> tbl_department { get; set; }
    }
}
