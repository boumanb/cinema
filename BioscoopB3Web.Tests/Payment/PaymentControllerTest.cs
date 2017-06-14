using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BioscoopB3Web.Controllers;
using BioscoopB3Web.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BioscoopB3Web.Domain.Concrete;
using BioscoopB3Web.Domain.Abstract;
using Moq;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Tests.Payment
{
    [TestClass]
    public class PaymentControllerTest
    {
        [TestMethod]
        public void GetIDealPaymentTest()
        {
            Mock<ITicketRepository> TicketRepo = new Mock<ITicketRepository>();
            Mock<IOrderRepository> OrderRepo = new Mock<IOrderRepository>();
            var test = new PaymentController(TicketRepo.Object, OrderRepo.Object);
            test.TempData["hallMovieViewModel"] = new HallMovieViewModel() { order = new Order() };
            var result = test.IDealPayment().ViewName;
            Assert.AreEqual(result, "IDealPayment");
        }

        [TestMethod]
        public void PostIDealPaymentTest()
        {
            Mock<ITicketRepository> TicketRepo = new Mock<ITicketRepository>();
            Mock<IOrderRepository> OrderRepo = new Mock<IOrderRepository>();
            var test = new PaymentController(TicketRepo.Object, OrderRepo.Object);
            test.TempData["hallMovieViewModel"] = new HallMovieViewModel() { order = new Order() };
            IDealPaymentViewModel model = new IDealPaymentViewModel()
            {
                IBAN = "NL20RABO0142505234",
                Card = "1234"
            };
            var result = test.IDealPayment(model).ViewName;
            Assert.AreEqual(result, "Success");
        }

        [TestMethod]
        public void PostIDealPaymentTest2()
        {
            Mock<ITicketRepository> TicketRepo = new Mock<ITicketRepository>();
            Mock<IOrderRepository> OrderRepo = new Mock<IOrderRepository>();
            var test = new PaymentController(TicketRepo.Object, OrderRepo.Object);
            test.TempData["hallMovieViewModel"] = new HallMovieViewModel() { order = new Order() };
            IDealPaymentViewModel model = new IDealPaymentViewModel()
            {
                IBAN = "",
                Card = "1234"
            };
            test.ModelState.AddModelError("IBAN", "Required");
            var result = test.IDealPayment(model).ViewName;
            Assert.AreEqual(result, "IDealPayment");
        }

        [TestMethod]
        public void GetCardPaymentTest()
        {
            Mock<ITicketRepository> TicketRepo = new Mock<ITicketRepository>();
            Mock<IOrderRepository> OrderRepo = new Mock<IOrderRepository>();
            var test = new PaymentController(TicketRepo.Object, OrderRepo.Object);
            var result = test.CardPayment().ViewName;
            Assert.AreEqual(result, "CardPayment");
        }

        [TestMethod]
        public void PostCardPaymentTest()
        {   
            Mock<ITicketRepository> TicketRepo = new Mock<ITicketRepository>();
            Mock<IOrderRepository> OrderRepo = new Mock<IOrderRepository>();
            HallMovieViewModel hallMovieViewModel = new HallMovieViewModel() { order = new Order()};            

            var test = new PaymentController(TicketRepo.Object, OrderRepo.Object);
            test.TempData["hallMovieViewModel"] = new HallMovieViewModel() { order = new Order()};
            CardPaymentViewModel model = new CardPaymentViewModel()
            {
                CardNumber = "1928374657483920",
                ExpiryMonth = 3,
                ExpiryYear = 3000,
                SecurityNumber = "123"
            };
            model.checkExpired(model.ExpiryMonth, model.ExpiryYear);
            var result = test.CardPayment(model).ViewName;
            Assert.AreEqual(result, "Success");
        }

        [TestMethod]
        public void PostCardPaymentTest2()
        {
            Mock<ITicketRepository> TicketRepo = new Mock<ITicketRepository>();
            Mock<IOrderRepository> OrderRepo = new Mock<IOrderRepository>();
            var test = new PaymentController(TicketRepo.Object, OrderRepo.Object);
            test.TempData["hallMovieViewModel"] = new HallMovieViewModel() { order = new Order() };
            CardPaymentViewModel model = new CardPaymentViewModel()
            {
                CardNumber = "1928374657483920",
                ExpiryMonth = 3,
                ExpiryYear = 2000,
                SecurityNumber = "123"
            };
            model.checkExpired(model.ExpiryMonth, model.ExpiryYear);
            var result = test.CardPayment(model).ViewName;
            Assert.AreEqual(result, "CardPayment");
        }

    }
}
