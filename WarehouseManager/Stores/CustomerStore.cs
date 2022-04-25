using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Stores
{
    internal class CustomerStore : StoreBase
    {
        private readonly ApplicationDatabaseContext _db;

        public CustomerStore(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        private List<Customer> _customers;
        public IEnumerable<Customer> Customers { get => _customers; }

        public Customer SelectedCustomer { get; set; }


        public async override Task Load()
        {
            _customers = await _db.Customers.ToListAsync();
        }

        public void DeleteCustomer()
        {
            _customers.Remove(SelectedCustomer);
        }

        // add through new view 
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        // edit through new view



        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
