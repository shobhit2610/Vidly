using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var Customers = _context.Customers.Include(c => c.MembershipType).ToList();
           
            return View(Customers);
        }

     

        public ActionResult Details(int id)
        {
            var Customer=_context.Customers.SingleOrDefault(c => c.Id == id);

            return View(Customer);
        }
    }
}