using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        //Get /api/customers/{Id}
        [HttpGet]
        public Customer GetCustomer(int Id)
        {
            return _dbContext.Customers.SingleOrDefault(c => c.Id == Id) ?? throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //Post /api/customers/{customer}
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer;
        }

        // Put /api/customers
        [HttpPut]
        public void PutUpdateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var db_customer = _dbContext.Customers.Single(c => c.Id == customer.Id);

            if (db_customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db_customer.Name = customer.Name;
            db_customer.MembershipType = customer.MembershipType;
            db_customer.MembershipTypeId = customer.MembershipTypeId;
            db_customer.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            db_customer.BirthDate = customer.BirthDate;

            _dbContext.SaveChanges();
        }

        //Delete /api/customers/{Id}
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = _dbContext.Customers.Single(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}
