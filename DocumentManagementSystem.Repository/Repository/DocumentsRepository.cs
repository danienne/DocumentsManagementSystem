using DocumentManagementSystem.Contracts.Repository;
using DocumentManagementSystem.Entities;
using DocumentManagementSystem.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository.Repository
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private DocumentManagementSystemContext context = new DocumentManagementSystemContext();

        public void UpdateDocument(Document doc)
        {
            context.Entry(doc).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void SaveDocument(Document doc)
        {
            context.Documents.Add(doc);
            context.SaveChanges();
        }

        public Document GetDocument(int id)
        {
            return context.Documents.Find(id);
        }

        public IQueryable<Document> GetDocuments()
        {
            return context.Documents;
        }
    }
}
