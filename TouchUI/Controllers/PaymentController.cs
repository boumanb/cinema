using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rotativa;
using System.Web.Mvc;
using TouchUI.Models;

namespace TouchUI.Controllers
{
    public class PaymentController : Controller
    {
        ITicketRepository TicketRepo;
        IOrderRepository OrderRepo;

        public PaymentController(ITicketRepository TicketRepo, IOrderRepository OrderRepo)
        {
            this.TicketRepo = TicketRepo;
            this.OrderRepo = OrderRepo;
        }

        [HttpGet]
        public ViewResult PinPayment()
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            TempData["hallMovieViewModel"] = hallMovieViewModel;
            return View("Payment");
        }

        [HttpPost]
        public ActionResult PinPayment(HallMovieViewModel HallMovieViewModel)
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            hallMovieViewModel.Saldo = HallMovieViewModel.Saldo;
            try
            {
                if (HallMovieViewModel.Saldo > hallMovieViewModel.order.TotalPrice)
                {

                    //hallMovieViewModel.order.OrderID = OrderRepo.GetMaxOrderID() + 1;

                    bool PrintIDUnique = false;

                    Random Random = new Random();

                    int PrintID = Random.Next(100000000, 999999999);

                    if (OrderRepo.CheckPrintIDExist(PrintID) == false)
                    {
                        hallMovieViewModel.order.PrintID = PrintID;
                        OrderRepo.AddOrder(hallMovieViewModel.order);
                        hallMovieViewModel.order = OrderRepo.GetOrderOnPrintID(PrintID);
                    }
                    else
                    {
                        while (PrintIDUnique == false)
                        {
                            int NewPrintID = Random.Next(100000000, 999999999);
                            if (OrderRepo.CheckPrintIDExist(NewPrintID) == false)
                            {
                                hallMovieViewModel.order.PrintID = NewPrintID;
                                OrderRepo.AddOrder(hallMovieViewModel.order);
                                PrintIDUnique = true;
                                hallMovieViewModel.order = OrderRepo.GetOrderOnPrintID(NewPrintID);
                            }
                            else
                            {
                                PrintIDUnique = false;
                            }
                        }
                    }



                    foreach (Ticket ticket in hallMovieViewModel.TempTickets)
                    {
                        ticket.OrderID = hallMovieViewModel.order.OrderID;
                        TicketRepo.AddTicket(ticket);
                    }

                    TempData["hallMovieViewModel"] = hallMovieViewModel;
                    return new ViewAsPdf("Succes", hallMovieViewModel);
                }
                else
                {
                    ViewBag.Error = "Onvoldoende saldo";
                    TempData["hallMovieViewModel"] = hallMovieViewModel;
                    return View("Payment");
                }
            }
            catch (Exception a)
            {
                return View("Payment");
            }
        }
    }
}