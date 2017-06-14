using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioscoopB3Web.Models
{
    public class NewsMailModel
    {
        [AllowHtml]
        [UIHint("tinymce_full")]
        [Display(Name = "Tekst")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Vul een onderwerp in")]
        public string Subject { get; set; }
    }
}