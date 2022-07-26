using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample_Client.Models;

namespace Sample_Client.Contracts.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private IHttpClientFactory _httpClientFactory;
        private HttpClient _client;
        public CustomerRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient("WebClient");
        }

        public IEnumerable<Customer> GetAll()
        {
            var jsonData = _client.GetStringAsync("/Api/Customers").Result;
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonData);
            return list;
        }

        public Customer GetCustomerById(int customerId)
        {
            var jsonData = _client.GetStringAsync("/Api/Customers" + "/" + customerId).Result;
            var customer = JsonConvert.DeserializeObject<Customer>(jsonData);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            var jsonData = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("/Api/Customers", content).Result;
        }

        public void UpdateCustomer(Customer customer)
        {
            var jsonData = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = _client.PutAsync("/Api/Customers" + "/" + customer.CustomerId, content).Result;
        }

        public void DeleteCustomer(int customerId)
        {
            var res = _client.DeleteAsync("/Api/Customers" + "/" + customerId);
        }


    }
}
