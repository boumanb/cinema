using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Entities;

namespace BioscoopB3.Domain.Abstract
{
    public interface IHallMovieRepository
    {
        IEnumerable<HallMovie> GetAllHallMovies();
        HallMovie GetOneHallMovie(int HallMovieID);
        HallMovie GetAllAvailableSeats(int AvailableSeats);
    }
}
