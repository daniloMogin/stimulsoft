using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Infrastructure;
using server.Interfaces;
using server.Model;

namespace server.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Customers>> Get()
        {
            return GetAllCustomers();
        }

        private async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public Task<Customers> Get(string id)
        {
            return GetCustomerById(id);
        }

        private async Task<Customers> GetCustomerById(string id)
        {
            return await _customerRepository.GetCustomerById(id);
        }
    }
}