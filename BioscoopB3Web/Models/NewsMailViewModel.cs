using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class NewsMailViewModel
    {
        [Required(ErrorMessage = "Het veld email is vereist")]
        [EmailAddress(ErrorMessage = "Geen geldig emailadres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Het veld naam is vereist")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Gebruik alleen letters in je naam")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Het veld achternaam is vereist")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Gebruik alleen letters in je naam")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Het veld aanhef is vereist")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Gebruik alleen letters in je naam")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Laat weten of je de nieuwsbrief wilt")]
        public bool WantsNewsletter { get; set; }

    }
}