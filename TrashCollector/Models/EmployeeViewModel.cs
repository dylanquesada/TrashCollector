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
    public class GetZipList
    {
        [Required]
        public int Zip { get; set; }

    }
}