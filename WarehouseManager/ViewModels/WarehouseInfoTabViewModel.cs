using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.ViewModels
{
    internal class WarehouseInfoTabViewModel : ViewModelBase
    {
        private string _warehouse;

        public string Warehouse
        {
            get { return _warehouse; }
            set { _warehouse = value; }
        }

        private string _operator;

        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        private ObservableCollection<Sector> _sectors;

        public ObservableCollection<Sector> Sectors
        {
            get { return _sectors; }
            set { _sectors = value; }
        }


        private readonly ApplicationDatabaseContext _db;

        public WarehouseInfoTabViewModel(ApplicationDatabaseContext db)
        {
            _db = db;

            _sectors = new ObservableCollection<Sector>((System.Collections.Generic.IEnumerable<Sector>)_db.Sectors.ToListAsync());
        }
    }
}
