using BioscoopB3Web.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Concrete
{
    public class EfTicketRepository : ITicketRepository
    {
        private BioscoopModel BioscoopModel;

        public EfTicketRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }

        public bool AddTicket(Ticket ticket)
        {
            BioscoopModel.Tickets.Add(ticket);
            BioscoopModel.SaveChanges();
            return true;
        }

        public IEnumerable<Ticket> GetAllTickets(int hallMovieID)
        {
            return BioscoopModel.Tickets.Where(m => m.HallMovieID == hallMovieID);
        }

        public List<Ticket> GetAllTicketsWithOrderID(int OrderID)
        {
            return BioscoopModel.Tickets.Where(t => t.OrderID == OrderID).ToList();
        }
    }
}
