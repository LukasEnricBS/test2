using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Controller
{
    class TableController
    {

        CRUD crud;
        TableView v;
        MenuView mv;
        String cardBack;
        String background;

        CancellationTokenSource cts = new CancellationTokenSource();
        ClientWebSocket socket = new ClientWebSocket();

        public TableController(MenuView menuV)
        {
            crud = new CRUD();
            v = new TableView();
            mv = menuV;
            Start();
        }

        private void Start()
        {
            StartSockets();
            InitListeners();
            UpdateGlobalPlayers();

            LoadPlayerValues();
            LoadTableValues();
            CheckIfActivePlayer();
            v.lb_winner.Visible = false;
            v.Show();
        }

        private void InitListeners()
        {
            v.bt_call.Click += Bt_call_Click;
            v.bt_check.Click += Bt_check_Click;
            v.bt_fold.Click += Bt_fold_Click;
            v.bt_raise.Click += Bt_raise_Click;
            v.playAgain_BT.Click += PlayAgain_BT_Click;
            v.endGame_BT.Click += EndGame_BT_Click;

            v.tb_usrMoney.TextChanged += Tb_usrMoney_TextChanged;

            v.FormClosed += V_FormClosed;
        }

        private void V_FormClosed(object sender, FormClosedEventArgs e)
        {
            alert5Changes("closeGame$$" + Globals.currentTable.id + "$$" + Globals.activeUser.usrName, "updatePlayers",
                "updateTables", "updateTablePlayers" + Globals.currentTable.id, "updateButtons" + Globals.currentTable.id);
        }

        private void EndGame_BT_Click(object sender, EventArgs e)
        {
            alert5Changes("closeGame$$" + Globals.currentTable.id + "$$" + "ñññ", "updatePlayers",
                "updateTables", "updateTablePlayers" + Globals.currentTable.id, "updateButtons"+ Globals.currentTable.id);
        }

        private void CloseGame()
        {
            v.Close();
            mv.Show();
        }

        private void PlayAgain_BT_Click(object sender, EventArgs e)
        {
            alertChanges("nextRound" + Globals.currentTable.id);
        }

        private async void StartSockets()
        {
            await InitWebSocket();
        }

        private void UpdateGlobalPlayer()
        {
            Player player = crud.GetPlayerByName(Globals.activeUser.usrName);
            Globals.activeUser = player;
        }

        private void LoadPlayerValues()
        {
            UpdateGlobalPlayer();
            SetPlayerCardBack();
            SetPlayerBackground();

            v.BackgroundImage = new Bitmap(Globals.resourceDirectory + background);

            v.tb_usrName.Text = Globals.activeUser.usrName;
            v.tb_usrBet.Text = "0";
            v.tb_totalBet.Text = Globals.playersInGame.Where(x=>x.playerName.Equals(Globals.activeUser.usrName)).SingleOrDefault().totalBet.ToString();
            v.tb_usrMoney.Text = Globals.activeUser.currentMoney.ToString();

            List<Deck> cards = crud.GetTablePlayerCards(Globals.currentTable.id,Globals.activeUser.usrName);

            int cardsShown = 1;

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].playerName.Equals(Globals.activeUser.usrName))
                {
                    switch (cardsShown)
                    {
                        case 1:
                            v.pb_usrCard1.Image = new Bitmap(Globals.resourceDirectory + GetImageForCard(cards[i].cardNum, cards[i].cardSuit));
                            cardsShown++;
                            break;
                        case 2:
                            v.pb_usrCard2.Image = new Bitmap(Globals.resourceDirectory + GetImageForCard(cards[i].cardNum, cards[i].cardSuit));
                            cardsShown++;
                            break;
                        default:
                            break;
                    }
                }
            }

            PlayerTable p = crud.GetPlayerInTableByName(Globals.activeUser.usrName);

            if (p.isSmallBlind)
            {
                int usrMoney = Int32.Parse(v.tb_usrMoney.Text);
                v.tb_usrMoney.Text = (usrMoney - 50).ToString();

                Globals.activeUser.currentMoney = Int32.Parse(v.tb_usrMoney.Text);
            }
            else if (p.isBigBlind)
            {
                int usrMoney = Int32.Parse(v.tb_usrMoney.Text);
                v.tb_usrMoney.Text = (usrMoney - 100).ToString();

                Globals.activeUser.currentMoney = Int32.Parse(v.tb_usrMoney.Text);
            }
        }

        private void LoadTableValues()
        {
            v.pb_tableCard1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
            v.pb_tableCard2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
            v.pb_tableCard3.Image = new Bitmap(Globals.resourceDirectory + cardBack);
            v.pb_tableCard4.Image = new Bitmap(Globals.resourceDirectory + cardBack);
            v.pb_tableCard5.Image = new Bitmap(Globals.resourceDirectory + cardBack);

            List<Deck> cards = crud.GetCommonCardsInTable(Globals.currentTable.id);

            int cardsShown = 0;

            for (int i = 0; i < cards.Count; i++)
            {
                if ( cards[i].played == true )
                {
                    cardsShown++;

                    switch (cardsShown)
                    {
                        case 1:
                            v.pb_tableCard1.Image = new Bitmap(Globals.resourceDirectory + GetImageForCard(cards[i].cardNum, cards[i].cardSuit));
                            break;
                        case 2:
                            v.pb_tableCard2.Image = new Bitmap(Globals.resourceDirectory + GetImageForCard(cards[i].cardNum, cards[i].cardSuit));
                            break;
                        case 3:
                            v.pb_tableCard3.Image = new Bitmap(Globals.resourceDirectory + GetImageForCard(cards[i].cardNum, cards[i].cardSuit));
                            break;
                        case 4:
                            v.pb_tableCard4.Image = new Bitmap(Globals.resourceDirectory + GetImageForCard(cards[i].cardNum, cards[i].cardSuit));
                            break;
                        case 5:
                            v.pb_tableCard5.Image = new Bitmap(Globals.resourceDirectory + GetImageForCard(cards[i].cardNum, cards[i].cardSuit));
                            break;
                        default:
                            break;
                    }
                }
            }

            setPlayerInfo();
        }

        private void setPlayerInfo()
        {
            try
            {
                Globals.playersInGame.Remove(Globals.playersInGame.Single(x => x.playerName.Equals(Globals.activeUser.usrName)));
            }
            catch (Exception es) { }

            foreach (PlayerTable p in Globals.playersInGame)
            {
                int pos = Globals.playersInGame.IndexOf(p);

                switch (pos)
                {
                    case 0:
                        v.lb_op1Name.Text = p.playerName;
                        v.lb_op1Bet.Text = p.totalBet.ToString();
                        v.pb_op1Card1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        v.pb_op1Card2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        break;
                    case 1:
                        v.lb_op2Name.Text = p.playerName;
                        v.lb_op2Bet.Text = p.totalBet.ToString();
                        v.pb_op2Card1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        v.pb_op2Card2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        break;
                    case 2:
                        v.lb_op3Name.Text = p.playerName;
                        v.lb_op3Bet.Text = p.totalBet.ToString();
                        v.pb_op3Card1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        v.pb_op3Card2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        break;
                    case 3:
                        v.lb_op4Name.Text = p.playerName;
                        v.lb_op4Bet.Text = p.totalBet.ToString();
                        v.pb_op4Card1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        v.pb_op4Card2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        break;
                    case 4:
                        v.lb_op5Name.Text = p.playerName;
                        v.lb_op5Bet.Text = p.totalBet.ToString();
                        v.pb_op5Card1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        v.pb_op5Card2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        break;
                    case 5:
                        v.lb_op6Name.Text = p.playerName;
                        v.lb_op6Bet.Text = p.totalBet.ToString();
                        v.pb_op6Card1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        v.pb_op6Card2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        break;
                    case 6:
                        v.lb_op7Name.Text = p.playerName;
                        v.lb_op7Bet.Text = p.totalBet.ToString();
                        v.pb_op7Card1.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        v.pb_op7Card2.Image = new Bitmap(Globals.resourceDirectory + cardBack);
                        break;
                }
            }
        }

        private void UpdateGlobalPlayers()
        {
            List<PlayerTable> player = crud.GetPlayersInTable(Globals.currentTable.id);
            Globals.playersInGame = player;
        }

        public async Task InitWebSocket()
        {
            string wsUri = string.Format(Globals.wsUri);
            await socket.ConnectAsync(new Uri(wsUri), cts.Token);

            await Task.Factory.StartNew(
                async () =>
                {
                    var rcvBytes = new byte[128];
                    var rcvBuffer = new ArraySegment<byte>(rcvBytes);
                    while (true)
                    {
                        WebSocketReceiveResult rcvResult = await socket.ReceiveAsync(rcvBuffer, cts.Token);
                        byte[] msgBytes = rcvBuffer.Skip(rcvBuffer.Offset).Take(rcvResult.Count).ToArray();
                        string rcvMsg = Encoding.UTF8.GetString(msgBytes);
                        if (rcvMsg.StartsWith("actionDone"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                int tableId = int.Parse(rcvMsg.Remove(0, 10));
                                if (tableId == Globals.currentTable.id)
                                {
                                    CheckIfActivePlayer();
                                    UpdateGlobalPlayers();
                                    LoadTableValues();
                                }
                            });
                        }
                        if (rcvMsg.StartsWith("nextRound"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                int tableId = int.Parse(rcvMsg.Remove(0, 9));
                                if (tableId == Globals.currentTable.id)
                                {
                                    v.lb_winner.Visible = false;
                                    UnsetNextRound();
                                    CheckIfActivePlayer();
                                    UpdateGlobalPlayers();
                                    LoadPlayerValues();
                                    LoadTableValues();
                                }
                            });
                        }
                        if (rcvMsg.StartsWith("closeGame"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                string[] tokens = rcvMsg.Split(new[] { "$$" }, StringSplitOptions.None);
                                int tableId = int.Parse(tokens[1]);
                                if (tokens[2].Equals(Globals.activeUser.usrName))
                                {
                                    Application.Exit();
                                }
                                if (tableId == Globals.currentTable.id)
                                {
                                    CloseGame();
                                }
                                
                            });
                        }
                        if (rcvMsg.StartsWith("Guanyador: $$"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                string[] tokens = rcvMsg.Split(new[] { "$$" }, StringSplitOptions.None);
                                int tableId = int.Parse(tokens[1]);
                                if (tableId == Globals.currentTable.id)
                                {
                                    v.lb_winner.Text = tokens[0] + tokens[2];
                                    v.lb_winner.Visible = true;

                                    CheckIfActivePlayer();
                                    CheckIfActivePlayerNextRound();
                                    UpdateGlobalPlayers();
                                    LoadTableValues();
                                    SetEndgameCards();
                                }
                            });
                        }
                    }
                }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public async void alertChanges(string message)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(message);
            var sendBuffer = new ArraySegment<byte>(sendBytes);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
        }

        public async void alert5Changes(string message1, string message2, string message3, string message4, string message5)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(message1);
            byte[] sendBytes2 = Encoding.UTF8.GetBytes(message2);
            byte[] sendBytes3 = Encoding.UTF8.GetBytes(message3);
            byte[] sendBytes4 = Encoding.UTF8.GetBytes(message4);
            byte[] sendBytes5 = Encoding.UTF8.GetBytes(message5);
            var sendBuffer = new ArraySegment<byte>(sendBytes);
            var sendBuffer2 = new ArraySegment<byte>(sendBytes2);
            var sendBuffer3 = new ArraySegment<byte>(sendBytes3);
            var sendBuffer4 = new ArraySegment<byte>(sendBytes4);
            var sendBuffer5 = new ArraySegment<byte>(sendBytes5);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
            await socket.SendAsync(sendBuffer2, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
            await socket.SendAsync(sendBuffer3, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
            await socket.SendAsync(sendBuffer4, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
            await socket.SendAsync(sendBuffer5, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
        }

        private void Tb_usrMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int curMoney = Int32.Parse(v.tb_usrMoney.Text);

                if (curMoney <= 0)
                {
                    v.tb_usrMoney.BackColor = Color.Red;
                    v.tb_usrMoney.ForeColor = Color.White;
                }
                else
                {
                    v.tb_usrMoney.ResetBackColor();
                    v.tb_usrMoney.ResetForeColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en usrMoney.TextChanged a TableController: " + ex.Message);
            }
        }

        private void Bt_raise_Click(object sender, EventArgs e)
        {
            try
            {
                int raiseBet = 0;

                try
                {
                    raiseBet = Int32.Parse(v.tb_usrBet.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Introdueix una quantitat vàlida");
                }


                int curMoney = Int32.Parse(v.tb_usrMoney.Text);

                if (raiseBet > curMoney)
                {
                    raiseBet = curMoney;
                }

                List<PlayerTable> list = crud.GetPlayersInTable(Globals.currentTable.id);
                PlayerTable p = list.Where(x => x.playerName.Equals(Globals.activeUser.usrName)).FirstOrDefault();
                int maxBet = list.Where(x => x.hasFolded == false).OrderByDescending(x => x.totalBet).FirstOrDefault().totalBet;
                int pRaiseBet = raiseBet + p.totalBet;

                if (pRaiseBet <= maxBet)
                {
                    MessageBox.Show("Necessites fer una aposta més alta.");
                }
                else
                {
                    curMoney -= raiseBet;

                    v.tb_usrMoney.Text = curMoney.ToString();

                    int totalBet = Int32.Parse(v.tb_totalBet.Text);

                    v.tb_totalBet.Text = (totalBet + raiseBet).ToString();

                    p.totalBet = totalBet + raiseBet;
                    crud.UpdateTablePlayer(p);

                    alertChanges("actionDone" + Globals.currentTable.id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en raiseClick a TableController: " + ex.Message);
            }
        }

        private void Bt_fold_Click(object sender, EventArgs e)
        {
            try
            {
                PlayerTable p = crud.GetPlayerInTableByName(Globals.activeUser.usrName);
                p.hasFolded = true;
                crud.UpdateTablePlayer(p);
                alertChanges("actionDone" + Globals.currentTable.id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en foldClick a TableController: " + ex.Message);
            }
        }

        private void Bt_check_Click(object sender, EventArgs e)
        {
            try
            {
                List<PlayerTable> list = crud.GetPlayersInTable(Globals.currentTable.id);
                PlayerTable p = list.Where(x => x.playerName.Equals(Globals.activeUser.usrName)).FirstOrDefault();
                int maxBet = list.Where(x => x.hasFolded == false).OrderByDescending(x => x.totalBet).FirstOrDefault().totalBet;

                if (p.totalBet >= maxBet)
                {
                    alertChanges("actionDone" + Globals.currentTable.id);
                }
                else
                {
                    MessageBox.Show("La teva aposta no és suficient.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en checkClick a TableController: " + ex.Message);
            }
        }

        private void Bt_call_Click(object sender, EventArgs e)
        {
            try
            {
                List<PlayerTable> list = crud.GetPlayersInTable(Globals.currentTable.id);
                PlayerTable p = list.Where(x => x.playerName.Equals(Globals.activeUser.usrName)).FirstOrDefault();
                int maxBet = list.Where(x => x.hasFolded == false).OrderByDescending(x => x.totalBet).FirstOrDefault().totalBet;
                int betDiff = maxBet - p.totalBet;
                p.totalBet = maxBet;
                v.tb_totalBet.Text = maxBet.ToString();

                if (p.totalBet >= maxBet)
                {
                    int usrMoney = Int32.Parse(v.tb_usrMoney.Text);
                    v.tb_usrMoney.Text = (usrMoney - betDiff).ToString();

                    Globals.activeUser.currentMoney = Int32.Parse(v.tb_usrMoney.Text);

                    crud.UpdateTablePlayer(p);
                    alertChanges("actionDone" + Globals.currentTable.id);
                }
                else
                {
                    MessageBox.Show("La teva aposta no és suficient.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en callClick a TableController: " + ex.Message);
            }
        }
        
        private void CheckIfActivePlayer()
        {
            try
            {
                PlayerTable p = crud.GetPlayerInTableByName(Globals.activeUser.usrName);

                if (p != null)
                {
                    if (p.isActivePlayer == true)
                    {
                        ButtonStateOn();
                    }
                    else if (p.isActivePlayer == false)
                    {
                        ButtonStateOff();
                    }
                }
            }
            catch (Exception es)
            {
            }
        }

        private void CheckIfActivePlayerNextRound()
        {
            try
            {
                PlayerTable p = crud.GetPlayerInTableByName(Globals.activeUser.usrName);

                if (p != null)
                {
                    if (p.isActivePlayer == true)
                    {
                        v.playAgain_BT.Enabled = true;
                        v.playAgain_BT.Visible = true;
                        v.endGame_BT.Enabled = true;
                        v.endGame_BT.Visible = true;
                    }
                    else if (p.isActivePlayer == false)
                    {
                        v.playAgain_BT.Enabled = false;
                        v.playAgain_BT.Visible = false;
                        v.endGame_BT.Enabled = false;
                        v.endGame_BT.Visible = false;
                    }
                }
            }
            catch (Exception es)
            {
            }
        }

        private void UnsetNextRound()
        {
            v.playAgain_BT.Enabled = false;
            v.playAgain_BT.Visible = false;
            v.endGame_BT.Enabled = false;
            v.endGame_BT.Visible = false;
        }

        private void SetPlayerCardBack()
        {
            int choice = Globals.activeUser.cardBack;

            switch (choice)
            {
                case 0:
                    cardBack = "Red_back.jpg";
                    break;
                case 1:
                    cardBack = "Yellow_back.jpg";
                    break;
                case 2:
                    cardBack = "blue_back.jpg";
                    break;
                default:
                    cardBack = "ERROR.jpg";
                    break;
            }
        }

        private void SetPlayerBackground()
        {
            int choice = Globals.activeUser.gameBg;

            switch (choice)
            {
                case 0:
                    background = "windows.png";
                    break;
                case 1:
                    background = "beach.png";
                    break;
                case 2:
                    background = "snow.png";
                    break;
                default:
                    background = "ERROR.jpg";
                    break;
            }
        }

        private void ButtonStateOn()
        {
            v.bt_call.Enabled = true;
            v.bt_check.Enabled = true;
            v.bt_fold.Enabled = true;
            v.bt_raise.Enabled = true;
        }

        private void ButtonStateOff()
        {
            v.bt_call.Enabled = false;
            v.bt_check.Enabled = false;
            v.bt_fold.Enabled = false;
            v.bt_raise.Enabled = false;
        }

        private void SetEndgameCards()
        {
            try
            {
                Globals.playersInGame.Remove(Globals.playersInGame.Single(x => x.playerName.Equals(Globals.activeUser.usrName)));
            }
            catch (Exception es) { }

            foreach (PlayerTable p in Globals.playersInGame)
            {
                int pos = Globals.playersInGame.IndexOf(p);

                List<Deck> cards = crud.GetTablePlayerCards(p.tableId, p.playerName);

                string card1 = GetImageForCard(cards[0].cardNum, cards[0].cardSuit);
                string card2 = GetImageForCard(cards[1].cardNum, cards[1].cardSuit);

                switch (pos)
                {
                    case 0:
                        v.lb_op1Name.Text = p.playerName;
                        v.lb_op1Bet.Text = p.totalBet.ToString();
                        v.pb_op1Card1.Image = new Bitmap(Globals.resourceDirectory + card1);
                        v.pb_op1Card2.Image = new Bitmap(Globals.resourceDirectory + card2);
                        break;
                    case 1:
                        v.lb_op2Name.Text = p.playerName;
                        v.lb_op2Bet.Text = p.totalBet.ToString();
                        v.pb_op2Card1.Image = new Bitmap(Globals.resourceDirectory + card1);
                        v.pb_op2Card2.Image = new Bitmap(Globals.resourceDirectory + card2);
                        break;
                    case 2:
                        v.lb_op3Name.Text = p.playerName;
                        v.lb_op3Bet.Text = p.totalBet.ToString();
                        v.pb_op3Card1.Image = new Bitmap(Globals.resourceDirectory + card1);
                        v.pb_op3Card2.Image = new Bitmap(Globals.resourceDirectory + card2);
                        break;
                    case 3:
                        v.lb_op4Name.Text = p.playerName;
                        v.lb_op4Bet.Text = p.totalBet.ToString();
                        v.pb_op4Card1.Image = new Bitmap(Globals.resourceDirectory + card1);
                        v.pb_op4Card2.Image = new Bitmap(Globals.resourceDirectory + card2);
                        break;
                    case 4:
                        v.lb_op5Name.Text = p.playerName;
                        v.lb_op5Bet.Text = p.totalBet.ToString();
                        v.pb_op5Card1.Image = new Bitmap(Globals.resourceDirectory + card1);
                        v.pb_op5Card2.Image = new Bitmap(Globals.resourceDirectory + card2);
                        break;
                    case 5:
                        v.lb_op6Name.Text = p.playerName;
                        v.lb_op6Bet.Text = p.totalBet.ToString();
                        v.pb_op6Card1.Image = new Bitmap(Globals.resourceDirectory + card1);
                        v.pb_op6Card2.Image = new Bitmap(Globals.resourceDirectory + card2);
                        break;
                    case 6:
                        v.lb_op7Name.Text = p.playerName;
                        v.lb_op7Bet.Text = p.totalBet.ToString();
                        v.pb_op7Card1.Image = new Bitmap(Globals.resourceDirectory + card1);
                        v.pb_op7Card2.Image = new Bitmap(Globals.resourceDirectory + card2);
                        break;
                }
            }
        }

        private String GetImageForCard(int num, char suit)
        {
            try
            {
                String card = "";

                switch (num)
                {
                    case 1:
                        card = "1";
                        break;
                    case 2:
                        card = "2";
                        break;
                    case 3:
                        card = "3";
                        break;
                    case 4:
                        card = "4";
                        break;
                    case 5:
                        card = "5";
                        break;
                    case 6:
                        card = "6";
                        break;
                    case 7:
                        card = "7";
                        break;
                    case 8:
                        card = "8";
                        break;
                    case 9:
                        card = "9";
                        break;
                    case 10:
                        card = "10";
                        break;
                    case 11:
                        card = "11";
                        break;
                    case 12:
                        card = "12";
                        break;
                    case 13:
                        card = "13";
                        break;
                    default:
                        return "ERROR.jpg";
                }

                switch (suit)
                {
                    case 'C':
                        card = card + "C.jpg";
                        break;
                    case 'D':
                        card = card + "D.jpg";
                        break;
                    case 'H':
                        card = card + "H.jpg";
                        break;
                    case 'S':
                        card = card + "S.jpg";
                        break;
                    default:
                        return "ERROR.jpg";
                }

                return card;
            }
            catch (Exception ex)
            {
                return "ERROR.jpg";
            }
        }

    }
}
