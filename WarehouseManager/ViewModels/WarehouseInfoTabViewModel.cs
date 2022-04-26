using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Data;
using WarehouseManager.Models;
using WarehouseManager.Stores;

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

        public IEnumerable<Sector> Sectors => _store.Sectors;


        private readonly ApplicationDatabaseContext _db;
        private readonly SectorStore _store;

        private ICommand initializeCommand;

        public WarehouseInfoTabViewModel(ApplicationDatabaseContext db, SectorStore sectorStore)
        {
            _db = db;
            _store = sectorStore;

            initializeCommand = new LoadingCommand(sectorStore);
           

        }
    }
}
