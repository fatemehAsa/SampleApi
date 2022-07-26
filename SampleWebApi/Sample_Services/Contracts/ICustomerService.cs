using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample_DataAccess.Entities;

namespace Sample_Services.Contracts
{
    public interface ICustomerService
    {

        List<Customer> GetAllCustomers();
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int customerId);
        Task<bool> CheckCustomerExist(int customerId);
        int CountCustomer();

    }
}
