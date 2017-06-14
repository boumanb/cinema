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
    public class AccountController : Controller
    {
        IAccountRepository CustomerRepo;
        public AccountController(IAccountRepository CustomerRepo)
        {
            this.CustomerRepo = CustomerRepo;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(CustomerRegistrationViewModel CustomerRegistrationViewModel)
        {

            Account customer = new Account()
            {
                Name = CustomerRegistrationViewModel.Name,
                Email = CustomerRegistrationViewModel.Email,
                Password = CustomerRegistrationViewModel.Password
            };

            if (ModelState.IsValid)
            {
                if(CustomerRegistrationViewModel.Password == CustomerRegistrationViewModel.PasswordCheck) { 
                    if (CustomerRepo.AddCustomer(customer))
                    {
                        //string naam = customer.Name;

                        //var fromAddress = new MailAddress("BioscoopB3@gmail.com", "BioscoopB3");
                        //var toAddress = new MailAddress(customer.Email, "To Name");
                        //const string fromPassword = "BioscoopB3B3B3";
                        //const string subject = "Aanmelding nieuwsbrief";
                        //string body = "Beste " + naam + ",<br/><br/>U heeft zich succesvol geabboneerd op onze nieuwsbrief. <br/><br/>Mvg,<br/><br/> BioscoopB3";

                        //var smtp = new SmtpClient
                        //{
                        //    Host = "smtp.gmail.com",
                        //    Port = 587,
                        //    EnableSsl = true,
                        //    DeliveryMethod = SmtpDeliveryMethod.Network,
                        //    UseDefaultCredentials = false,
                        //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        //};
                        //using (var message = new MailMessage(fromAddress, toAddress)
                        //{
                        //    Subject = subject,
                        //    Body = body
                        //})
                        //{
                        //    message.IsBodyHtml = true;
                        //    smtp.Send(message);
                        //}
                        return View("Thanks", customer);
                    }
                    else
                    {
                        return View("AlreadyRegistered", customer);
                    }
                }
                else
                {
                    ViewBag.PasswordError = "Wachtwoorden waren niet gelijk";
                    return View();
                }
            }
            else
            {
                // there is a validation error
                return View();
            }
        }
        [HttpGet]
        public ActionResult Account()
        {
            if (Session["AccountMail"] != null)
            {
                Account Account = CustomerRepo.GetCustomer(Session["AccountMail"].ToString());
                switch (Account.AccountType)
                {
                    case "BackOffice":
                        return View("AccountViews/BackOfficeAccount", Account);
                    case "Manager":
                        return View("AccountViews/ManagerAccount", Account);
                    case "NewsMailAccount":
                        return View("AccountViews/NewsMailAccount", Account);
                    case "Cashier":
                        return View("AccountViews/CashierAccount", Account);
                    case "SubscriptionHolder":
                        return View("AccountViews/SubscriptionHolderAccount", Account);
                    default:
                        return View("Account", Account);
                }
            } else
            {
                return View("LogIn");
            }
           
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return View(); 
        }

        [HttpPost]
        public ActionResult Login(LoginModel Customer)
        {
            Account CustomerDB = CustomerRepo.GetCustomer(Customer.Email);
            if (CustomerDB != null)
            {
                if (CustomerDB.Password == Customer.Password)
                {
                    Session["AccountType"] = CustomerDB.AccountType;
                    Session["AccountNaam"] = CustomerDB.Name;
                    Session["AccountMail"] = CustomerDB.Email;
                    if(CustomerDB.AccountType != "NewsMailAccount")
                    {
                        Session["LoggedIn"] = true;
                    }
                    
                    return RedirectToAction("Account");
                }                
                else
                {
                    ViewBag.WrongPassword = "U heeft een verkeerd wachtwoord ingegeven, probeer aub opnieuw";
                    return View("Login");
                }

            }
            else
            {
                ViewBag.NoAccount = "Account niet gevonden, registreer aub";
                return View("Login");
            }
        }
    }
}
