//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_teacher_details
    {
        public tbl_teacher_details()
        {
            this.tbl_Address = new HashSet<tbl_Address>();
            this.tbl_schoolDetails = new HashSet<tbl_schoolDetails>();
        }
    
        public string TeacherRegno { get; set; }
        public string ReferenceCode { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> Del_ind { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual tbl_Gender tbl_Gender { get; set; }
        public virtual ICollection<tbl_Address> tbl_Address { get; set; }
        public virtual ICollection<tbl_schoolDetails> tbl_schoolDetails { get; set; }
    }
}
