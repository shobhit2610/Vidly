using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
     
        public ViewResult Index()
        {
            var Customers = GetCustomers();
           
            return View(Customers);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }

        public ActionResult Details(int id)
        {
            var Customer=GetCustomers().SingleOrDefault(c => c.Id == id);

            return View(Customer);
        }
    }
}