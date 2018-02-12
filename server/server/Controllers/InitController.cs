using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Model;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class InitController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public InitController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{settings}")]
        public string Get(string settings)
        {
            if (settings == "init")
            {
                _customerRepository.RemoveAllCustomers();
                var name = _customerRepository.CreateIndex();

                _customerRepository.AddCustomer(new Customers() { CustomerId = 1, ContactName = "Test customer 1", Address = "Test address 1", City = "Test City 1", Country = "Test country 1", PostalCode = 21000, CompanyName = "Test company name 1", ContactTitle = "Test title 1", Phone = "0038162222555", Fax = "0038154555544", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
                _customerRepository.AddCustomer(new Customers() { CustomerId = 2, ContactName = "Test customer 2", Address = "Test address 2", City = "Test City 2", Country = "Test country 2", PostalCode = 21000, CompanyName = "Test company name 2", ContactTitle = "Test title 2", Phone = "0038162222555", Fax = "0038154555544", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
                _customerRepository.AddCustomer(new Customers() { CustomerId = 3, ContactName = "Test customer 3", Address = "Test address 3", City = "Test City 3", Country = "Test country 3", PostalCode = 21000, CompanyName = "Test company name 3", ContactTitle = "Test title 3", Phone = "0038162222555", Fax = "0038154555544", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
                _customerRepository.AddCustomer(new Customers() { CustomerId = 4, ContactName = "Test customer 4", Address = "Test address 4", City = "Test City 4", Country = "Test country 4", PostalCode = 21000, CompanyName = "Test company name 4", ContactTitle = "Test title 4", Phone = "0038162222555", Fax = "0038154555544", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });


                return "Database CustomersDb was created, and collection 'Customers' was filled with 4 sample items";
            }
            return "Unknown";
        }
    }
}