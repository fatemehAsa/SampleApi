using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample_Client.Models;

namespace Sample_Client.Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetCustomerById(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
    }
}
