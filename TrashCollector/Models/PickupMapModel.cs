using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickupMapModel
    {
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Day { get; set; }
        public string Zip { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}