using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var Movie = new Movie() { Name = "Shrek!" };

            var Customer = new List<Customer>
            { 
                new Customer {Name ="Customer1"},
                new Customer {Name ="Customer2"},
            };

            var ViewModel = new RandomMovieViewModel
            {
                Movie = Movie,
                Customers = Customer
            };

            return View(ViewModel);
        }
    }
}