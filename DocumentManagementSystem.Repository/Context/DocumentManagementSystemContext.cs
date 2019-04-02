using DocumentManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository.Context
{
    public class DocumentManagementSystemContext : DbContext
    {
        public DocumentManagementSystemContext() :
            base("name=DocumentManagementSystemContext")
        {
        }
        public DbSet<Document> Documents { get; set; }
    }
}
