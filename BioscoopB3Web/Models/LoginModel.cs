using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Het veld email is vereist")]
        [EmailAddress(ErrorMessage = "Geen geldig emailadres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Het wachtwoord is vereist")]
        public string Password { get; set; }
    }
}