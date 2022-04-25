using System.Threading.Tasks;

namespace WarehouseManager.Stores
{
    internal abstract class StoreBase
    {
        public abstract Task Load();
    }
}
