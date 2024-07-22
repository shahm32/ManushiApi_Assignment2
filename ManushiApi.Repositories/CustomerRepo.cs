using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManushiApi.Entities;
using ManushiApi.Interfaces;
using Microsoft.Extensions.Logging;

namespace ManushiApi.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CustomerRepo> _logger; // For logging

        public CustomerRepo(ApplicationDbContext dbContext, ILogger<CustomerRepo> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _dbContext.Customers.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all customers.");
                throw; // Rethrow the exception to be handled elsewhere (e.g., middleware)
            }
        }

        public Customer? GetCustomerById(int id)
        {
            try
            {
                return _dbContext.Customers.Find(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting customer with ID {id}.", id);
                throw; 
            }
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new customer.");
                throw; 
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = _dbContext.Customers.Find(customer.Id);
                if (existingCustomer == null) return false;

                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating customer with ID {id}.", customer.Id);
                throw; 
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = _dbContext.Customers.Find(id);
                if (customerToDelete == null) return false;

                _dbContext.Customers.Remove(customerToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting customer with ID {id}.", id);
                throw; 
            }
        }
    }

}
