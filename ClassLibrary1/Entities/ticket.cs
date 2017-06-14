using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BioscoopB3Web.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        public int HallMovieID { get; set; }
        public string Type { get; set; }
        public int Seat { get; set; }
        public int Row { get; set; }
        public int OrderID { get; set; }

    }
}
