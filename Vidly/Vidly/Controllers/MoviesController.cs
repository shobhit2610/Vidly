using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            var Movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(Movies);
        }

        public ActionResult Details(int Id)
        {
            var Movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == Id);

            return View(Movies);
        }

        public ActionResult New()
        {
            var genre = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genre = genre
            };

            return View("Save",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            movie.ID = 0;
            
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()
                };

                return View("Save", viewModel);
            }
            
            if(movie.ID==0)
            {
                
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.ID == movie.ID);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.NumberInStock = movie.NumberInStock;
                MovieInDb.DateAdded = movie.DateAdded;
                MovieInDb.GenreId = movie.GenreId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        
        }

        public ActionResult Edit(int ID)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == ID);

            if(movie == null)
            {
                HttpNotFound();
            }

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };
            return View("Save",viewModel);
        }
    }
}