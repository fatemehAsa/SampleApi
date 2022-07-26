using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample_DataAccess.Context;
using Sample_DataAccess.Entities;

namespace Sample_Services.Contracts.Services
{
    public class CustomerService : ICustomerService
    {
        private SampleDbContext _context;

        public CustomerService(SampleDbContext context)
        {
            _context = context;
        }


        public List<Customer> GetAllCustomers()
        {
            return  _context.Customers.ToList();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            return customer;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var customer = await _context.Customers.SingleAsync(c => c.CustomerId == customerId);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> CheckCustomerExist(int customerId)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == customerId);
        }

        public int CountCustomer()
        {
            return  _context.Customers.Count();
        }
    }
}
