using DocumentManagementSystem.Contracts.ContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Contracts.Business
{
    public interface IDocumentsBusiness 
    {
        void UploadDocument(DocumentContractModel documentContractModel);
        IQueryable<DocumentContractModel> GetDocuments();
        DocumentContractModel DownloadFile(int documentId);
    }
}
