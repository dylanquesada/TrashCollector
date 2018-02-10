using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class EmployeeViewModel
    {
    }
    public class GetZipListViewModel
    {
        [Required]
        [DataType(DataType.PostalCode)]
        public int Zip { get; set; }
        public List<PickupModel> Pickups { get; set;}
        public PickupModel Label { get; set; }
    }
    public class ShowRouteListViewModel
    {
        public List<string> list { get; set; }
    }
}