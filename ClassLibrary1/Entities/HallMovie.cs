using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Entities
{
    public class HallMovie
    {
        [Key]
        public int HallMovieID { get; set; }
        public int MovieID { get; set; }
        public int HallID { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public bool LadiesNight { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
