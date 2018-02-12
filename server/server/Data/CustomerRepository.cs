using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using server.Interfaces;
using server.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context = null;

        public CustomerRepository(IOptions<Settings> settings)
        {
            _context = new CustomerContext(settings);
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            try
            {
                return await _context.Customers.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customers> GetCustomerById(string id)
        {
            var filter = Builders<Customers>.Filter.Eq("CustomerId", id);
            try
            {
                return await _context.Customers.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveAllCustomers()
        {
            try
            {
                DeleteResult actionResult = await _context.Customers.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateIndex()
        {
            try
            {
                return await _context.Customers.Indexes
                                               .CreateOneAsync(Builders<Customers>
                                                                   .IndexKeys
                                                                   .Ascending(item => item.CustomerId)
                                                                   .Ascending(item => item.ContactName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddCustomer(Customers item)
        {
            try
            {
                await _context.Customers.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
