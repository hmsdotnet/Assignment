using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Entities;

namespace Assignment.Application.Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);

       }
}
