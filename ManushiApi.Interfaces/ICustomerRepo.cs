using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManushiApi.Entities;

namespace ManushiApi.Interfaces
{
    public interface ICustomerRepo
    {
        List<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id);
        void AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
    }
}
