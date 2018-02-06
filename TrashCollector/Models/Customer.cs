using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TrashCollector.Models
{
    public class Customer : IdentityUser
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public List<DayOfWeek> PickupDays { get; set; }
        public int Zip { get; set; }

    }
}