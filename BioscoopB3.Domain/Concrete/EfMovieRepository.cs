using BioscoopB3.Domain.Abstract;
using ClassLibrary1.Concrete;
using ClassLibrary1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3.Domain.Concrete
{
    public class EfMovieRepository : IMovieRepository
    {
        private BioscoopModel context = new BioscoopModel();

        public IEnumerable<Movie> GetAllMovies()
        {
            return context.Movies;
        }

        public Movie GetOneMovie(int MovieID)
        {
            return context.Movies.Find(MovieID);
        }
    }
}
