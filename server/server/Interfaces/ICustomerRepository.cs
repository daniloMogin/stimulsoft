using server.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customers>> GetAllCustomers();
        Task<Customers> GetCustomerById(string id);
        Task<bool> RemoveAllCustomers();
        Task<string> CreateIndex();
        Task AddCustomer(Customers item);
    }
}
