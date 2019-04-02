using DocumentManagementSystem.Business.Exceptions;
using DocumentManagementSystem.Contracts.Business;
using DocumentManagementSystem.Contracts.ContractModel;
using DocumentManagementSystem.Contracts.Repository;
using DocumentManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Business.Business
{
    public class DocumentsBusiness : IDocumentsBusiness
    {
        private readonly IDocumentsRepository repo;
        public DocumentsBusiness(IDocumentsRepository repo)
        {
            this.repo = repo;
        }

        public void UploadDocument(DocumentContractModel documentContractModel)
        {
            ValidarModel(documentContractModel);
            Document doc = new Document()
            {
                Name = documentContractModel.Name,
                Type = documentContractModel.Type,
                Size = documentContractModel.Size,
                Data = Convert.FromBase64String(documentContractModel.Data),
                Username = documentContractModel.Username,
                UploadDate = DateTime.Now
            };

            repo.SaveDocument(doc);
        }

        public IQueryable<DocumentContractModel> GetDocuments()
        {
            IQueryable<DocumentContractModel> documents = null;
            documents = repo.GetDocuments().Select(x => new DocumentContractModel
            {
                DocumentId = x.DocumentId,
                Name = x.Name,
                Size = x.Size,
                Type = x.Type,
                UploadDate = x.UploadDate,
                Username = x.Username,
                LastDownloadDate = x.LastDownloadDate
            });

            return documents.OrderByDescending(x => x.UploadDate);
        }

        public DocumentContractModel DownloadFile(int documentId)
        {
            Document document = repo.GetDocument(documentId);
            ValidarDocumentoParaDownload(document);
            document.LastDownloadDate = DateTime.Now;
            repo.UpdateDocument(document);

            DocumentContractModel docContractModel = new DocumentContractModel
            {
                Name = document.Name,
                DataByteArray = document.Data
            };
            return docContractModel;
        }

        private void ValidarModel(DocumentContractModel documentContractModel)
        {
            if (documentContractModel == null || string.IsNullOrEmpty(documentContractModel.Data))
            {
                throw new BusinessException("O arquivo escolhido não pode ser carregado.");
            }
        }

        private void ValidarDocumentoParaDownload(Document document)
        {
            if (document == null)
            {
                throw new BusinessException("Documento não encontrado.");
            }
        }
    }
}
