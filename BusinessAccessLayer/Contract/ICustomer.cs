using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Contract
{
     public interface ICustomer
    {
        List<Customer> GetCustomers();
        object CreateCustomer(Customer obj);
        bool DeleteCustomer(int id);
        Customer GetCustomerById(int id);
    }
}
