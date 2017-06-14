using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Controllers
{
    public class SubscriptionHolderAccountController : Controller
    {
        private IAccountRepository IAccountRepository;

        public SubscriptionHolderAccountController(IAccountRepository IAccountRepository)
        {
            this.IAccountRepository = IAccountRepository;
        }
        // GET: SubscriptionHolderAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditInformation()
        {
            if (Session["AccountType"] != null && Session["LoggedIn"] != null)
            {
                if (Session["AccountType"].ToString() == "SubscriptionHolder")
                {
                    Account Account = IAccountRepository.GetCustomer(Session["AccountMail"].ToString());
                    return View("~/Views/Account/AccountViews/SubscriptionHolderAccountOptions/EditInformation.cshtml", Account);
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
        public ActionResult EditInformation(Account account)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Success = "Account succesvol aangepast";
                IAccountRepository.AddCustomer(account);
                return View("~/Views/Account/AccountViews/SubscriptionHolderAccountOptions/EditInformation.cshtml", account);
            } else
            {
                ViewBag.NoSuccess = "Er is iets fout gegaan";
                return View("~/Views/Account/AccountViews/SubscriptionHolderAccountOptions/EditInformation.cshtml");
            }
        }
    }
}