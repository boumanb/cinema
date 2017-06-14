using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouchUI.Controllers
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

        public ViewResult MovieList()
        {
            ViewBag.MovieList = "MovieList";

            return View("MovieList", HallMovieRepo.GetAllHallMovies().Where(d => d.DateTime > DateTime.Now).OrderBy(d => d.DateTime).ToList());
        }

        public ActionResult MovieListHall(int id)
        {
            ViewBag.MovieList = "MovieList: Zaal " + id;
            return View("MovieList", HallMovieRepo.GetAllHallMovies().Where(hm => hm.HallID == id && hm.DateTime > DateTime.Now).OrderBy(d => d.DateTime).ToList());
        }

        public ActionResult HallList()
        {
            IEnumerable<HallMovie> hallmovies = HallMovieRepo.GetAllHallMovies();
            IEnumerable<int> halls = hallmovies.Select(h => h.HallID).Distinct();
            IEnumerable<int> HallIdsSorted = halls.OrderBy(s => s);
            return View("Halls", HallIdsSorted);
        }
    }
}