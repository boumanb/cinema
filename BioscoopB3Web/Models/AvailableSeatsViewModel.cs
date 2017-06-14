using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class AvailableSeatsViewModel
    {
        public HallMovie HallMovie { get; set; }
        public decimal PercentAvailable { get; set; }
        public int SeatsAvailable { get; set; }
        public int TakenSeats { get; set; }
    }
}