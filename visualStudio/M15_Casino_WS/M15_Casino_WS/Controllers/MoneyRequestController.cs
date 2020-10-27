using M15_Casino_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace M15_Casino_WS.Controllers
{
    public class MoneyRequestController : ApiController
    {

        /************************************************** GETS *********************************************************/

        [HttpGet]
        [Route("api/requests")]
        public HttpResponseMessage Get()
        {
            var requests = MoneyRequestRepository.GetAllMoneyRequests();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requests);
            return response;
        }

        [HttpGet]
        [Route("api/requests/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var request = MoneyRequestRepository.GetMoneyRequest(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, request);
            return response;
        }

        [HttpGet]
        [Route("api/requestsN/{name?}")]
        public HttpResponseMessage GetPlayerRequests(string name)
        {
            var request = MoneyRequestRepository.GetMoneyRequestsByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, request);
            return response;
        }

        [HttpGet]
        [Route("api/pendingRequests")]
        public HttpResponseMessage GetPending()
        {
            var requests = MoneyRequestRepository.GetAllPendingMoneyRequests();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requests);
            return response;
        }

        [HttpGet]
        [Route("api/acceptedRequests")]
        public HttpResponseMessage GetAccepted()
        {
            var requests = MoneyRequestRepository.GetAllAcceptedMoneyRequests();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requests);
            return response;
        }

        [HttpGet]
        [Route("api/deniedRequests")]
        public HttpResponseMessage GetDenied()
        {
            var requests = MoneyRequestRepository.GetAllDeniedMoneyRequests();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requests);
            return response;
        }

        /************************************************** POST + PUT *********************************************************/

        [HttpPost]
        [Route("api/request/")]
        public HttpResponseMessage Post([FromBody]MoneyRequest val)
        {
            var request = MoneyRequestRepository.InsertMoneyRequest(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, request);
            return response;
        }

        [HttpPut]
        [Route("api/request/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody]MoneyRequest val)
        {
            var request = MoneyRequestRepository.UpdateMoneyRequest(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, request);
            return response;
        }

    }
}