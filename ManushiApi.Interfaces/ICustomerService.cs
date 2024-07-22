using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManushiApi.Entities;

namespace ManushiApi.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAllCustomers();
        CustomerDto? GetCustomerById(int id);
        void AddCustomer(CustomerDto customerDto);
        bool UpdateCustomer(CustomerDto customerDto);
        bool DeleteCustomer(int id); 
    }
}
