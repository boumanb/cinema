//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TouchUI.Tests
//{
//    [TestClass]
//    public class PaymentControllerTests
//    {

//        [TestMethod()]
//        public void PayTest()
//        {
//            Mock<ITicketInfoRepository> mock1 = new Mock<ITicketInfoRepository>();
//            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();

//            mock1.Setup(m => m.FindOneTicket(1)).Returns(new TicketInfo
//            {
//                TicketInfoID = 1,
//                MovieTitle = "Test",
//                TotalPrice = 22
//            });

//            PaymentController target = new PaymentController(mock1.Object, mock2.Object);

//            var result = target.Pay(1) as ViewResult;

//            var model = result.Model;



//            Assert.IsNotNull(model);
//        }

//        [TestMethod()]
//        public void pay2ResturnsFailedTest()
//        {
//            Mock<ITicketInfoRepository> mock1 = new Mock<ITicketInfoRepository>();
//            Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();

//            mock1.Setup(m => m.FindOneTicket(1)).Returns(new TicketInfo
//            {
//                TicketInfoID = 1,
//                MovieTitle = "Test",
//                TotalPrice = 22
//            });

//            PaymentController target = new PaymentController(mock1.Object, mock2.Object);

//            var result = target.Betaling(new TicketInfo
//            {
//                TicketInfoID = 1,
//                Saldo = 20
//            }) as ViewResult;

//            Assert.AreEqual(result.ViewName, "Failed");
//        }


//        //[TestMethod()]
//        //public void pay2ResturnSuccesTest()
//        //{
//        //    Mock<ITicketInfoRepository> mock1 = new Mock<ITicketInfoRepository>();
//        //    Mock<IHallMovieRepository> mock2 = new Mock<IHallMovieRepository>();



//        //    mock1.Setup(m => m.FindOneTicket(1)).Returns(new TicketInfo
//        //    {
//        //        TicketInfoID = 1,
//        //        MovieTitle = "Test",
//        //        TotalPrice = 22,
//        //        FirstSeat = 5,
//        //        ticketAmount = 5,
//        //        HallMovieID = 1

//        //    });

//        //    mock2.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, AvailableSeats = 0, Hall = new Hall { HallID = 1, Capacity = 100 } });

//        //    PaymentController target = new PaymentController(mock1.Object, mock2.Object);

//        //    var result = target.Betaling(new TicketInfo
//        //    {
//        //        TicketInfoID = 1,
//        //        Saldo = 30
//        //    }) as ViewResult;

//        //    Assert.AreEqual(result.ViewName, "");
//        //}
//    }
//}