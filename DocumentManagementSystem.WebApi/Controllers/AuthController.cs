using DocumentManagementSystem.Contracts.ContractModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DocumentManagementSystem.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        ILog logger = LogManager.GetLogger("LogFileAppender");
        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Post(UserContractModel userContractModel)
        {
            try
            {
                var re = Request;
                var header = re.Headers;

                if (header.Contains("Username"))
                {
                    if (header.Contains("Admin"))
                    {
                        string value = header.GetValues("Admin").First();
                        userContractModel.Admin = value == "1";
                    }

                    if (string.IsNullOrEmpty(header.GetValues("Username").First()))
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, userContractModel);
                }

                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }

}
