using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
    public class Movie
    {
        [Key]
        public int MovieID {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public bool ThreeD { get; set; }
        public string Language { get; set; }
        public int Subtitles { get; set; }
        public string Genre { get; set; }
        public string Age { get; set; }
        public string RunTime { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Imdb { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
