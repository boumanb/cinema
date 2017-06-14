//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TouchUI.Models;
//using BioscoopB3Web.Domain.Abstract;
//using Moq;


//namespace TouchUI.Tests
//{
//    [TestClass]
//    public class HallMovieDescriptionControllerTests
//    {
//        [TestMethod()]
//        public void DescriptionReturnModelTest()
//        {
//            //correct

//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
//            Mock<ITicketInfoRepository> mock3 = new Mock<ITicketInfoRepository>();

//            HallMovieDescriptionController target = new HallMovieDescriptionController(mock1.Object, mock2.Object, mock3.Object);

//            mock1.Setup(m => m.GetOneHallMovie(1)).Returns(new HallMovie { HallMovieID = 1, HallID = 1, AvailableSeats = 0 });

//            var result = target.Description(1) as ViewResult;

//            HallMovieOrderViewModel model = new HallMovieOrderViewModel { HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, AvailableSeats = 0 } };

//            Assert.AreEqual(result.ViewName, "Description");
//            Assert.AreNotEqual(result.Model, model);
//        }

//        [TestMethod()]
//        public void DescriptionReturnViewTest()
//        {
//            //id equals 0
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
//            Mock<ITicketInfoRepository> mock3 = new Mock<ITicketInfoRepository>();

//            HallMovieDescriptionController target = new HallMovieDescriptionController(mock1.Object, mock2.Object, mock3.Object);

//            mock1.Setup(m => m.GetOneHallMovie(0)).Returns(new HallMovie { HallMovieID = 0 });

//            var result = target.Description(0) as ViewResult;

//            HallMovieOrderViewModel model = new HallMovieOrderViewModel { HallMovie = new HallMovie { HallMovieID = 1, HallID = 1, AvailableSeats = 0 } };

//            Assert.AreEqual(result.ViewName, "Description");
//        }


//        [TestMethod()]
//        public void PayTest()
//        {
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
//            Mock<ITicketInfoRepository> mock3 = new Mock<ITicketInfoRepository>();

//            HallMovieDescriptionController target = new HallMovieDescriptionController(mock1.Object, mock2.Object, mock3.Object);

//            OrderViewModel model = new OrderViewModel { };
//            var result = target.Pay(model) as ViewResult;
//            Assert.AreEqual(result.ViewName, "Pay");
//        }

//        [TestMethod()]
//        public void Can_Retrieve_Image_Data()
//        {
//            // Arrange - create a Product with image data
//            HallMovie hm = new HallMovie
//            {
//                HallMovieID = 1,
//                MovieID = 1,
//                Movie = new Movie
//                {
//                    MovieID = 1,
//                    Title = "TestMovie",
//                    Description = "TestDescription",
//                    Length = 120,
//                    Language = "NL",
//                    ImageData = new byte[] { },
//                    ImageMimeType = "image/png",
//                    ThreeD = true,
//                    Subtitles = true,
//                    Genre = "Roman",
//                    Age = "1"
//                }
//            };
//            // Arrange - create the mock repository
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
//            Mock<ITicketInfoRepository> mock3 = new Mock<ITicketInfoRepository>();

//            mock1.Setup(m => m.GetAllHallMovies()).Returns(new HallMovie[] { new HallMovie { MovieID = 2, HallID = 2 }, hm, new HallMovie { MovieID = 3, HallID = 2 } }.AsQueryable());
//            // Arrange - create the controller
//            HallMovieDescriptionController target = new HallMovieDescriptionController(mock1.Object, mock2.Object, mock3.Object);
//            // Act - call the GetImage action method
//            ActionResult result = target.GetImage(1);
//            // Assert
//            Assert.IsNotNull(result);
//            Assert.IsInstanceOfType(result, typeof(FileResult));
//            Assert.AreEqual(hm.Movie.ImageMimeType, ((FileResult)result).ContentType);
//        }

//        [TestMethod]
//        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
//        {
//            // Arrange - create the mock repository
//            // Arrange - create the mock repository
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();
//            Mock<ITicketInfoRepository> mock3 = new Mock<ITicketInfoRepository>();

//            mock1.Setup(m => m.GetAllHallMovies()).Returns(new HallMovie[] { new HallMovie { MovieID = 2, HallID = 2 }, new HallMovie { MovieID = 3, HallID = 2 } }.AsQueryable());

//            // Arrange - create the controller
//            HallMovieDescriptionController target = new HallMovieDescriptionController(mock1.Object, mock2.Object, mock3.Object);
//            // Act - call the GetImage action method
//            ActionResult result = target.GetImage(100);
//            // Assert
//            Assert.IsNull(result);
//        }


//    }
//}