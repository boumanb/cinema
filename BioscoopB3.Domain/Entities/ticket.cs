using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
   public  class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        public int HallMovieID { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
