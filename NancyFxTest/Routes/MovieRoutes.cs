using Nancy;
using Nancy.ModelBinding;
using NancyFxTest.Business;
using NancyFxTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest
{
    public class MovieRoutes : NancyModule
    {
        public MovieRoutes()
        {
            Get["movie/{id}"] = GetMovieById;
            Get["movie"] = GetMoviesAll;

            Post["movie/add"] = AddMovie;

            Delete["movie"] = DeleteMoviesAll;
            Delete["movie/{id}"] = DeleteMovieById;
        }

        private dynamic DeleteMovieById(dynamic arg)
        {
            throw new NotImplementedException();
        }

        private dynamic DeleteMoviesAll(dynamic arg)
        {
            throw new NotImplementedException();
        }

        private dynamic AddMovie(dynamic arg)
        {
            var movieBusiness = new MovieBusiness(new MovieService());

            var movie = this.Bind<Movie>();
            movieBusiness.AddNewMovie(movie);

            return "Saved";

        }

        private dynamic GetMoviesAll(dynamic arg)
        {
            var movieBusiness = new MovieBusiness(new MovieService());
            var movies =  movieBusiness.GetAllMovies();
            return Response.AsJson(movies);
        }

        private dynamic GetMovieById(dynamic arg)
        {
            throw new NotImplementedException();
        }
    }
}
