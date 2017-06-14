using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using BioscoopB3Web.Models;
using MessagingToolkit.QRCode.Codec;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Zen.Barcode;

namespace BioscoopB3Web.Controllers
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
        public ViewResult IDealPayment()
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            TempData["hallMovieViewModel"] = hallMovieViewModel;
            return View("IDealPayment");
        }

        [HttpPost]
        public ViewResult IDealPayment(IDealPaymentViewModel ideal)
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            try
            {
                if (ModelState.IsValid)
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
                    } else
                    {
                        while(PrintIDUnique == false)
                        {
                            int NewPrintID = Random.Next(100000000, 999999999);
                            if (OrderRepo.CheckPrintIDExist(NewPrintID) == false)
                            {
                                hallMovieViewModel.order.PrintID = NewPrintID;
                                OrderRepo.AddOrder(hallMovieViewModel.order);
                                PrintIDUnique = true;
                                hallMovieViewModel.order = OrderRepo.GetOrderOnPrintID(NewPrintID);
                            } else
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
                    return View("Success", hallMovieViewModel);
                }
                else
                {
                    TempData["hallMovieViewModel"] = hallMovieViewModel;
                    return View("IDealPayment");
                }
            }
            catch(Exception a)
            {
                return View("IDealPayment");
            }
        }

        [HttpGet]
        public ViewResult CardPayment()
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            TempData["hallMovieViewModel"] = hallMovieViewModel;
            return View("CardPayment");
        }

        [HttpPost]
        public ViewResult CardPayment(CardPaymentViewModel card)
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];

                if (ModelState.IsValid)
                {
                    card.checkExpired(card.ExpiryMonth, card.ExpiryYear);
                    if(card.Expired == false)
                    {
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
                        return View("Success", hallMovieViewModel);
                    }
                    else
                    {
                        TempData["hallMovieViewModel"] = hallMovieViewModel;
                    this.ModelState.AddModelError("Expired", "Uw kaart is verlopen");
                    return View("CardPayment");
                    }
                }
                else
                {
                this.ModelState.AddModelError("Expired", "Uw kaart is verlopen");
                return View("CardPayment");
                }
            }

        
        
        public ActionResult Print()
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            TempData["hallMovieViewModel"] = hallMovieViewModel;
            return new ViewAsPdf("Print", hallMovieViewModel);
        }

        public ActionResult PrintQRCode()
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            TempData["hallMovieViewModel"] = hallMovieViewModel;
            
            QRCodeEncoder enq = new QRCodeEncoder();
            Bitmap img = enq.Encode(hallMovieViewModel.order.PrintID.ToString());
            img.Save(Server.MapPath("../QRCodes/") + hallMovieViewModel.order.PrintID.ToString(), ImageFormat.Jpeg);

            return new ViewAsPdf("PrintQRCode", hallMovieViewModel);
            
        }

        public ActionResult PrintBarCode()
        {
            HallMovieViewModel hallMovieViewModel = (HallMovieViewModel)TempData["hallMovieViewModel"];
            TempData["hallMovieViewModel"] = hallMovieViewModel;
            Code128BarcodeDraw bc128 = BarcodeDrawFactory.Code128WithChecksum;
            System.Drawing.Image img = bc128.Draw("" + hallMovieViewModel.order.PrintID, 40);
            
            img.Save(Server.MapPath("../Barcodes/") + hallMovieViewModel.order.PrintID.ToString(), ImageFormat.Jpeg);

            return new ViewAsPdf("PrintBarCode", hallMovieViewModel);

        }
    }
}