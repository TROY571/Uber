﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Uber2.Models;

namespace Uber2.Data
{
    public interface ICustomersService
    {
        Task<IList<Customer>> GetCustomersAsync();
        Task<Customer>   RegisterCustomerAsync(Customer customer);
        Task   RemoveCustomerAsync(int customerId);
        Task<Customer>   EditCustomerInfoAsync(Customer customer);

        Task<Customer> Login(string username, string password);

        Task Logout(string username);

        Task<Customer> SearchCustomer(string username);
        
    }
}