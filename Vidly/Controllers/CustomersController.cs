using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var Customers = new List<Customer>()
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };

            var CustomerDetails = new CustomerDetails
            {
                Customers = Customers
            };

            return View(CustomerDetails);
        }

        public ActionResult Details()
        {
            return View(new Customer());

        }

        [Route("Customers/CustomerDetails/{Id:regex(\\d)}/{name}")]
        public ActionResult CustomerDetails(int Id, string name)
        {
            var Customer = new Customer
            {
                Id = Id,
                Name = name
            };

            return View(Customer);
        }
    }
}