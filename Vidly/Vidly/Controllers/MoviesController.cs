using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;


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

    }
}