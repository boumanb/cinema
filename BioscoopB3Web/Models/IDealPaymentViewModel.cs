using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class IDealPaymentViewModel
    {
        [Required(ErrorMessage = "Voer uw IBAN in")]
        [RegularExpression("^(?:[a-zA-Z][a-zA-Z][0-9][0-9][a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9])$",
            ErrorMessage = "Voer een geldig IBAN in")]
        public string IBAN { get; set; }

        [Required(ErrorMessage = "Voer uw kaartnummer in")]
        [RegularExpression("^(?:[0-9][0-9][0-9][0-9])$",
            ErrorMessage = "Voer een geldig kaartnummer in")]
        public string Card { get; set; }
    }
}
