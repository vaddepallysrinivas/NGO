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
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public decimal? FeeAmount { set; get; }
        public int? Del_ind { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDate { set; get; }
        public int? ModifiedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
    }

    public class IteamID
    {
        public string ID { get; set; }
    }

    public class Districts
    {
        public string Code { get; set; }
        public string DistrictName { get; set; }
    }
    public class Zones
    {
        public string Code { get; set; }
        public string ZoneName { get; set; }
    }
    public class Mandals
    {
        public string Code { get; set; }
        public string MandalName { get; set; }
    }
}