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
    class MenuController
    {
        CRUD crud;
        MenuView v;
        List<MoneyRequest> requests;

        CancellationTokenSource cts = new CancellationTokenSource();
        ClientWebSocket socket = new ClientWebSocket();

        public MenuController()
        {
            requests = new List<MoneyRequest>();
            crud = new CRUD();
            v = new MenuView();
            Start();
        }

        private void Start()
        {
            StartSockets();
            GetPlayerRequests();
            InitListeners();
            LoadListValues();
            LoadPlayerValues();
            LoadTableValues();
            ResetRankingDGV();
            SetUpComboBox();
            v.Show();
        }

        private async void StartSockets()
        {
            await InitWebSocket();
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
                        if (rcvMsg.StartsWith("updatePlayers"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                LoadPlayerValues();
                                ResetRankingDGV();
                            });
                        }
                        else if (rcvMsg.StartsWith("updateRequests"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                LoadPlayerValues();
                                ResetRankingDGV();
                                GetPlayerRequests();
                            });
                        }
                        else if (rcvMsg.StartsWith("updateTables"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                LoadTableValues();
                            });
                        }
                        else if (rcvMsg.StartsWith("updateTablePlayers"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                int tableId = int.Parse(rcvMsg.Remove(0, 18));
                                if ( Globals.currentTable != null && tableId == Globals.currentTable.id)
                                {
                                    LoadTablePlayers();
                                }
                            });
                        }
                        else if (rcvMsg.StartsWith("updateButtons"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                int tableId = int.Parse( rcvMsg.Remove(0,13) );
                                if (tableId == Globals.currentTable.id)
                                {
                                    NotInRoomButtonState();
                                }
                            });
                        }
                        else if (rcvMsg.StartsWith("startGame"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                int tableId = int.Parse(rcvMsg.Remove(0, 9));
                                if (tableId == Globals.currentTable.id)
                                {
                                    StartGame();
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

        public async void alert2Changes(string message1, string message2)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(message1);
            byte[] sendBytes2 = Encoding.UTF8.GetBytes(message2);
            var sendBuffer = new ArraySegment<byte>(sendBytes);
            var sendBuffer2 = new ArraySegment<byte>(sendBytes2);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
            await socket.SendAsync(sendBuffer2, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
        }

        public async void alert3Changes(string message1, string message2, string message3)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(message1);
            byte[] sendBytes2 = Encoding.UTF8.GetBytes(message2);
            byte[] sendBytes3 = Encoding.UTF8.GetBytes(message3);
            var sendBuffer = new ArraySegment<byte>(sendBytes);
            var sendBuffer2 = new ArraySegment<byte>(sendBytes2);
            var sendBuffer3 = new ArraySegment<byte>(sendBytes3);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
            await socket.SendAsync(sendBuffer2, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
            await socket.SendAsync(sendBuffer3, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
        }

        private void InitListeners()
        {
            v.moneyRequests_CB.SelectedIndexChanged += MoneyRequests_CB_SelectedIndexChanged;
            v.insertMoneyRequest_BT.Click += InsertMoneyRequest_BT_Click;
            v.bt_usrUpd.Click += Bt_usrUpd_Click;

            v.cb_usrCardBack.SelectedIndexChanged += Cb_usrCardBack_SelectedIndexChanged;
            v.cb_usrGameBg.SelectedIndexChanged += Cb_usrGameBg_SelectedIndexChanged;
            v.bt_createNewGame.Click += Bt_createNewGame_Click;
            v.bt_connectToGame.Click += Bt_connectToGame_Click;
            v.bt_startGame.Click += Bt_startGame_Click;
            v.bt_exitGame.Click += Bt_exitGame_Click;

            v.FormClosing += V_FormClosing;
        }

        private void V_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Cb_usrGameBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPlayerBackGround();
        }

        private void Cb_usrCardBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPlayerCardBack();
        }

        private void Bt_exitGame_Click(object sender, EventArgs e)
        {
            try
            {
                /* MARXA ACTIVE PLAYER */
                if (Globals.gameStats.isActivePlayer)
                {
                    crud.DeleteGameTable(Globals.currentTable.id);
                    alert3Changes("updateButtons"+ Globals.currentTable.id, "updateTablePlayers" + Globals.currentTable.id, "updateTables");
                }
                /* SI ESTA BUIDA ADIOS */
                else if (crud.GetPlayersInTable(Globals.currentTable.id).Count <= 0 )
                {
                    crud.DeleteGameTable(Globals.currentTable.id);
                    alert2Changes("updateTablePlayers" + Globals.currentTable.id, "updateTables");
                    NotInRoomButtonState();
                }
                else
                {
                    /* SORTIR DE LA TAULA */
                    crud.DeletePlayerTable(Globals.gameStats.tableId, Globals.activeUser.usrName);
                    alertChanges("updateTablePlayers" + Globals.currentTable.id);
                    NotInRoomButtonState();
                }
                ClearTablePlayers();
            }
            catch (Exception ex) {}
        }

        private void Bt_startGame_Click(object sender, EventArgs e)
        {
            if ( crud.GetPlayersInTable(Globals.currentTable.id).Count >= 2 )
            {
                alertChanges("startGame" + Globals.currentTable.id);
            }
            else
            {
                MessageBox.Show("Mínim 2 jugadors per començar una partida");
            }
        }

        private void StartGame()
        {
            v.Hide();
            new TableController(v);
        }

        private void Bt_connectToGame_Click(object sender, EventArgs e)
        {
            try
            {
                GameTable gt = (GameTable)v.dgv_openGames.CurrentRow.DataBoundItem;

                if ( crud.GetPlayersInTable(gt.id).Count < gt.maxPlayers )
                {
                    if (CheckIfNotNullOrEmpty(v.tb_gamePwd.Text))
                    {
                        if (gt.pwd.Equals(v.tb_gamePwd.Text))
                        {
                            UpdateGlobalTable(gt.name);
                            UpdateGlobalPlayerStats(false);
                            crud.InsertPlayerTable(Globals.gameStats);
                            v.tb_gamePwd.Text = "";
                            alertChanges("updateTablePlayers" + Globals.currentTable.id);

                            InRoomButtonState();
                        }
                        else
                        {
                            MessageBox.Show("Contrasenya incorrecta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Escriu la contrasenya de la sala");
                    }
                }
                else
                {
                    MessageBox.Show("La partida esta plena");
                }
            }
            catch (Exception es) {}
        }

        private void Bt_createNewGame_Click(object sender, EventArgs e)
        {
            GameTable gt = new GameTable();

            if ( CheckIfNotNullOrEmpty(v.tb_newGameName.Text) && CheckIfNotNullOrEmpty(v.tb_newGamePwd.Text) )
            {
                gt.name = v.tb_newGameName.Text.Trim();

                if ( crud.GetGameTableByName(gt.name) == null )
                {
                    gt.pwd = v.tb_newGamePwd.Text.Trim();
                    gt.maxPlayers = 8;

                    if (gt != null) { crud.InsertGameTable(gt); }
                    else MessageBox.Show("Error de dades");

                    UpdateGlobalTable(gt.name);
                    /*CREATE PLAYER TABLE*/
                    UpdateGlobalPlayerStats(true);
                    crud.InsertPlayerTable(Globals.gameStats);

                    v.tb_newGameName.Text = "";
                    v.tb_newGamePwd.Text = "";

                    alert2Changes("updateTablePlayers" + Globals.currentTable.id, "updateTables");

                    HostButtonState();
                }
                else
                {
                    MessageBox.Show("Ja existeix una sala amb aquest nom.");
                }
            }
            else
            {
                MessageBox.Show("Has d'introduir nom i contrasenya per la sala.");
            }            
        }

        private void InsertMoneyRequest_BT_Click(object sender, EventArgs e)
        {
            MoneyRequest mr = new MoneyRequest();
            mr.playerName = Globals.activeUser.usrName;
            mr.accepted = false;
            mr.pending = true;
            mr.amount = (int)v.moneyRequestAmount.Value;
            if (mr != null) { crud.InsertMoneyRequest(mr); }
            else MessageBox.Show("Error de dades");
            alertChanges("updateRequests");
        }

        private void GetPlayerRequests()
        {
            requests = crud.GetMoneyRequestByName(Globals.activeUser.usrName);
            v.moneyRequests_DGV.DataSource = requests;
        }

        private void MoneyRequests_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (v.moneyRequests_CB.SelectedIndex)
            {
                case 0:
                    v.moneyRequests_DGV.DataSource = requests;
                    break;
                case 1:
                    v.moneyRequests_DGV.DataSource = requests.Where(x => x.pending == true).ToList();
                    break;
                case 2:
                    v.moneyRequests_DGV.DataSource = requests.Where(x => x.pending == false && x.accepted == true).ToList();
                    break;
                case 3:
                    v.moneyRequests_DGV.DataSource = requests.Where(x => x.pending == false && x.accepted == false).ToList();
                    break;
                default:
                    v.moneyRequests_DGV.DataSource = requests;
                    break;
            }

        }

        private void Bt_usrUpd_Click(object sender, EventArgs e)
        {
            try
            {
                String name = "";
                String pwd = "";
                try
                {
                    name = v.tb_usrName.Text.Trim();
                    pwd = v.tb_usrPwd.Text.Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Has d'introduïr un nom i contrasenya valids");
                    Console.WriteLine("Error al agafar el nom dusuari o la contrasenya en usrUpd a ControllerLogin" + ex.Message);
                }

                if (CheckIfNotNullOrEmpty(name) && CheckIfNotNullOrEmpty(pwd))
                {
                    Player p = new Player();
                    p.usrName = name;
                    p.currentMoney = Globals.activeUser.currentMoney;
                    p.pwd = pwd;

                    int card = getCardBackChoice(v.cb_usrCardBack.SelectedItem.ToString());
                    int game = getGameBgChoice(v.cb_usrGameBg.SelectedItem.ToString());

                    p.cardBack = card;
                    p.gameBg = game;

                    crud.UpdatePlayer(p);
                    alertChanges("updatePlayers");

                    MessageBox.Show("Usuari actualitzat amb èxit");
                }
                else
                {
                    MessageBox.Show("No s'ha pogut crear l'usuari");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
            }
        }

        private bool CheckIfNotNullOrEmpty(string input)
        {
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            return false;
        }

        private int getCardBackChoice(String name)
        {
            switch (name)
            {
                case "Carta 1":
                    return 0;
                case "Carta 2":
                    return 1;
                case "Carta 3":
                    return 2;
                default:
                    return -1;
            }
        }

        private int getGameBgChoice(String name)
        {
            switch (name)
            {
                case "Fons 1":
                    return 0;
                case "Fons 2":
                    return 1;
                case "Fons 3":
                    return 2;
                default:
                    return -1;
            }
        }

        private void SetUpComboBox()
        {
            v.ranking_dgv.Columns["pwd"].Visible = false;
            v.ranking_dgv.Columns["cardBack"].Visible = false;
            v.ranking_dgv.Columns["gameBg"].Visible = false;

            v.dgv_openGames.Columns["id"].Visible = false;
            v.dgv_openGames.Columns["pwd"].Visible = false;

            v.moneyRequests_CB.Items.Add("Totes");
            v.moneyRequests_CB.Items.Add("Pendents");
            v.moneyRequests_CB.Items.Add("Acceptades");
            v.moneyRequests_CB.Items.Add("Denegades");

            v.moneyRequests_CB.SelectedItem = "Totes";
            v.moneyRequestAmount.Maximum = Decimal.MaxValue;
            v.moneyRequests_DGV.Columns["id"].Visible = false;
        }

        private void LoadListValues()
        {
            List<String> cardBackList = new List<String>();
            cardBackList.Add("Carta 1");
            cardBackList.Add("Carta 2");
            cardBackList.Add("Carta 3");
            v.cb_usrCardBack.DataSource = cardBackList;

            List<String> gameBgList = new List<String>();
            gameBgList.Add("Fons 1");
            gameBgList.Add("Fons 2");
            gameBgList.Add("Fons 3");
            v.cb_usrGameBg.DataSource = gameBgList;
        }

        private void LoadPlayerValues()
        {
            UpdateGlobalPlayer();

            v.tb_usrName.Text = Globals.activeUser.usrName;
            v.tb_usrPwd.Text = Globals.activeUser.pwd;
            v.tb_usrMoney.Text = Globals.activeUser.currentMoney.ToString();
            v.cb_usrCardBack.SelectedIndex = Globals.activeUser.cardBack;
            v.cb_usrGameBg.SelectedIndex = Globals.activeUser.gameBg;
        }

        private void UpdateGlobalPlayer()
        {
            Player player = crud.GetPlayerByName(Globals.activeUser.usrName);
            Globals.activeUser = player;
        }

        private void UpdateGlobalTable(string name)
        {
            GameTable table = crud.GetGameTableByName(name);
            Globals.currentTable = table;
        }

        private void ResetRankingDGV()
        {
            v.ranking_dgv.DataSource = crud.GetPlayerRanking();
        }

        private void LoadTableValues()
        {
            v.dgv_openGames.DataSource = crud.GetGameTables();
        }

        private void UpdateGlobalPlayerStats(bool active)
        {
            PlayerTable stats = new PlayerTable();

            stats.tableId = Globals.currentTable.id;
            stats.totalBet = 0;
            stats.playerName = Globals.activeUser.usrName;
            stats.isActivePlayer = active;
            stats.isBigBlind = false;
            stats.isSmallBlind = false;
            stats.hasFolded = false;

            Globals.gameStats = stats;
        }

        private void LoadTablePlayers()
        {
            try
            {
                v.DGV_TablePlayers.DataSource = crud.GetPlayersInTable(Globals.gameStats.tableId);

                v.DGV_TablePlayers.Columns["tableId"].Visible = false;
                v.DGV_TablePlayers.Columns["totalBet"].Visible = false;
                v.DGV_TablePlayers.Columns["isBigBlind"].Visible = false;
                v.DGV_TablePlayers.Columns["isSmallBlind"].Visible = false;
                v.DGV_TablePlayers.Columns["hasFolded"].Visible = false;
            }
            catch (Exception ex) {}

        }

        private void SetPlayerCardBack()
        {
            switch (v.cb_usrCardBack.Text)
            {
                case "Carta 1":
                    v.usr_card_PB.Image = new Bitmap(Globals.resourceDirectory + "Red_back.jpg");
                    break;
                case "Carta 2":
                    v.usr_card_PB.Image = new Bitmap(Globals.resourceDirectory + "Yellow_back.jpg");
                    break;
                case "Carta 3":
                    v.usr_card_PB.Image = new Bitmap(Globals.resourceDirectory + "blue_back.jpg");
                    break;
                default:
                    v.usr_card_PB.Image = new Bitmap(Globals.resourceDirectory + "ERROR.jpg");
                    break;
            }
        }

        private void SetPlayerBackGround()
        {
            switch (v.cb_usrGameBg.Text)
            {
                case "Fons 1":
                    v.usr_bg_PB.Image = new Bitmap(Globals.resourceDirectory + "windows.png");
                    break;
                case "Fons 2":
                    v.usr_bg_PB.Image = new Bitmap(Globals.resourceDirectory + "beach.png");
                    break;
                case "Fons 3":
                    v.usr_bg_PB.Image = new Bitmap(Globals.resourceDirectory + "snow.png");
                    break;
                default:
                    v.usr_bg_PB.Image = new Bitmap(Globals.resourceDirectory + "ERROR.jpg");
                    break;
            }
        }

        private void ClearTablePlayers()
        {
            Globals.gameStats = new PlayerTable();
        }

        private void HostButtonState()
        {
            v.bt_createNewGame.Enabled = false;
            v.bt_connectToGame.Enabled = false;
            v.bt_startGame.Enabled = true;
            v.bt_exitGame.Enabled = true;
        }

        private void InRoomButtonState()
        {
            v.bt_createNewGame.Enabled = false;
            v.bt_connectToGame.Enabled = false;
            v.bt_startGame.Enabled = false;
            v.bt_exitGame.Enabled = true;
        }

        private void NotInRoomButtonState()
        {
            v.bt_createNewGame.Enabled = true;
            v.bt_connectToGame.Enabled = true;
            v.bt_startGame.Enabled = false;
            v.bt_exitGame.Enabled = false;
        }

    }
}
