using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRegistrationDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }

        public string CountryName { get; set; }
        public string RegionName { get; set; }
    }
}