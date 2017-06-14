using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using BioscoopB3Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BioscoopB3Web.Controllers
{
    public class BackOfficeAccountController : Controller
    {

        private IAccountRepository IAccountRepository;
        private IMovieRepository IMovieRepository;
        private IHallRepository IHallRepository;
        private IHallMovieRepository IHallMovieRepository;

        public BackOfficeAccountController(IAccountRepository IAccountRepository, IMovieRepository IMovieRepository, IHallRepository IHallRepository, IHallMovieRepository IHallMovieRepository)
        {
            this.IAccountRepository = IAccountRepository;
            this.IMovieRepository = IMovieRepository;
            this.IHallRepository = IHallRepository;
            this.IHallMovieRepository = IHallMovieRepository;
        }

        // GET: BackOfficeAccount
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult SendNewsMail()
        {
            if (Session["AccountType"] != null && Session["LoggedIn"] != null )
            {
                if (Session["AccountType"].ToString() == "BackOffice")
                {
                    return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/SendNewsMail.cshtml");
                } else
                {
                    return RedirectToAction("Account", "Account");
                }
            }
            else
            {
                return RedirectToAction("Account", "Account");
            }
        }

        [HttpPost]
        public ActionResult SendNewsMail(NewsMailModel Model, HttpPostedFileBase file)
        {
            if (file != null && ModelState.IsValid && Model != null )
            {
                

                IEnumerable<Account> NewsMailReceivers = IAccountRepository.GetAllNewsLetterAccounts();

                string fileName = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("/NewsLetterAttachs/" + fileName));                

                foreach (Account account in NewsMailReceivers)
                {
                    string Greeting = (account.Gender == "Male") ? "Geachte meneer " + account.LastName + "," : "Geachte mevrouw " + account.LastName + ",";

                    var fromAddress = new MailAddress("BioscoopB3@gmail.com", "BioscoopB3");
                    var toAddress = new MailAddress(account.Email, "To Name");
                    const string fromPassword = "BioscoopB3B3B3";
                    string subject = Model.Subject;
                    string body = Greeting + "<br/><br/><br/> " + Model.Text + "<br/><br/>Mvg,<br/><br/> BioscoopB3";                    

                    //Attachment attachment = new Attachment(file.InputStream, fileName);


                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                    })
                    {
                        message.IsBodyHtml = true;
                        message.Attachments.Add( new Attachment(Server.MapPath("/NewsLetterAttachs/" + fileName)));
                        smtp.Send(message);                    
                        
                    }
                    smtp.Dispose();
                }

                string destinationFile = ""+Server.MapPath("/NewsLetterAttachs/" + fileName);
                if (System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Delete(destinationFile);
                }

                ViewBag.SentMail = "Mail is succesvol verzonden";
                return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/SendNewsMail.cshtml");
            }
            else
            {
                ViewBag.NoFile = "Geen bestand geselecteerd";
                return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/SendNewsMail.cshtml");
            }            
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            if (Session["AccountType"] != null && Session["LoggedIn"] != null)
            {
                if (Session["AccountType"].ToString() == "BackOffice")
                {
                    return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddMovie.cshtml");
                }
                else
                {
                    return RedirectToAction("Account", "Account");
                }
            }
            else
            {
                return RedirectToAction("Account", "Account");
            }            
        }

        public ActionResult AddMovie(Movie Movie)
        {
            if (ModelState.IsValid)
            {
                if (IMovieRepository.CheckIfMovieExist(Movie.Title) == false)
                {
                    Movie m = IMovieRepository.AddMovie(Movie);
                    return RedirectToAction("Description", "Movie", new { MovieID = m.MovieID });
                }
                else
                {
                    ViewBag.NoSuccess = "Er bestaat al een film met de titel '" + Movie.Title + "' in de database.";
                    return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddMovie.cshtml");
                }
                
            }
            else
            {
                ViewBag.NoSucces = "Er is iets fout gegaan, zijn alle velden goed ingevoerd?";
                return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddMovie.cshtml", Movie);
            }
        }

        [HttpGet]
        public ActionResult AddHallMovie()
        {

            if (Session["AccountType"] != null && Session["LoggedIn"] != null)
            {
                if (Session["AccountType"].ToString() == "BackOffice")
                {
                    AddHallMovieModel Model = new AddHallMovieModel();
                    Model.AllHalls = IHallRepository.GetAllHalls();
                    Model.AllMovies = IMovieRepository.GetAllMovies().Where(m => m.RunTime > DateTime.Now);
                    Model.AllHallMovies = IHallMovieRepository.GetAllHallMovies();
                    return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddHallMovie.cshtml", Model);
                }
                else
                {
                    return RedirectToAction("Account", "Account");
                }
            }
            else
            {
                return RedirectToAction("Account", "Account");
            }
        }
        [HttpPost]  
        public ActionResult AddHallMovie(AddHallMovieModel AddHallMovieModel, DateTime begintime, DateTime endtime)
        {
            if (ModelState.IsValid)
            {
                AddHallMovieModel.AllHalls = IHallRepository.GetAllHalls();
                AddHallMovieModel.AllMovies = IMovieRepository.GetAllMovies().Where(m => m.RunTime > DateTime.Now);
                AddHallMovieModel.AllHallMovies = IHallMovieRepository.GetAllHallMovies();

                HallMovie HallMovie = new HallMovie()
                {
                    DateTime = begintime,
                    DateTimeEnd = endtime,
                    Hall = IHallRepository.GetOneHall(AddHallMovieModel.HallID),
                    Movie = IMovieRepository.GetOneMovie(AddHallMovieModel.MovieID),
                    HallID = AddHallMovieModel.HallID,
                    MovieID = AddHallMovieModel.MovieID,
                    LadiesNight = false
                };             

                if(HallMovie.DateTime < HallMovie.Movie.RunTime && HallMovie.DateTimeEnd < HallMovie.Movie.RunTime)
                {
                    if(HallMovie.DateTime > DateTime.Now && HallMovie.DateTimeEnd > DateTime.Now) {
                        if (IHallMovieRepository.AddOneHallMovie(HallMovie) == HallMovie)
                        {
                            ViewBag.AddedHallmovie = "Voorstelling toegevoegd: " + IMovieRepository.GetOneMovie(AddHallMovieModel.MovieID).Title + " in zaal " + AddHallMovieModel.HallID + " op " + HallMovie.DateTime.ToShortDateString();
                            return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddHallMovie.cshtml", AddHallMovieModel);
                        }
                        else
                        {
                            HallMovie existing = IHallMovieRepository.AddOneHallMovie(HallMovie);
                            AddHallMovieModel.AllHallMovies = IHallMovieRepository.GetAllHallMovies();
                            ViewBag.ExistingHallmovie = "Er is al een voorstelling in deze zaal op " + existing.DateTime.ToShortDateString() + ": " + existing.Movie.Title + " in zaal " + existing.HallID + " tussen " + existing.DateTime.ToShortTimeString() + " en " + existing.DateTimeEnd.ToShortTimeString();
                            return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddHallMovie.cshtml", AddHallMovieModel);
                        }
                    }
                    else
                    {
                        ViewBag.PlannedPast = "Het is niet mogelijk om een film in het verleden te plannen";
                        return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddHallMovie.cshtml", AddHallMovieModel);
                    }
                }
                else
                {
                    ViewBag.RunTimeEnded = "Film draait tot " + HallMovie.Movie.RunTime + " in de bioscoop, inplannen van " + HallMovie.DateTime + " tot " + HallMovie.DateTimeEnd + " gaat dus niet.";
                    return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddHallMovie.cshtml", AddHallMovieModel);
                }
                
            }
            else
            {
                return View("~/Views/Account/AccountViews/BackOfficeAccountOptions/AddHallMovie.cshtml", AddHallMovieModel);
            }
        }
    }
}