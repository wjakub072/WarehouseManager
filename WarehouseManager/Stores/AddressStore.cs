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

        // edit through new view



        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
