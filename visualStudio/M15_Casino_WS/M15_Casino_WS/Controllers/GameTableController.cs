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
    public class GameTableController : ApiController
    {

        /************************************************** GETS *********************************************************/

        [HttpGet]
        [Route("api/tables")]
        public HttpResponseMessage GetAllTables()
        {
            var tables = GameTableRepository.GetAllGameTables();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tables);
            return response;
        }

        [HttpGet]
        [Route("api/tableName/{name?}")]
        public HttpResponseMessage GetByName(string name)
        {
            var table = GameTableRepository.GetGameTableByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, table);
            return response;
        }

        [HttpGet]
        [Route("api/tables/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var table = GameTableRepository.GetGameTable(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, table);
            return response;
        }

        /************************************************** POST + DELETE ***********************************************/

        [HttpPost]
        [Route("api/table/")]
        public HttpResponseMessage Post([FromBody]GameTable val)
        {
            var table = GameTableRepository.InsertGameTable(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, table);
            return response;
        }

        [HttpDelete]
        [Route("api/table/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            GameTableRepository.DeleteGameTable(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}