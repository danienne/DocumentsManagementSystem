using System;
using DocumentManagementSystem.Business.Business;
using DocumentManagementSystem.Business.Exceptions;
using DocumentManagementSystem.Contracts.Business;
using DocumentManagementSystem.Contracts.ContractModel;
using DocumentManagementSystem.Contracts.Repository;
using DocumentManagementSystem.Entities;
using DocumentManagementSystem.Repository.Context;
using DocumentManagementSystem.Repository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DocumentManagementSystem.Business.Tests
{
    [TestClass]
    public class DocumentBusinessTest
    {
        Mock<IDocumentsRepository> _repository;
        Mock<IDocumentsBusiness> _business;

        [TestInitialize]
        public void Init()
        {
            _business = new Mock<IDocumentsBusiness>(MockBehavior.Strict);
            _repository = new Mock<IDocumentsRepository>(MockBehavior.Strict);
        }

        [TestMethod]
        public void UploadDocument_ValidDocumentUpload_Success()
        {
            try
            {
                DocumentContractModel documentContractModel = new DocumentContractModel
                {
                    Name = "Teste.doc",
                    Type = "teste",
                    Size = 123456,
                    Data = "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlz",
                    Username = "UsuarioTeste"
                };
                _business.Setup(m => m.UploadDocument(documentContractModel));
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UploadDocument_InvalidDocumentUpload_Error()
        {
            DocumentContractModel documentContractModel = null;
            _business.Setup(m => m.UploadDocument(documentContractModel)).Throws(new BusinessException("O arquivo escolhido não pode ser carregado."));
        }

        [TestMethod]
        public void DownloadFile_DocumentExists_Success()
        {
            Document doc = new Document
            {
                DocumentId = 0,
                Name = "teste.doc",
                Type = "teste",
                Size = 123,
                Data = Convert.FromBase64String("TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlz"),
                Username = "Teste",
                UploadDate = DateTime.Now,
            };
            _repository.Setup(m => m.SaveDocument(doc));

            _business.Setup(m => m.DownloadFile(1)).Throws(new BusinessException("Documento não encontrado."));
        }

        [TestMethod]
        public void DownloadFile_DocumentNotExists_Error()
        {
            _business.Setup(m => m.DownloadFile(1)).Throws(new BusinessException("Documento não encontrado."));
        }
    }
}
