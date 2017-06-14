using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using TouchUI.Models;

namespace TouchUI.Controllers
{
    public class PrintController : Controller
    {
        IOrderRepository OrderRepo;
        ITicketRepository TicketRepo;
        IMovieRepository MovieRepo;
        IHallMovieRepository HallMovieRepo;

        public PrintController(IOrderRepository OrderRepo, ITicketRepository TicketRepo, IMovieRepository MovieRepo, IHallMovieRepository HallMovieRepo)
        {
            this.OrderRepo = OrderRepo;
            this.TicketRepo = TicketRepo;
            this.MovieRepo = MovieRepo;
            this.HallMovieRepo = HallMovieRepo;
        }

        [HttpGet]
        public ViewResult Print()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Print(PrintViewModel PrintViewModel)
        {
            Order Order = OrderRepo.GetOrderOnPrintID(PrintViewModel.PrintID);

            List<Ticket> Tickets = TicketRepo.GetAllTicketsWithOrderID(Order.OrderID);

            HallMovie HallMovie = HallMovieRepo.GetOneHallMovie(Tickets.FirstOrDefault().HallMovieID);
            
            Movie Movie = MovieRepo.GetOneMovie(HallMovie.MovieID);

            HallMovieViewModel HallMovieViewModel = new HallMovieViewModel();

            HallMovieViewModel.order = Order;
            HallMovieViewModel.TempTickets = Tickets;
            HallMovieViewModel.Movie = Movie;
            HallMovieViewModel.HallMovie = HallMovie;

            return new ViewAsPdf("Order",HallMovieViewModel);
        }
    }
}