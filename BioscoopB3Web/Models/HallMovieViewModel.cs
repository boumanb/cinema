using BioscoopB3Web.Domain.Concrete;
using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class HallMovieViewModel
    {
        public int HallMovieID { get; set; }
        public int MovieID { get; set; }
        public Order order { get; set; }
        public HallLayout hallLayout { get; set; }
        public HallMovie HallMovie { get; set; }
        public Movie Movie { get; set; }
        public List<Ticket> TempTickets { get; set; }
        public List<Ticket> AllTickets { get; set;}

        public HallMovieViewModel()
        {
            TempTickets = new List<Ticket>();
        }

        public void addTempTicket(Ticket t)
        {
            TempTickets.Add(t);
        }
        public void addTicket(int row, int seat)
        {
            new BioscoopModel().Tickets.Add(new Ticket { Row = row, Seat = seat});
        }
        

    }
}