using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DocumentManagementSystem.Business.Exceptions;
using DocumentManagementSystem.Contracts.Business;
using DocumentManagementSystem.Contracts.ContractModel;
using log4net;

namespace DocumentManagementSystem.WebApi.Controllers
{
    [RoutePrefix("api/documents")]
    public class DocumentsController : ApiController
    {
        ILog logger = LogManager.GetLogger("LogFileAppender");
        private IDocumentsBusiness business;
        public DocumentsController(IDocumentsBusiness business)
        {
            this.business = business;
        }

        [HttpGet]
        [Route("GetDocuments")]
        public HttpResponseMessage GetDocuments()
        {
            UserContractModel user = GetUser();
            if (!string.IsNullOrEmpty(user.Username))
            {
                try
                {
                    IQueryable<DocumentContractModel> documents = business.GetDocuments();
                    return Request.CreateResponse(HttpStatusCode.OK, documents);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        [HttpGet]
        [Route("DownloadFile/{documentId}")]
        public HttpResponseMessage DownloadFile(int documentId)
        {
            HttpResponseMessage result = null;
            try
            {
                DocumentContractModel document = business.DownloadFile(documentId);
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(document.DataByteArray);
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = document.Name;
                return result;
            }
            catch (BusinessException ex)
            {
                logger.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("UploadDocument")]
        public HttpResponseMessage UploadDocument(DocumentContractModel document)
        {
            UserContractModel user = GetUser();

            if (!string.IsNullOrEmpty(user.Username) && user.Admin)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                    document.Username = user.Username;
                    business.UploadDocument(document);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (BusinessException ex)
                {
                    logger.Error(ex.Message);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        private UserContractModel GetUser()
        {
            UserContractModel user = new UserContractModel();
            var re = Request;
            var header = re.Headers;

            if (header.Contains("Username"))
            {
                if (header.Contains("Admin"))
                {
                    string value = header.GetValues("Admin").First();
                    user.Admin = value == "1";
                }
                user.Username = header.GetValues("Username").First();
                return user;
            }
            return user;
        }
    }

}