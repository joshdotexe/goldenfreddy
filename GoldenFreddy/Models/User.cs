using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> Roles { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public DateTime Created { get; set; }

        public User()
        {
            Created = DateTime.UtcNow;
        }
    }
}