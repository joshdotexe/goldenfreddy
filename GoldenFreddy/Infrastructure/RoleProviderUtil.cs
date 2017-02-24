using GoldenFreddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenFreddy.Infrastructure
{
    public class RoleProviderUtil : System.Web.Security.RoleProvider
    {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                return "GoldenFreddy";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (GoldenFreddyDb db = new GoldenFreddyDb())
            {
                string[] roles = new string[] { };
                int id = int.Parse(username);
                User user = db.Users.Include("Roles").FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    return user.Roles.Select(r => r.Role).ToArray();
                }
                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}