using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample_DataAccess.Context;
using Sample_DataAccess.Entities;
using Sample_Services.Contracts;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        /// <summary>
        /// This Method Returns All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var listCustomer = _customerService.GetAllCustomers();
            HttpContext.Response.Headers.Add("_Name", "FatemehAsadi");
            HttpContext.Response.Headers.Add("_Count", _customerService.CountCustomer().ToString());
            return Ok(listCustomer);
        }

        /// <summary>
        /// This Method Gets Customer By It's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// This Method Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await CustomerExists(id))
            {
                await _customerService.UpdateCustomer(customer);
                return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
            }

            else
            {
                return BadRequest();
            }

        }

        // POST: api/Customers
        /// <summary>
        /// This Method Adds A New Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _customerService.AddCustomer(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        /// <summary>
        /// This Method Deletes Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);
            return Ok();

        }

        private async Task<bool> CustomerExists(int id)
        {
            return await _customerService.CheckCustomerExist(id);
        }
    }
}
