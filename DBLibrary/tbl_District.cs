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
    
    public partial class tbl_District
    {
        public tbl_District()
        {
            this.tbl_Address = new HashSet<tbl_Address>();
            this.tbl_Mandal = new HashSet<tbl_Mandal>();
            this.tbl_schoolDetails = new HashSet<tbl_schoolDetails>();
        }
    
        public string Code { get; set; }
        public string DistrictName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int Districtid { get; set; }
        public string zonecode { get; set; }
    
        public virtual ICollection<tbl_Address> tbl_Address { get; set; }
        public virtual tbl_Zone tbl_Zone { get; set; }
        public virtual ICollection<tbl_Mandal> tbl_Mandal { get; set; }
        public virtual ICollection<tbl_schoolDetails> tbl_schoolDetails { get; set; }
    }
}
