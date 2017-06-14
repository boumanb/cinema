using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;
using BioscoopB3Web.Domain.Abstract;

namespace BioscoopB3Web.Domain.Concrete
{
    public class EfMovieRepository : IMovieRepository
    {
        private BioscoopModel BioscoopModel;

        public EfMovieRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }

        public Movie AddMovie(Movie Movie)
        {
            BioscoopModel.Movies.Add(Movie);
            BioscoopModel.SaveChanges();
            Movie MovieAdded = BioscoopModel.Movies.Find(Movie.MovieID);
            return MovieAdded;
        }

        public bool CheckIfMovieExist(string MovieTitle)
        {
            if(BioscoopModel.Movies.Select(m => m.Title == MovieTitle) == null)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return BioscoopModel.Movies;
        }

        public Movie GetOneMovie(int MovieID)
        {
            return BioscoopModel.Movies.Find(MovieID);
        }

        public Movie GetOneMovieByName(string MovieName)
        {
            return BioscoopModel.Movies.First(m => m.Title == MovieName);
        }
    }
}
