using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.Models
{
    public class Notification
    {
        public int? NotificationId { set; get; }
        public string Code { set; get; }
        public string NotificationText { set; get; }
        public decimal? FeeAmount { set; get; }
        public bool? Del_ind { set; get; }
        public bool? IsActive { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDate { set; get; }
        public int? ModifiedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public int? Type{set;get;}
    }

    public class IteamID
    {
        public string ID { get; set; }
    }

    public class District
    {
        public string Code { get; set; }
        public string DistrictName { get; set; }
    }
    public class Zone
    {
        public string Code { get; set; }
        public string ZoneName { get; set; }
        public bool? Del_ind { set; get; }
        public bool? IsActive { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDate { set; get; }
        public int? ModifiedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
    }
    public class Mandal
    {
        public string Code { get; set; }
        public string MandalName { get; set; }
    }
    public class TeacherDetails
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SelectedGenderId { get; set; }
        public string Contactno { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAdd { get; set; }
        public string SchoolDistrictId { get; set; }
        public string ScholZoneId { get; set; }
        public string SchoolMandalid { get; set; }
        public string SchoolVillage { get; set; }
    }


    public class TeacherRegDetails
    {
        public string TEACHER_REG { get; set; }
        public string Password { get; set; }
        public string COUPON { get; set; }

    }
}