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
    
    public partial class tbl_schoolDetails
    {
        public int Id { get; set; }
        public string StudentRegno { get; set; }
        public string TeacherRegno { get; set; }
        public string schoolName { get; set; }
        public string schoolAddress { get; set; }
        public string PhNumber { get; set; }
        public string ZoneId { get; set; }
        public string MondalId { get; set; }
        public string DistrictId { get; set; }
        public string Village { get; set; }
    
        public virtual tbl_District tbl_District { get; set; }
        public virtual tbl_Mandal tbl_Mandal { get; set; }
        public virtual tbl_Student_details tbl_Student_details { get; set; }
        public virtual tbl_teacher_details tbl_teacher_details { get; set; }
        public virtual tbl_Zone tbl_Zone { get; set; }
    }
}