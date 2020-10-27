using Microsoft.Web.WebSockets;
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
    public class WebSocketController : ApiController
    {

        [Route("api/websocket")]
        // WebSockets: Socket api call wss://host:port/api/websocket
        public HttpResponseMessage GetSocket()
        {
            HttpContext.Current.AcceptWebSocketRequest(new SocketHandler()); return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private class SocketHandler : WebSocketHandler
        {
            private static readonly WebSocketCollection Sockets = new WebSocketCollection();

            public SocketHandler()
            {
            }

            public override void OnOpen()
            {
                Sockets.Add(this);
            }

            public override void OnMessage(string message)
            {
                
                if (message.StartsWith("updateButtons"))
                {
                    Sockets.Broadcast(message);
                }
                else if (message.StartsWith("closeGame"))
                {
                    string[] tokens = message.Split(new[] { "$$" }, StringSplitOptions.None);
                    int tableId = int.Parse(tokens[1]);
                    GameTableRepository.DeleteGameTable(tableId);
                    Sockets.Broadcast(message);
                }
                else if (message.StartsWith("startGame"))
                {
                    SetGameCards(int.Parse(message.Remove(0, 9)));
                    FirstGameBets(int.Parse(message.Remove(0, 9)));
                    Sockets.Broadcast(message);
                }
                else if (message.StartsWith("nextRound"))
                {
                    ResetTableDeck(int.Parse(message.Remove(0, 9)));
                    ResetPlayerTable(int.Parse(message.Remove(0, 9)));
                    Sockets.Broadcast(message);
                }
                else if (message.StartsWith("actionDone"))
                {
                    if ( CheckIfEndGame(int.Parse(message.Remove(0, 10))) )
                    {
                        string winner = CalculateWinner(int.Parse(message.Remove(0, 10)));
                        Sockets.Broadcast("Guanyador: $$" + message.Remove(0, 10) + "$$" + winner);
                    }
                    else
                    {
                        if (CheckIfCanShowCard(int.Parse(message.Remove(0, 10))))
                        {
                            ShowNextCard(int.Parse(message.Remove(0, 10)));
                        }
                        NextPlayerTurn(int.Parse(message.Remove(0, 10)));
                        Sockets.Broadcast(message);
                    }
                    
                }
                else if (message.StartsWith("updateTablePlayers"))
                {
                    Sockets.Broadcast(message);
                }
                else
                {
                    switch (message)
                    {
                        case "updatePlayers":
                            Sockets.Broadcast("updatePlayers");
                            break;
                        case "updateRequests":
                            Sockets.Broadcast("updateRequests");
                            break;
                        case "updateTables":
                            Sockets.Broadcast("updateTables");
                            break;
                        default:
                            break;
                    }
                }                
            }

            private void SetGameCards(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();

                List<Deck> deck = dataContext.Decks.Where(x=>x.tableId == tableId).ToList();
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId).ToList();
                Random random = new Random();
                Deck d = new Deck();

                for (int i = 0; i < 5; i++)
                {
                    int pos;
                    do
                    {
                        pos = random.Next(deck.Count);
                        d = deck[pos];
                    } while (d.playerName != null);
                    deck[pos].playerName = "Admin";
                    if (i < 3) { deck[pos].played = true; }
                    else { deck[pos].played = false; }
                }
                dataContext.SaveChanges();

                foreach (var p in players)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int pos;
                        do
                        {
                            pos = random.Next(deck.Count);
                            d = deck[pos];
                        } while (d.playerName != null);
                        deck[pos].playerName = p.playerName;
                        deck[pos].played = false;
                    }
                    dataContext.SaveChanges();
                }
            }

            private void FirstGameBets(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId).ToList();

                foreach (var p in players)
                {
                    if ( p.isActivePlayer == true )
                    {
                        p.isActivePlayer = false;
                    }
                }
                dataContext.SaveChanges();
                if (players.Count <= 2)
                {
                    players[0].isActivePlayer = true;
                    players[0].isSmallBlind = true;
                    players[0].totalBet = 50;


                    players[1].isBigBlind = true;
                    players[1].totalBet = 100;
                }
                else
                {
                    players[0].isSmallBlind = true;
                    players[0].totalBet = 50;

                    players[1].isBigBlind = true;
                    players[1].totalBet = 100;

                    players[2].isActivePlayer = true;
                }
                dataContext.SaveChanges();
            }

            private void NextPlayerTurn(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId).ToList();

                bool found = false;
                int pos = 0;

                foreach (var p in players)
                {
                    if (p.isActivePlayer == true)
                    {
                        pos = players.IndexOf(p);
                        p.isActivePlayer = false;
                    }
                }
                dataContext.SaveChanges();

                for (int i = 1; !found && pos+i < players.Count; i++)
                {
                    if (players[pos+i].hasFolded == false)
                    {
                        players[pos + i].isActivePlayer = true;
                        dataContext.SaveChanges();
                        found = true;
                    }
                }

                for (int i = 0; !found &&  i < pos; i++)
                {
                    if (players[i].hasFolded == false)
                    {
                        players[i].isActivePlayer = true;
                        dataContext.SaveChanges();
                        found = true;
                    }
                }
            }

            private bool CheckIfEndGame(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId).ToList();
                List<Deck> middleCards = dataContext.Decks.Where(x => x.tableId == tableId && x.played != null).OrderByDescending(x => x.played).ToList();

                if ( players.Where( x => x.hasFolded == false).ToList().Count == 1 ) { return true; }
                else if ( CheckIfCanShowCard(tableId) && CheckIfAllCardsInPlay(tableId) ) { return true; }

                return false;
            }

            private string CalculateWinner(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId).ToList();

                string winner = "";

                if (players.Where(x => x.hasFolded == false).ToList().Count == 1)
                {
                    winner = players.Where(x => x.hasFolded == false).SingleOrDefault().playerName;
                }
                else
                {
                    List<HandTier> hands = new List<HandTier>();

                    List<Deck> cards = dataContext.Decks.Where(x => x.tableId == tableId && x.playerName != null).ToList();

                    foreach (var p in players.Where(x => x.hasFolded == false).ToList() )
                    {
                        List<Deck> temp = cards.Where(x => x.playerName.Equals(p.playerName) || x.playerName.Equals("Admin")).OrderBy(x => x.cardNum).ToList();

                        List<int> nums = temp.OrderBy(x=>x.cardNum).Select(x => x.cardNum).ToList();
                        List<string> suits = temp.Select(x => x.cardSuit).ToList();

                        var parelles = nums.GroupBy(x => x).Where(g => g.Count() == 2).Select(g=>g.Key);
                        var trio = nums.GroupBy(x => x).Where(g => g.Count() == 3).Select(g => g.Key);
                        var poker = nums.GroupBy(x => x).Where(g => g.Count() == 4).Select(g => g.Key);

                        var color = suits.GroupBy(x => x).Where(g => g.Count() == 5).Select(g => g.Key);

                        bool escala = false;
                        int count = 1;

                        for (int i = 1; i < nums.Count; i++)
                        {
                            if ( nums[i] == nums[i-1] + 1 )
                            {
                                count++;
                            }
                            else
                            {
                                count = 1;
                            }
                            if (count == 5)
                            {
                                escala = true;
                                break;
                            }
                        }

                        HandTier h = new HandTier();
                        h.usrName = p.playerName;
                        h.cards = nums;
                        h.suits = suits;

                        if (escala && color.Count() == 1)
                        {
                            h.priority = 8;
                        }
                        else if ( poker.Count() == 1 )
                        {
                            h.priority = 7;
                        }
                        else if (trio.Count() >= 1 && parelles.Count() >= 1)
                        {
                            h.priority = 6;
                        }
                        else if (color.Count() == 1 )
                        {
                            h.priority = 5;
                        }
                        else if ( escala )
                        {
                            h.priority = 4;
                        }
                        else if (trio.Count() >= 1)
                        {
                            h.priority = 3;
                        }
                        else if (parelles.Count() > 1)
                        {
                            h.priority = 2;
                        }
                        else if (parelles.Count() == 1)
                        {
                            h.priority = 1;
                        }
                        else
                        {
                            h.priority = 0;
                        }
                        hands.Add(h);
                    }

                    hands = hands.OrderByDescending(x=>x.priority).ToList();

                    /* TODO: IF SAME TIER WHO WINS */

                    HandTier ht = hands.FirstOrDefault();

                    if ( hands.Where(x=>x.priority == ht.priority).Count() > 1 )
                    {
                        Random rd = new Random();
                        int pos = -1;
                        int greatNum = -1;
                        bool tie = false;

                        hands = hands.Where(x => x.priority == ht.priority).ToList();

                        switch (ht.priority)
                        {
                            case 1:
                            case 2:
                                /*PAIRS*/
                                for (int i = 0; i < hands.Count; i++)
                                {
                                    var parelles = hands[i].cards.GroupBy(x => x).Where(g => g.Count() == 2).Select(g => g.Key);
                                    if (parelles.OrderByDescending(j => j).FirstOrDefault() == greatNum)
                                    {
                                        tie = true;
                                        break;
                                    }
                                    else if (parelles.OrderByDescending(j => j).FirstOrDefault() > greatNum)
                                    {
                                        greatNum = parelles.OrderByDescending(j => j).FirstOrDefault();
                                        pos = i;
                                    }
                                }
                                if (tie)
                                {
                                    pos = rd.Next(hands.Count);
                                    winner = hands[pos].usrName;
                                }
                                else
                                {
                                    winner = hands[pos].usrName;
                                }
                                break;
                            case 3:
                                /*THREE OF A KIND*/
                                for (int i = 0; i < hands.Count; i++)
                                {
                                    var trio = hands[i].cards.GroupBy(x => x).Where(g => g.Count() == 3).Select(g => g.Key);
                                    if (trio.OrderByDescending(j => j).FirstOrDefault() == greatNum)
                                    {
                                        tie = true;
                                        break;
                                    }
                                    else if (trio.OrderByDescending(j => j).FirstOrDefault() > greatNum)
                                    {
                                        greatNum = trio.OrderByDescending(j => j).FirstOrDefault();
                                        pos = i;
                                    }
                                }
                                if (tie)
                                {
                                    pos = rd.Next(hands.Count);
                                    winner = hands[pos].usrName;
                                }
                                else
                                {
                                    winner = hands[pos].usrName;
                                }
                                break;
                            case 4:
                            case 8:
                                /* STRAIGHTS tie funciona al reves aqui */
                                int count = 1;
                                for (int i = 0; !tie && i < hands.Count; i++)
                                {
                                    for (int j = 1; j < hands[i].cards.Count; j++)
                                    {
                                        if (hands[i].cards[j] == hands[i].cards[j - 1] + 1)
                                        {
                                            count++;
                                        }
                                        else
                                        {
                                            count = 1;
                                        }
                                        if (count == 5 && hands[i].cards[j] == greatNum)
                                        {
                                            tie = true;
                                            break;
                                        }
                                        else if (count == 5 && hands[i].cards[j] > greatNum)
                                        {
                                            greatNum = hands[i].cards[j];
                                            pos = i;
                                        }
                                    }
                                }
                                if (!tie)
                                {
                                    pos = rd.Next(hands.Count);
                                    winner = hands[pos].usrName;
                                }
                                else
                                {
                                    winner = hands[pos].usrName;
                                }
                                break;
                            case 0:
                            case 5:
                                /*FLUSH*/
                                pos = rd.Next(hands.Count);
                                winner = hands[pos].usrName;
                                break;
                            case 6:
                                /*FULL HOUSE*/

                                bool goesToPairs = false;

                                for (int i = 0; i < hands.Count; i++)
                                {
                                    var trio = hands[i].cards.GroupBy(x => x).Where(g => g.Count() == 3).Select(g => g.Key);
                                    if (trio.OrderByDescending(j => j).FirstOrDefault() == greatNum)
                                    {
                                        goesToPairs = true;
                                        greatNum = -1;
                                        pos = -1;
                                        break;
                                    }
                                    else if (trio.OrderByDescending(j => j).FirstOrDefault() > greatNum)
                                    {
                                        greatNum = trio.OrderByDescending(j => j).FirstOrDefault();
                                        pos = i;
                                    }
                                }
                                for (int i = 0; goesToPairs && i < hands.Count; i++)
                                {
                                    var parelles = hands[i].cards.GroupBy(x => x).Where(g => g.Count() == 2).Select(g => g.Key);
                                    if (parelles.OrderByDescending(j => j).FirstOrDefault() == greatNum)
                                    {
                                        tie = true;
                                        break;
                                    }
                                    else if (parelles.OrderByDescending(j => j).FirstOrDefault() > greatNum)
                                    {
                                        greatNum = parelles.OrderByDescending(j => j).FirstOrDefault();
                                        pos = i;
                                    }
                                }
                                if (tie)
                                {
                                    pos = rd.Next(hands.Count);
                                    winner = hands[pos].usrName;
                                }
                                else
                                {
                                    winner = hands[pos].usrName;
                                }
                                break;
                            case 7:
                                /*POKER*/
                                for (int i = 0; i < hands.Count; i++)
                                {
                                    var poker = hands[i].cards.GroupBy(x => x).Where(g => g.Count() == 4).Select(g => g.Key);

                                    if (poker.OrderByDescending(j => j).FirstOrDefault() == greatNum)
                                    {
                                        tie = true;
                                        break;
                                    }

                                    else if (poker.OrderByDescending(j => j).FirstOrDefault() > greatNum)
                                    {
                                        greatNum = poker.OrderByDescending(j => j).FirstOrDefault();
                                        pos = i;
                                    }
                                }
                                if (tie)
                                {
                                    pos = rd.Next(hands.Count);
                                    winner = hands[pos].usrName;
                                }
                                else
                                {
                                    winner = hands[pos].usrName;
                                }
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        winner = ht.usrName;
                    }
                }
                MoneyWinnerTransacion(winner, tableId);
                SetCardsFaceUp(tableId);
                return winner;
            }

            private void SetCardsFaceUp(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<Deck> deck = dataContext.Decks.Where(x => x.tableId == tableId && x.played != null).ToList();
                deck.ForEach(x => x.played = true);
                dataContext.SaveChanges();
            }

            private void ResetTableDeck(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<Deck> deck = dataContext.Decks.Where(x => x.tableId == tableId).ToList();
                foreach (var d in deck)
                {
                    d.playerName = null;
                    d.played = null;
                    dataContext.SaveChanges();
                }
            }

            private void ResetPlayerTable(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId).ToList();
                players.ForEach(x => x.isActivePlayer = false);
                dataContext.SaveChanges();
                players.ForEach(x => x.hasFolded = false);
                dataContext.SaveChanges();
                players.ForEach(x => x.totalBet = 0);
                dataContext.SaveChanges();
                players.ForEach(x => x.isBigBlind = false);
                dataContext.SaveChanges();

                int pos = 0;

                bool small = false;
                bool big = false;
                bool active = false;

                foreach (var p in players)
                {
                    if (p.isSmallBlind == true)
                    {
                        p.isSmallBlind = false;
                        dataContext.SaveChanges();
                        pos = players.IndexOf(p);
                        break;
                    }
                }

                for (int i = pos + 1; !active && i < players.Count; i++)
                {
                    if (small && big && !active)
                    {
                        players[i].isActivePlayer = true;
                        dataContext.SaveChanges();
                        active = !active;
                    }
                    else if (small && !big)
                    {
                        players[i].isBigBlind = true;
                        players[i].totalBet = 100;
                        dataContext.SaveChanges();
                        big = !big;
                    }
                    else if (!small)
                    {
                        players[i].isSmallBlind = true;
                        players[i].totalBet = 50;
                        dataContext.SaveChanges();
                        small = !small;
                    }
                }

                for (int i = 0; !active && i < players.Count; i++)
                {
                    if (small && big && !active)
                    {
                        players[i].isActivePlayer = true;
                        dataContext.SaveChanges();
                        active = !active;
                    }
                    else if (small && !big)
                    {
                        players[i].isBigBlind = true;
                        players[i].totalBet = 100;
                        dataContext.SaveChanges();
                        big = !big;
                    }
                    else if (!small)
                    {
                        players[i].isSmallBlind = true;
                        players[i].totalBet = 50;
                        dataContext.SaveChanges();
                        small = !small;
                    }
                }

                if (players.Count == 2)
                {
                    foreach (var item in players)
                    {
                        if (item.isSmallBlind == true)
                        {
                            item.isActivePlayer = true;
                            dataContext.SaveChanges();
                        }
                    }
                }

                SetGameCards(tableId);
            }

            private void MoneyWinnerTransacion(string name, int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId).ToList();

                foreach (var item in players)
                {
                    Player p = dataContext.Players.Where(x=>x.usrName.Equals(item.playerName)).SingleOrDefault();
                    if ( p.usrName.Equals(name) )
                    {
                        p.currentMoney = p.currentMoney + players.Sum(x=>x.totalBet) - item.totalBet;
                        dataContext.SaveChanges();
                    }
                    else
                    {
                        p.currentMoney = p.currentMoney - item.totalBet;
                        dataContext.SaveChanges();
                    }
                }

            }

            private bool CheckIfAllCardsInPlay(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<Deck> middleCards = dataContext.Decks.Where(x => x.tableId == tableId && x.played != null).OrderByDescending(x => x.played).ToList();
                return middleCards.All(x => x.played == true) ? true : false;
            }

            private bool CheckIfCanShowCard(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                /*and not folded*/
                List<PlayerTable> players = dataContext.PlayerTables.Where(x => x.tableId == tableId && x.hasFolded == false).ToList();

                int firstBet = (int) players.First().totalBet;
                return players.All(x => x.totalBet == firstBet) ? true : false;
            }

            private void ShowNextCard(int tableId)
            {
                casinoEntities dataContext = new casinoEntities();
                List<Deck> middleCards = dataContext.Decks.Where(x => x.tableId == tableId && x.played != null).OrderByDescending(x=>x.played).ToList();

                foreach (var c in middleCards)
                {
                    if (c.played == false)
                    {
                        c.played = true;
                        dataContext.SaveChanges();
                        break;
                    }
                }
            }

            public override void OnClose()
            {
                Sockets.Remove(this);
            }
        }

    }
}