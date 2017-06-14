using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouchUI.Models;

namespace TouchUI.Controllers
{
    public class HallMovieController : Controller
    {
        private IHallMovieRepository HallMovieRepo;
        private IMovieRepository MovieRepo;
        private ITicketRepository TicketRepo;
        private IHallLayoutRepository HallLayoutRepo;

        public HallMovieController(IHallMovieRepository HallMovieRepo, IMovieRepository MovieRepo, ITicketRepository TicketRepo, IHallLayoutRepository HallLayoutRepo)
        {
            this.HallMovieRepo = HallMovieRepo;
            this.MovieRepo = MovieRepo;
            this.TicketRepo = TicketRepo;
            this.HallLayoutRepo = HallLayoutRepo;
        }


        [HttpGet]
        public ViewResult Description(int HallMovieID = 0)
        {

            if (HallMovieID.Equals(0)) /*|| HallMovieID > iHallMovieRepository.GetAllHallMovies().Count()*/
            {
                return View("Description");
            }
            else
            {
                int FreeSeats = HallMovieRepo.GetOneHallMovie(HallMovieID).Hall.HallLayout.Rows * HallMovieRepo.GetOneHallMovie(HallMovieID).Hall.HallLayout.SeatsPerRow - TicketRepo.GetAllTickets(HallMovieID).Count();
                ViewBag.FreeSeats = FreeSeats;
                HallMovieViewModel model = new HallMovieViewModel()
                {
                    HallMovie = HallMovieRepo.GetOneHallMovie(HallMovieID)


                };

                return View("Description", model);
            }
        }

        [HttpPost]
        public ViewResult Description(HallMovieViewModel hallMovieViewModel)
        {
            hallMovieViewModel.HallMovie = HallMovieRepo.GetOneHallMovie(hallMovieViewModel.HallMovieID);
            hallMovieViewModel.hallLayout = HallLayoutRepo.GetOneHallLayout(hallMovieViewModel.HallMovie.HallID);

            hallMovieViewModel.AllTickets = TicketRepo.GetAllTickets(hallMovieViewModel.HallMovieID).ToList();
            int tickets = hallMovieViewModel.order.getTotalTickets();

            if (hallMovieViewModel.order.TotalTickets == 0)
            {
                ViewBag.ticketAmountError = "U heeft geen kaartjes geselecteerd.";
                TempData["hallMovieViewModel"] = hallMovieViewModel;
                return View("Description", hallMovieViewModel);
            }
            TempData["hallMovieViewModel"] = hallMovieViewModel;
            return View("Selection", hallMovieViewModel);

        }

        [HttpPost]
        public ViewResult Selection(int[] rows, int[] selectedSeats)
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];

            if (selectedSeats == null || hallMovieViewModel.order.getTotalTickets() != selectedSeats.Count())
            {
                ViewBag.seatError = "U heeft niet het juiste aantal stoelen geselecteerd. u heeft: " + hallMovieViewModel.order.getTotalTickets() + " ticket(s) besteld.";
                TempData["hallMovieViewModel"] = hallMovieViewModel;
                return View("Selection", hallMovieViewModel);
            }

            int normalTicketsProcessed = 0, elderlyTicketsProcessed = 0, childTicketsProcessed = 0, studentTicketsProcessed = 0;
            foreach (int seat in selectedSeats)
            {
                String type = "";

                int row = rows[seat - 1];
                if (hallMovieViewModel.order.NormalTickets != 0 && hallMovieViewModel.order.NormalTickets > normalTicketsProcessed)
                {
                    /*process */
                    type = "Standaard";

                    normalTicketsProcessed++;
                }
                else if (hallMovieViewModel.order.ElderlyTickets != 0 && hallMovieViewModel.order.ElderlyTickets > elderlyTicketsProcessed)
                {
                    /*process */
                    type = "65+";
                    elderlyTicketsProcessed++;
                }
                else if (hallMovieViewModel.order.ChildTickets != 0 && hallMovieViewModel.order.ChildTickets > childTicketsProcessed)
                {
                    /*process */
                    type = "Kind";
                    childTicketsProcessed++;
                }
                else if (hallMovieViewModel.order.StudentTickets != 0 && hallMovieViewModel.order.StudentTickets > studentTicketsProcessed)
                {
                    /*process */
                    type = "Student";
                    studentTicketsProcessed++;
                }


                hallMovieViewModel.addTempTicket(new Ticket { HallMovieID = hallMovieViewModel.HallMovieID, Type = type, Seat = seat, Row = row, });
            }
            hallMovieViewModel.HallMovie = HallMovieRepo.GetOneHallMovie(hallMovieViewModel.HallMovieID);
            hallMovieViewModel.hallLayout = HallLayoutRepo.GetOneHallLayout(hallMovieViewModel.HallMovie.HallID);
            hallMovieViewModel.Movie = MovieRepo.GetOneMovie(hallMovieViewModel.MovieID);

            Discount discount = new Discount(hallMovieViewModel.order, hallMovieViewModel.HallMovie, hallMovieViewModel.Movie);
            if (hallMovieViewModel.HallMovie.LadiesNight == true)
            {
                hallMovieViewModel.order.NormalTicketsPrice = discount.calcLadiesNight();
                hallMovieViewModel.order.TotalPrice = discount.calcTotalPrice();
            }
            else
            {
                hallMovieViewModel.order.StudentTicketsPrice = discount.calcStudentDiscount();
                hallMovieViewModel.order.ChildTicketsPrice = discount.calcChildDiscount();
                hallMovieViewModel.order.ElderlyTicketsPrice = discount.calcElderlyDiscount();
                hallMovieViewModel.order.NormalTicketsPrice = discount.calcNoDiscount();
                hallMovieViewModel.order.TotalPrice = discount.calcTotalPrice();
                hallMovieViewModel.order.PopcornArrangementPrice = discount.calcPopcornArrangementPrice();
            }

            TempData["hallMovieViewModel"] = hallMovieViewModel;
            return View("Overview", hallMovieViewModel);

        }

        public ActionResult Selection(HallMovieViewModel hallMovieViewModel)
        {

            return new EmptyResult();
        }

        public ViewResult Pay()
        {
            return View();
        }
    }
}
