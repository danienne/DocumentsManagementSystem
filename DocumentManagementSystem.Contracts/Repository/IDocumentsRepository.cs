using DocumentManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Contracts.Repository
{
    public interface IDocumentsRepository
    {
        void UpdateDocument(Document doc);
        void SaveDocument(Document doc);
        Document GetDocument(int id);
        IQueryable<Document> GetDocuments();
    }
}
