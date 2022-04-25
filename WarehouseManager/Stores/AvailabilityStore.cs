using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Stores
{
    internal class AvailabilityStore : StoreBase
    {
        private readonly ApplicationDatabaseContext _db;

        public AvailabilityStore(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        private List<Availability> _availabilities;
        public IEnumerable<Availability> Availabilities { get => _availabilities; }


        public async override Task Load()
        {
            _availabilities = await _db.Availabilities.ToListAsync();
        }
    }
}
