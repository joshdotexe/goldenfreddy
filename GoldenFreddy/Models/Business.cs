using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class Business
    {
        public Business()
        {
            Created = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string WebSiteUrl { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public DateTime Created { get; set; }
        public int Badges { get; set; }
        public ICollection<BusinessLocation> Locations { get; set; }

    }
}