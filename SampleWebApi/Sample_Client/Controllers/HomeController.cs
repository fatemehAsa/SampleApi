using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample_Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Sample_Client.Contracts;

namespace Sample_Client.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository _customerRepository;

        public HomeController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public IActionResult Index()
        {
            var listCustomer = _customerRepository.GetAll();
            return View(listCustomer);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _customerRepository.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer==null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _customerRepository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

    }
}
