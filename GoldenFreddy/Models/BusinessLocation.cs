using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class BusinessLocation
    {
        public BusinessLocation()
        {
            Created = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

    }

}