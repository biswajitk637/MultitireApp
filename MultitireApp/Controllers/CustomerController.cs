using BusinessAccessLayer.Contract;
using BusinessAccessLayer.Service;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitireApp.Controllers
{
    public class CustomerController : Controller
    {
       private ICustomer customerService;

        public CustomerController(ICustomer customer)
        {
            customerService = customer;
        }
        
        public IActionResult Index()
        {
            var customers = customerService.GetCustomers();
            return View(customers);
        }
        public ActionResult Create()
        {
            return View();
             
        }
        [HttpPost]
        public IActionResult Create( Customer obj)
        {
            if(ModelState.IsValid)
            {
                var result = customerService.CreateCustomer(obj);
                if(result !=null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Error in Customer Create !");
                    return View(obj);
                }
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var result = customerService.DeleteCustomer(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message="Error in Delete !";
                return RedirectToAction("Index");
            }
        }
    }

    
}
