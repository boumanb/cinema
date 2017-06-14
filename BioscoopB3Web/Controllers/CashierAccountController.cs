using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using BioscoopB3Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioscoopB3Web.Controllers
{
    public class CashierAccountController : Controller
    {
        private IHallMovieRepository HallMovieRepo;        
        private ITicketRepository TicketRepo;

        public CashierAccountController(IHallMovieRepository HallMovieRepo, ITicketRepository TicketRepo)
        {
            this.HallMovieRepo = HallMovieRepo;            
            this.TicketRepo = TicketRepo;
        }

        // GET: CashierAccount
        public ActionResult AvailableSeats()
        {
            return View("~/Views/Account/AccountViews/CashierAccountOptions/AvailableSeats.cshtml");
        }

        public ActionResult LoadAvailableSeats()
        {

            IEnumerable<HallMovie> Hms = HallMovieRepo.GetAllHallMovies().Where(h => h.DateTime > DateTime.Now).OrderBy(h => h.DateTime).Take(5);
            int i = 1;

            List<AvailableSeatsViewModel> AvailableSeatsModels = new List<AvailableSeatsViewModel>();

            foreach (HallMovie hm in Hms)
            {
                int FreeSeats = HallMovieRepo.GetOneHallMovie(hm.HallMovieID).Hall.HallLayout.Rows * HallMovieRepo.GetOneHallMovie(hm.HallMovieID).Hall.HallLayout.SeatsPerRow - TicketRepo.GetAllTickets(hm.HallMovieID).Count();
                int TakenSeats = TicketRepo.GetAllTickets(hm.HallMovieID).Count(); 
                int TotalSeats = HallMovieRepo.GetOneHallMovie(hm.HallMovieID).Hall.HallLayout.Rows * HallMovieRepo.GetOneHallMovie(hm.HallMovieID).Hall.HallLayout.SeatsPerRow;

                var PercentAvailable = (int)Math.Round((double)(100 * FreeSeats) / TotalSeats);
                
                AvailableSeatsViewModel x = new AvailableSeatsViewModel()
                {
                    HallMovie = hm,
                    PercentAvailable = PercentAvailable,
                    SeatsAvailable = FreeSeats,
                    TakenSeats = TakenSeats                   
                };

                AvailableSeatsModels.Add(x);

                i++;
            }

            return PartialView("_SeatsAvailable", AvailableSeatsModels);
        }
    }
}