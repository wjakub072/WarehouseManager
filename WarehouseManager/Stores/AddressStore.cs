using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManager.Data;
using WarehouseManager.Models;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Stores
{
    internal class AddressStore : StoreBase
    {
        private readonly ApplicationDatabaseContext _db;

        public AddressStore(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        private List<Address> _addresses = new List<Address>(); // temporary
        public IEnumerable<Address> Addresses { get => _addresses; }

        public Address SelectedAddress { get; set; }


        public async override Task Load()
        {
            _addresses = await _db.Addresses.ToListAsync();
        }

        public void DeleteAddress()
        {
            _addresses.Remove(SelectedAddress);
        }

        // add through new view 
        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public async Task SaveRangeToDatabase(int customerId)
        {
            var unsaved = Addresses.Where(a => a.Address_Id == 0 && a.CustomerId == 0).ToList();

            foreach (var address in unsaved)
            {
                address.CustomerId = customerId;
            }

            _db.Addresses.AddRange(unsaved);

            await _db.SaveChangesAsync();
        }
    }
}
