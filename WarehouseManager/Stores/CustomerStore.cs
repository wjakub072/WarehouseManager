using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        private List<Customer> _customers = new List<Customer>(); // temporary then use load init command
        public IEnumerable<Customer> Customers { get => _customers; }

        public Customer SelectedCustomer { get; set; }


        public async override Task Load()
        {
            _customers = await _db.Customers.Where(c => c.Status > 0).ToListAsync();
        }

        public async Task DeleteCustomer()
        {
            //instead of deleting change status to 0
            SelectedCustomer.Status = 0;
            _db.Update(SelectedCustomer);

            await _db.SaveChangesAsync();

            _customers.Remove(SelectedCustomer);
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
