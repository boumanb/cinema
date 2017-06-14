using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BioscoopB3Web.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int MovieID {get; set;}
        [Required(ErrorMessage = "Vul aub de titel van de film in")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Vul aub de beschrijving van de film in")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vul aub de tijdsduur van de film in")]
        public int Length { get; set; }
        [Required(ErrorMessage = "Vul in of de film in 3D is")]
        public bool ThreeD { get; set; }
        [Required(ErrorMessage = "Vul aub de taal in van de film")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Laat aub weten of de film ondertiteling heeft of niet")]
        public bool Subtitles { get; set; }
        [Required(ErrorMessage = "Vul aub het genre in van de film")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Vul aub de minimumleeftijd in voor de film")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Vul aub in tot wanneer de film draait")]
        public DateTime RunTime { get; set; }
        [Required(ErrorMessage = "Vul aub de regisseur van de film in")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Vul aub de acteurs van de film in")]
        public string Actor { get; set; }
        public string Imdb { get; set; }
        public string Trailer { get; set; }
        public string Site { get; set; }
        public string ImgUrl { get; set; }
    }
}
