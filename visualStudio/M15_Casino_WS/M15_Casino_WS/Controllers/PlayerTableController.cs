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
    public class PlayerTableController : ApiController
    {
        /************************************************** GETS *********************************************************/

        [HttpGet]
        [Route("api/playerTables/{id?}")]
        public HttpResponseMessage GetPlayersInTable(int id)
        {
            var players = PlayerTableRepository.GetPlayerTableByTableId(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, players);
            return response;
        }

        [HttpGet]
        [Route("api/playerTablesN/{name?}")]
        public HttpResponseMessage GetPlayerInTableByName(string name)
        {
            var players = PlayerTableRepository.GetPlayerTableByPlayerName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, players);
            return response;
        }

        /************************************************** POST + PUT + DELETE *******************************************/

        [HttpPost]
        [Route("api/playerTable/")]
        public HttpResponseMessage Post([FromBody]PlayerTable val)
        {
            var player = PlayerTableRepository.InsertPlayerTable(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);
            return response;
        }

        [HttpPut]
        [Route("api/playerTable/{name?}")]
        public HttpResponseMessage Put(string name, [FromBody]PlayerTable val)
        {
            var player = PlayerTableRepository.UpdatePlayerTable(name, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);
            return response;
        }

        [HttpDelete]
        [Route("api/playerTable/{id?}/{name?}")]
        public HttpResponseMessage Delete(int id, string name)
        {
            PlayerTableRepository.DeletePlayerTable(id, name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}