using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.Models
{
    public class Notification
    {
        public int NotificationId { set; get; }
        public string Code { set; get; }
        public string NotificationText { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public decimal FeeAmount { set; get; }
        public int Del_ind { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedDate { set; get; }
    }
}