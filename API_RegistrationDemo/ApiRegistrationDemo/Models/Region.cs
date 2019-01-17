using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRegistrationDemo.Models
{
    public class Region
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string RegionName { get; set; }
    }
}