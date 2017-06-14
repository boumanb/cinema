using BioscoopB3Web.Domain.Entities;
using BioscoopB3Web.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using BioscoopB3Web.Models;

namespace BioscoopB3Web.Controllers
{
    public class NewsmailController : Controller
    {
        IAccountRepository CustomerRepo;

        public NewsmailController(IAccountRepository CustomerRepo)
        {
            this.CustomerRepo = CustomerRepo;
        }

        [HttpGet]
        // GET: Newsmail
        public ViewResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Subscribe(NewsMailViewModel NewsMailViewModel)
        {
            Account customer = new Account()
            {
                Name = NewsMailViewModel.Name,
                Email = NewsMailViewModel.Email,
                WantsNewsletter = NewsMailViewModel.WantsNewsletter,
                LastName = NewsMailViewModel.LastName,
                Gender = NewsMailViewModel.Gender,
                AccountType = "NewsMailAccount"
            };
            if (ModelState.IsValid)
            {
                if (CustomerRepo.AddCustomer(customer))
                {
                    string naam = customer.Name;

                    var fromAddress = new MailAddress("BioscoopB3@gmail.com", "BioscoopB3");
                    var toAddress = new MailAddress(customer.Email, "To Name");
                    const string fromPassword = "BioscoopB3B3B3";
                    const string subject = "Aanmelding nieuwsbrief";
                    string body = "Beste "+ naam + ",<br/><br/>U heeft zich succesvol geabboneerd op onze nieuwsbrief. <br/><br/>Mvg,<br/><br/> BioscoopB3";

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
                        Body = body
                    })
                    {
                        message.IsBodyHtml = true;
                        smtp.Send(message);
                    }
                    return View("Thanks", customer);
                }
                else
                {
                    return View("AlreadyRegistered", customer);
                }
            }
            else
            {
                // there is a validation error
                return View();
            }
        }
    }
}