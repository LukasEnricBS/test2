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
    public class DeckController : ApiController
    {

        /************************************************** GETS *********************************************************/

        [HttpGet]
        [Route("api/deck/{id?}")]
        public HttpResponseMessage GetTableDeck(int id)
        {
            var deck = DeckRepository.GetTableDeck(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, deck);
            return response;
        }

        [HttpGet]
        [Route("api/deckC/{id?}")]
        public HttpResponseMessage GetTableCommonCards(int id)
        {
            var deck = DeckRepository.GetTableCommonCards(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, deck);
            return response;
        }

        [HttpGet]
        [Route("api/deckN/{id?}/{name?}")]
        public HttpResponseMessage GetPlayerCards(int id, string name)
        {
            var deck = DeckRepository.GetTableDeckPlayerCards(id,name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, deck);
            return response;
        }

        [HttpPut]
        [Route("api/deckUp/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody]Deck val)
        {
            DeckRepository.UpdateDeckTable(id,val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}