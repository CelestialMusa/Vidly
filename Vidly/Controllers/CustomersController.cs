using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            var Customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();

            return View(Customers);
        }

        public ActionResult Details()
        {
            return View(new Customer());

        }

        [Route("Customers/CustomerDetails/{Id:regex(\\d)}")]
        public ActionResult CustomerDetails(int Id)
        {
            var Customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (Customer == null)
                return HttpNotFound();

            return View(Customer);
        }
    }
}