//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TouchUI.Tests
//{
//    [TestClass]
//    public class MovieControllerTests
//    {

//        [TestMethod()]
//        public void NoMovieListReturnTest()
//        {
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();

//            mock1.Setup(m => m.GetAllHallMovies()).Returns(new List<HallMovie> { });

//            MovieController target = new MovieController(mock2.Object, mock1.Object);

//            var result = target.MovieList() as ViewResult;

//            Assert.AreEqual(result.ViewName, "MovieList");
//        }

//        [TestMethod()]
//        public void MovieListHallTest()
//        {
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();

//            mock1.Setup(m => m.GetAllHallMovies()).Returns(new List<HallMovie> { });

//            MovieController target = new MovieController(mock2.Object, mock1.Object);

//            var result = target.MovieList() as ViewResult;

//            Assert.AreEqual(result.ViewName, "MovieList");
//        }

//        [TestMethod()]
//        public void Can_Retrieve_Image_Data()
//        {
//            // Arrange - create a Product with image data
//            Movie hm = new Movie
//            {
//                MovieID = 1,
//                Title = "TestMovie",
//                Description = "TestDescription",
//                Length = 120,
//                Language = "NL",
//                ImageData = new byte[] { },
//                ImageMimeType = "image/png",
//                ThreeD = true,
//                Subtitles = true,
//                Genre = "Roman",
//                Age = "1"
//            };
//            // Arrange - create the mock repository
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();

//            mock2.Setup(m => m.GetAllMovies()).Returns(new Movie[] { new Movie { MovieID = 2, Title = "Film2" }, hm, new Movie { MovieID = 3, Title = "Movie2" } }.AsQueryable());
//            // Arrange - create the controller
//            MovieController target = new MovieController(mock2.Object, mock1.Object);
//            // Act - call the GetImage action method
//            ActionResult result = target.GetImage(1);
//            // Assert
//            Assert.IsNotNull(result);
//            Assert.IsInstanceOfType(result, typeof(FileResult));
//            Assert.AreEqual(hm.ImageMimeType, ((FileResult)result).ContentType);
//        }

//        [TestMethod]
//        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
//        {
//            // Arrange - create the mock repository
//            // Arrange - create the mock repository
//            Mock<IHallMovieRepository> mock1 = new Mock<IHallMovieRepository>();
//            Mock<IMovieRepository> mock2 = new Mock<IMovieRepository>();

//            mock2.Setup(m => m.GetAllMovies()).Returns(new Movie[] { new Movie { MovieID = 2, Title = "Film2" }, new Movie { MovieID = 3, Title = "Movie2" } }.AsQueryable());

//            // Arrange - create the controller
//            MovieController target = new MovieController(mock2.Object, mock1.Object);
//            // Act - call the GetImage action method
//            ActionResult result = target.GetImage(100);
//            // Assert
//            Assert.IsNull(result);
//        }
//    }
//}