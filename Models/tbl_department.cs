//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tbl_department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_department()
        {
            this.tbl_courses = new HashSet<tbl_courses>();
        }
    
        public int Dept_ID { get; set; }
        public string Dept_Name { get; set; }
        public string Dept_head { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_courses> tbl_courses { get; set; }
    }
}
