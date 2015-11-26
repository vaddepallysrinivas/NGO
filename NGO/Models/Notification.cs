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
}