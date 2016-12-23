using NancyFxTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest.Business
{
    public class MovieBusiness
    {
        private IMovieService _movieService;

        public MovieBusiness(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void AddNewMovie(Movie newMovie)
        {
            _movieService.Add(newMovie);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieService.GetAll();
        }
    }
}
