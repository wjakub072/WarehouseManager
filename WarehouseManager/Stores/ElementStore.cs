using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Stores
{
    internal class ElementStore : StoreBase
    {
        private readonly ApplicationDatabaseContext _db;

        public ElementStore(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        private List<Element> _elementsToDelete = new List<Element>();
        private List<Element> _elements = new List<Element>();
        public IEnumerable<Element> Elements { get => _elements; }

        public Element SelectedElement { get; set; }

        public int DocumentId { get; set; }

        public async override Task Load()
        {
            _elements = await _db.Elements.Where(e=> e.DeliveryId == DocumentId).ToListAsync();
        }

        public void DeleteElement()
        {
            _elements.Remove(SelectedElement);
            _elementsToDelete.Add(SelectedElement);
        }

        public void AddElement(Element element)
        {
            _elements.Add(element);
        }

        public async Task RemoveElements()
        {
            _db.Elements.RemoveRange(_elementsToDelete);
            await _db.SaveChangesAsync();

            _elementsToDelete.Clear();
        }

        public async Task SaveRangeToDatabase(int documentId)
        {
            var unsaved = _elements.Where(a => a.Element_Id == 0 && a.DeliveryId == documentId).ToList();

            _db.Elements.AddRange(unsaved);

            await _db.SaveChangesAsync();
        }
    }
}
