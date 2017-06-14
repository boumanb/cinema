using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Controllers;
using BioscoopB3Web.Domain.Entities;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;

namespace BioscoopB3Web.Tests.Controllers
{
    [TestClass]
    public class ManagerAccountControllerTests
    {
        [TestMethod]
        public void SuccesFullAddSurvey()
        {
            Mock<ISurveyRepository> mock1 = new Mock<ISurveyRepository>();

            ManagerAccountController target = new ManagerAccountController(mock1.Object);

            Survey survey = new Survey()
            {
                ScoreQ = 1,
                MultipleChoiceQ = "Het is goed zo!",
                SurveyID = 1,
                OpenQ = "Test",
                OpenQIsDeleted = false
            };

            var result = target.AddSurvey(survey) as ViewResult;

            result.ViewBag.Success.Equals("Bedankt voor het invullen van de enquête!");
        }

        [TestMethod]
        public void UnSuccesFullAddSurvey()
        {
            Mock<ISurveyRepository> mock1 = new Mock<ISurveyRepository>();

            ManagerAccountController target = new ManagerAccountController(mock1.Object);

            Survey survey = new Survey()
            {
                ScoreQ = 1,
                MultipleChoiceQ = "Het is goed zo!",
                SurveyID = 1,
                OpenQIsDeleted = false
            };

            var result = target.AddSurvey(survey) as ViewResult;

            result.ViewBag.Success.Equals(null);
        }

        [TestMethod]
        public void ViewSurveyResultsWorking()
        {

            var session = new Mock<HttpSessionStateBase>();
            
            Mock<ISurveyRepository> mock1 = new Mock<ISurveyRepository>();

            mock1.Setup(m => m.GetAllSurveys()).Returns(new List<Survey> {
                new Survey { ScoreQ = 1,
                MultipleChoiceQ = "Het is goed zo!",
                SurveyID = 1,
                OpenQ = "Test",
                OpenQIsDeleted = false },
                new Survey { ScoreQ = 2,
                MultipleChoiceQ = "Het kan beter",
                SurveyID = 2,
                OpenQ = "Test",
                OpenQIsDeleted = false },
            });

            ManagerAccountController target = new ManagerAccountController(mock1.Object);

            var result = target.SurveyResults() as ViewResult;

            result.Model.Equals(new List<Survey> {
                new Survey { ScoreQ = 1,
                MultipleChoiceQ = "Het is goed zo!",
                SurveyID = 1,
                OpenQ = "Test",
                OpenQIsDeleted = false },
                new Survey { ScoreQ = 2,
                MultipleChoiceQ = "Het kan beter",
                SurveyID = 2,
                OpenQ = "Test",
                OpenQIsDeleted = false },
            });
        }
    }
}
