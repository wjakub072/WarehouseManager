using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Stores
{
    internal class SectorStore : StoreBase
    {
        private readonly ApplicationDatabaseContext _db;

        public SectorStore(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        private List<Sector> _sectors;
        public IEnumerable<Sector> Sectors { get => _sectors; }

        public string Warehouse { get; set; }
        public string Operator { get; set; } = "TESTOWY";

        public async override Task Load()
        {
            _sectors = await _db.Sectors.ToListAsync();
            Warehouse = await _db.Warehouses.Select(w => w.Name).FirstAsync();
        }
    }
}
