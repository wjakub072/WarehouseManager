using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Stores
{
    internal class DocumentStore : StoreBase
    {
        private readonly ApplicationDatabaseContext _db;

        public DocumentStore(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        private List<Document> _documents = new List<Document>();
        public IEnumerable<Document> Documents { get => _documents; }

        public Document SelectedDocument { get; set; }


        public async override Task Load()
        {
            _documents = await _db.Documents.ToListAsync();
        }

        public async Task DeleteDocument()
        {
            _db.Documents.Remove(SelectedDocument);
            await _db.SaveChangesAsync();
        }

        // add through new view 
        public async Task AddDocument(Document document)
        {
            _db.Documents.Add(document);
            await _db.SaveChangesAsync();

            _documents.Add(document);
        }

        // edit through new view
        public bool EditingMode { get; set; }
    }
}
