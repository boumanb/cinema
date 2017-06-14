using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
    public class Seat
    {
        [Key]
        public int SeatID { get; set; }
        public int HallMovieID { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool available { get; set; }

        public virtual HallMovie HallMovie { get; set; }
    }
}
