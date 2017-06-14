
using BioscoopB3.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Concrete;
using ClassLibrary1.Entities;

namespace BioscoopB3.Domain.Concrete
{
    public class EfHallMovieRepository : IHallMovieRepository
    {
        private BioscoopModel context = new BioscoopModel();

        public HallMovie GetAllAvailableSeats(int AvailableSeats)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HallMovie> GetAllHallMovies()
        {
            return context.HallMovies;
        }

        public HallMovie GetOneHallMovie(int HallMovieID)
        {
            return context.HallMovies.Find(HallMovieID);
        }
    }
}
