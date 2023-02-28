using EF_Code_First_Tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First_Tutorial.Controllers
{
    public class CustomersController
    {
        private readonly SalesDbContext _context;
        public CustomersController()
        {
            _context = new SalesDbContext();
        }
        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _context.Customers
                                        //.Include(x=> x.Orders)
                                    .ToListAsync();
        }
        public async Task<Customer?> GetCustomer(int id)
        {
            return await _context.Customers
                                    .FindAsync(id);
        }

        public async Task<Customer?> GetCustomerWithOrders(int id)
        {
            return await _context.Customers
                                    .Include(x => x.Orders)
                                        .ThenInclude(x => x.OrderLines)
                                            .ThenInclude(x => x.Item)
                                    .SingleOrDefaultAsync(x => x.Id == id);
                                    
        }

        public async Task<Customer> InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            var changes = await _context.SaveChangesAsync();
            if(changes != 1)
            {
                throw new Exception("Insert failed!");
            }
            return customer;
        }
        public async Task UpdateCustomer(int id, Customer customer)
        {
            if(id != customer.Id)
            {
                throw new Exception("Customer Id Doesn't match!");
            }
            _context.Entry(customer).State = EntityState.Modified;
            var changes = await _context.SaveChangesAsync();
            if(changes != 1)
            {
                throw new Exception("Update Failed");
            }
        }
        public async Task DeleteCustomer(int id)
        {
            var cust = await GetCustomer(id);
            if(cust is null)
            {
                throw new Exception("Not Found!");
            }
            _context.Customers.Remove(cust);
            var changes = await _context.SaveChangesAsync();
            if(changes != 1)
            {
                throw new Exception("Delete Failed");
            }
        }
    }
}
