using A = Cinema.ASP.Models;
using Cinema.DAL.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.ASP.Models;

namespace Cinema.ASP.Areas.Admin.Models.User
{
    public class UserListItem
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Login { get; set; }
        [DisplayName("Nom")]
        public string FullName { get; set; }
        public string Email { get; set; }
        [DisplayName("Statut utilisateur")]
        public string Role { get; set; }

        public UserListItem()
        {

        }

        public UserListItem(A.User user)
        {
            Id = user.Id;
            Login = user.Login;
            FullName = $"{user.LastName}, {user.FirstName}";
            Email = user.Email;
            Role = user.Role.ToString();
        }
    }
}