using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Vidly.DTOs;
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
        public IHttpActionResult GetCustomers()
        {
            return Ok(_dbContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>));
        }

        //Get /api/customers/{Id}
        [HttpGet]
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //Post /api/customers/{CustomerDTO}
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

            customerDTO.Id = customer.Id;

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDTO);
        }

        // Put /api/customers
        [HttpPut]
        public void PutUpdateCustomer(CustomerDTO CustomerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var customer = _dbContext.Customers.Single(c => c.Id == CustomerDTO.Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            CustomerDTO.Id = customer.Id;

            Mapper.Map(CustomerDTO, customer);

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
