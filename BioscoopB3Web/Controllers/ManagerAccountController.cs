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
    public class ManagerAccountController : Controller
    {
        public ISurveyRepository ISurveyRepository;

        public ManagerAccountController(ISurveyRepository ISurveyRepository)
        {
            this.ISurveyRepository = ISurveyRepository;
        }

        // GET: ManagerAccount
        public ActionResult Survey()
        {
            return PartialView("_Survey");
        }

        public ActionResult AddSurvey(Survey Survey)
        {
            ISurveyRepository.AddSurvey(Survey);
            ViewBag.Success = "Bedankt voor het invullen van de enquête!";
            return View("~/Views/Payment/Success.cshtml");
        }

        public ActionResult SurveyResults()
        {
            if (Session["AccountType"] != null && Session["LoggedIn"] != null)
            {
                if (Session["AccountType"].ToString() == "Manager")
                {
                    SurveyResultsViewModel Model = new SurveyResultsViewModel();
                    Model.Surveys = ISurveyRepository.GetAllSurveys();
                    return View("~/Views/Account/AccountViews/ManagerAccountOptions/SurveyResults.cshtml", Model);
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

        public void RemoveOpenQ(int SurveyID)
        {
            ISurveyRepository.SetOpenQDeletedTrue(SurveyID);
        }
    }
}