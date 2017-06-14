using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouchUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            Movie movie = new Movie { Length = 122, ThreeD = true, Language = "Nederlands" };
            DateTime datetime = new DateTime(2017, 02, 22, 15, 2, 1);
            HallMovie hallmovie = new HallMovie { DateTime = datetime };
            //Order order = new Order(3, 5, 1, 0, movie, hallmovie);
            //decimal total = order.calcTotalPrice();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
