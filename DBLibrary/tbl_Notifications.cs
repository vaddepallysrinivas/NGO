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
    
    public partial class tbl_Notifications
    {
        public tbl_Notifications()
        {
            this.tbl_Student_details = new HashSet<tbl_Student_details>();
        }
    
        public int NotificationId { get; set; }
        public string code { get; set; }
        public string NotificationText { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Del_ind { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public decimal FeeAmount { get; set; }
    
        public virtual ICollection<tbl_Student_details> tbl_Student_details { get; set; }
    }
}