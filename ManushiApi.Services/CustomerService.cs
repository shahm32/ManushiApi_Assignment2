using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManushiApi.Entities;
using ManushiApi.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ManushiApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly ILogger<CustomerService> _logger;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo customerRepo, ILogger<CustomerService> logger, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public List<CustomerDto> GetAllCustomers()
        {
            try
            {
                var customers = _customerRepo.GetAllCustomers();
                return _mapper.Map<List<CustomerDto>>(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all customers.");
                throw; // Rethrow the exception for handling in the controller
            }
        }

        public CustomerDto? GetCustomerById(int id)
        {
            try
            {
                var customer = _customerRepo.GetCustomerById(id);
                return customer != null ? _mapper.Map<CustomerDto>(customer) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting customer with ID {id}.", id);
                throw; 
            }
        }

        public void AddCustomer(CustomerDto customerDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                _customerRepo.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new customer.");
                throw; 
            }
        }

        public bool UpdateCustomer(CustomerDto customerDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                return _customerRepo.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating customer with ID {id}.", customerDto.Id);
                throw;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                return _customerRepo.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting customer with ID {id}.", id);
                throw;
            }
        }
    }
}
