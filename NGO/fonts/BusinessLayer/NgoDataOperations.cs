using NGO.DataAcessLayer;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.BusinessLayer
{
    public class NgoDataOperations
    {
        NgoDbOperations obj;

        public NgoDataOperations()
        {
            obj = new NgoDbOperations();
        }

        public IEnumerable<Notification> GetNotificationsList()
        {
            return obj.GetNotificationsList();
        }

        internal IEnumerable<Districts> GetDistricts()
        {
            return obj.GetDistricts();
        }

        internal IEnumerable<Zones> GetZones(Models.IteamID DistrictID)
        {
            return obj.GetZone(DistrictID);
        }

        internal IEnumerable<Mandals> GetMandals(IteamID ZoneID)
        {
            return obj.GetMandal(ZoneID);
        }
    }
}