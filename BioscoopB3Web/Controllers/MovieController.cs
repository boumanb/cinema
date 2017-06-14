using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using BioscoopB3Web.Domain.Concrete;
using BioscoopB3Web.Models;

namespace BioscoopB3Web.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository MovieRepo;
        IHallMovieRepository HallMovieRepo;

        public MovieController(IMovieRepository MovieRepo, IHallMovieRepository HallMovieRepo)
        {
            this.MovieRepo = MovieRepo;
            this.HallMovieRepo = HallMovieRepo;
        }

        public ViewResult List()
        {
            DateTime Today = DateTime.Today;
            int daysUntilWednesday = ((int)DayOfWeek.Wednesday - (int)Today.DayOfWeek + 7) % 7;
            DateTime NextWednesday = Today.AddDays(daysUntilWednesday).AddHours(23).AddMinutes(59).AddSeconds(59);
            ViewBag.MovieList = "Films deze filmweek";
            return View("~/Views/MovieList/MovieList.cshtml", HallMovieRepo.GetAllHallMovies().Where(d => d.DateTime > DateTime.Now && d.DateTime < NextWednesday).OrderBy(d => d.DateTime).ToList());
        }

        public ActionResult HallList()
        {
            IEnumerable<HallMovie> hallmovies = HallMovieRepo.GetAllHallMovies();
            IEnumerable<int> halls = hallmovies.Select(h => h.HallID).Distinct();
            return View("Halls", halls);
        }

        public ViewResult Description(int MovieID = 0)
        {
            if (MovieID.Equals(0)) /*|| MovieID > iMovieRepository.GetAllMovies().Count()*/
            {
                return View("Description");
            }
            else
            {
                MovieViewModel model = new MovieViewModel()
                {
                    Movie = MovieRepo.GetOneMovie(MovieID)

                };
                return View(model);
            }
        }
        [HttpPost]
        public ViewResult Description(MovieViewModel MovieViewModel)
        {

            return View("Overview");

        }
    }
}