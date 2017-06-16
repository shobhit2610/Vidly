using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {
            var Movies = GetMovies();
            return View(Movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List <Movie>
            {
                new Movie{ID=1, Name="Shrek!"},
                new Movie{ID=1, Name="Wall E"}
            };

        }
   

    }
}