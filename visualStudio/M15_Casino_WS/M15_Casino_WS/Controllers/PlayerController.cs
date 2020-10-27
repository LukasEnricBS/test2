using M15_Casino_WS.Models;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace M15_Casino_WS.Controllers
{
    public class PlayerController : ApiController
    {
        /************************************************** GETS *********************************************************/

        [HttpGet]
        [Route("api/players")]
        public HttpResponseMessage Get()
        {
            var players = PlayerRepository.GetAllPlayers();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, players);
            return response;
        }

        [HttpGet]
        [Route("api/ranking")]
        public HttpResponseMessage GetByMoney()
        {
            var players = PlayerRepository.GetAllPlayersByMoney();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, players);
            return response;
        }

        [HttpGet]
        [Route("api/players/{id?}")]
        public HttpResponseMessage Get(string id)
        {
            var player = PlayerRepository.GetPlayer(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);
            return response;
        }

        /************************************************** POST + PUT + DELETE *******************************************/

        [HttpPost]
        [Route("api/player/")]
        public HttpResponseMessage Post([FromBody]Player val)
        {
            var player = PlayerRepository.InsertPlayer(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);
            return response;
        }

        [HttpPut]
        [Route("api/player/{name?}")]
        public HttpResponseMessage Put(string name, [FromBody]Player val)
        {
            var player = PlayerRepository.UpdatePlayer(name, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);
            return response;
        }

        [HttpDelete]
        [Route("api/player/{id?}")]
        public HttpResponseMessage Delete(string id)
        {
            PlayerRepository.DeletePlayer(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}