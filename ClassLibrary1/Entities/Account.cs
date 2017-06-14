using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BioscoopB3Web.Domain.Entities
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Het veld email is vereist")]
        [EmailAddress(ErrorMessage = "Geen geldig emailadres")]
        public string Email { get; set; }
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Gebruik alleen letters in je naam")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Laat weten of je de nieuwsbrief wilt")]
        public bool WantsNewsletter { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Account type moet ingevuld zijn")]
        public string AccountType { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
                
    }
}
