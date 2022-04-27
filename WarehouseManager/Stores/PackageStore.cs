using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Stores
{
    internal class PackageStore : StoreBase
    {
        private readonly ApplicationDatabaseContext _db;

        public PackageStore(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        private List<Package> _packages;
        public IEnumerable<Package> Packages { get => _packages; }

        public async override Task Load()
        {
            _packages = await _db.Packages.ToListAsync();
        }
    }
}
