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
        public string Warehouse => _store.Warehouse;

        public string Operator => _store.Operator;

        private ObservableCollection<Sector> _sectors = new ObservableCollection<Sector>();

        public ObservableCollection<Sector> Sectors
        {
            get { return _sectors; }
            set { _sectors = value; }
        }

        private readonly SectorStore _store;

        public LoadSectorsCommand InitializeCommand { get; }

        public WarehouseInfoTabViewModel(SectorStore sectorStore)
        {
            _store = sectorStore;

            InitializeCommand = new LoadSectorsCommand(sectorStore, this);

            //InitializeCommand.Execute(null);
        }
    }
}
