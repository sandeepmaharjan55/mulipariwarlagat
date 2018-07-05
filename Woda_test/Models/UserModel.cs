using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Woda_test.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
        public virtual ICollection<UserRole>Roles { get; set; }
        public string Email { get; set; }
       
        public string Name { get; set; }
        public string Designation { get; set; }
    }
    public class Role
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}