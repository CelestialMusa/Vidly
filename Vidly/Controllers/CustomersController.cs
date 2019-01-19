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
            return View();
        }

        public ViewResult New()
        {
            List<MembershipType> membershipTypes = null;

            membershipTypes = _dbContext.MembershipTypes.ToList();
            
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _dbContext.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var editedCustomer = _dbContext.Customers.Single(c => c.Id == customer.Id);

                editedCustomer.Name = customer.Name;
                editedCustomer.BirthDate = customer.BirthDate;
                editedCustomer.MembershipTypeId = customer.MembershipTypeId;
                editedCustomer.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        
        public ActionResult Edit(int Id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
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