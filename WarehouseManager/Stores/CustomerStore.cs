using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private List<Customer> _customers = new List<Customer>();
        public IEnumerable<Customer> Customers { get => _customers; }

        public Customer SelectedCustomer { get; set; }


        public async override Task Load()
        {
            _customers = await _db.Customers.ToListAsync();
        }

        public async Task DeleteCustomer()
        {
            SelectedCustomer.Status = 0;
            _db.Update(SelectedCustomer);
            await _db.SaveChangesAsync();
        }

        // add through new view 
        public async Task AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();

            _customers.Add(customer);
        }

        // edit through new view
        public bool EditingMode { get; set; }
    }
}
