using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class CardPaymentViewModel
    {
        public bool isFalse
        {
            get { return false; }
        }

        [Required(ErrorMessage = "Vul een kaartnummer in")]
        [RegularExpression("^(?:[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9])$",
            ErrorMessage = "Voer een geldig kaartnummer in")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Kies een vervalmaand")]
        [RegularExpression("^(?:[1-9]|([1][0-2]))$",
            ErrorMessage = "Kies een geldige vervalmaand")]
        public int ExpiryMonth { get; set; }

        [Required(ErrorMessage = "Kies een vervaljaar")]
        [RegularExpression("^(?:[1-9][0-9][0-9][0-9])$",
        ErrorMessage = "Kies een geldig vervaljaar")]
        public int ExpiryYear { get; set; }

        [Required(ErrorMessage = "Vul een veiligheidscode in")]
        [RegularExpression("^(?:[0-9][0-9][0-9])$",
        ErrorMessage = "Voer een geldige veiligheidscode in")]
        public string SecurityNumber { get; set; }

        [Compare("isFalse", ErrorMessage = "Uw kaart is verlopen")]
        public bool Expired { get; set; } = false;

        public CardPaymentViewModel()
        {
            
        }

        public void checkExpired(int expiryMonth, int expiryYear)
        {
            this.Expired = false;
            if (DateTime.Now.Year > expiryYear)
            {
                this.Expired = true;
                
            }
            else if(DateTime.Now.Year == expiryYear)
            {
                if(DateTime.Now.Month > expiryMonth)
                {
                    this.Expired = true;
                
                }
                else
                {
                    this.Expired = false;
                
                }
            }
            else
            {
                this.Expired = false;
                
            }
        }
   }
}
