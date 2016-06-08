using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBS.Models
{
    public enum UserRights
    {
        Developer = 1,
        Superuser = 2,
        Helper = 3
    };

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRights Right { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime LastVisitDate { get; set; }

        public UserModel()
        {
            
        }

    }
}