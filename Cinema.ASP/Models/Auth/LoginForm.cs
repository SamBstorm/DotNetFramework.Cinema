using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.ASP.Models.Auth
{
    public class LoginForm
    {
        [DisplayName("Identifiant ou e-mail :")]
        [Required]
        [MinLength(3)]
        public string Login { get; set; }
        [DisplayName("Mot de passe :")]
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(32)]
        [MinLength(4)]
        public string Password { get; set; }
    }
}