using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using System.Net.WebSockets;
using System.Threading;

namespace Controller
{
    class AdminController
    {
        CRUD m;
        AdminView v;

        CancellationTokenSource cts = new CancellationTokenSource();
        ClientWebSocket socket = new ClientWebSocket();

        public AdminController()
        {
            m = new CRUD();
            v = new AdminView();
            start();
        }

        private async void start()
        {
            await InitWebSocket();
            InitListeners();
            LoadInfo();
            MaskInfo();
            v.Show();
        }

        public async Task InitWebSocket()
        {
            /*local url*/
            //string wsUri = string.Format("wss://localhost:44344/api/websocket");
            /*online url*/
            string wsUri = string.Format("wss://m15-casino-ws.conveyor.cloud//api/websocket");
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
                            v.Invoke((MethodInvoker) delegate ()
                            {
                                ResetRankingDGV();
                                ResetPlayerDGV();
                            });
                        }
                        else if(rcvMsg.StartsWith("updateRequests"))
                        {
                            //run on ui thread
                            v.Invoke((MethodInvoker)delegate ()
                            {
                                ResetRankingDGV();
                                ResetPlayerDGV();
                                UpdateAllRequestDGV();
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

        private void InitListeners()
        {
            v.FormClosed += V_FormClosed;
            v.player_search_BT.Click += Player_search_BT_Click;
            v.player_search_TB.TextChanged += Player_search_TB_TextChanged;
            v.players_dgv.SelectionChanged += Players_dgv_SelectionChanged;
            v.insert_player_BT.Click += Insert_player_BT_Click;
            v.update_player_BT.Click += Update_player_BT_Click;
            v.delete_player_BT.Click += Delete_player_BT_Click;
            v.pendingRequests_DGV.SelectionChanged += PendingRequests_DGV_SelectionChanged;
            v.accept_request_BT.Click += Accept_request_BT_Click;
            v.decline_request_BT.Click += Decline_request_BT_Click;
        }

        private void Decline_request_BT_Click(object sender, EventArgs e)
        {
            MoneyRequest p = (MoneyRequest)v.pendingRequests_DGV.CurrentRow.DataBoundItem;
            p.pending = false;
            p.accepted = false;
            m.UpdateRequest(p);
            alertChanges("updateRequests");
        }

        private void Accept_request_BT_Click(object sender, EventArgs e)
        {
            MoneyRequest p = (MoneyRequest)v.pendingRequests_DGV.CurrentRow.DataBoundItem;
            p.pending = false;
            p.accepted = true;
            m.UpdateRequest(p);
            alertChanges("updateRequests");
        }

        private void PendingRequests_DGV_SelectionChanged(object sender, EventArgs e)
        {
            MoneyRequest p = (MoneyRequest)v.pendingRequests_DGV.CurrentRow.DataBoundItem;

            if (p != null)
            {
                v.request_name_TB.Text = p.playerName;
                v.request_money_TB.Text = p.amount.ToString();
            }
        }

        private void Delete_player_BT_Click(object sender, EventArgs e)
        {
            Player p = (Player)v.players_dgv.CurrentRow.DataBoundItem;
            if (p != null) { m.DeletePlayer(p.usrName); }
            else MessageBox.Show("Error al esborrar");
            alertChanges("updatePlayers");
        }

        private void Update_player_BT_Click(object sender, EventArgs e)
        {
            Player p = ConstructDataPlayer();
            if (p != null) { m.UpdatePlayer(p); }
            else MessageBox.Show("Error de dades");
            alertChanges("updatePlayers");
        }

        private void Insert_player_BT_Click(object sender, EventArgs e)
        {
            Player p = ConstructDataPlayer();
            if (p != null) { m.InsertPlayer(p); }
            else MessageBox.Show("Error de dades");
            alertChanges("updatePlayers");
        }

        private Player ConstructDataPlayer()
        {
            Player p = new Player();

            if ( CheckIfNotNullOrEmpty(v.player_name_TB.Text) ) { p.usrName = v.player_name_TB.Text; }
            else new Player();
            if ( CheckIfNotNullOrEmpty(v.player_pwd_TB.Text) ) { p.pwd = v.player_pwd_TB.Text; }
            else new Player();

            p.currentMoney = (int) v.player_money.Value;
            p.cardBack = (int) v.player_cards.Value;
            p.gameBg = (int) v.player_table.Value;

            return p;
        }

        private void Players_dgv_SelectionChanged(object sender, EventArgs e)
        {
            Player p = (Player)v.players_dgv.CurrentRow.DataBoundItem;

            if (p != null)
            {
                v.player_name_TB.Text = p.usrName;
                v.player_pwd_TB.Text = p.pwd;
                v.player_money.Value = p.currentMoney;
                v.player_cards.Value = p.cardBack;
                v.player_table.Value = p.gameBg;
            }
        }

        private void Player_search_BT_Click(object sender, EventArgs e)
        {
            ResetPlayerDGV();
        }

        private void Player_search_TB_TextChanged(object sender, EventArgs e)
        {
            if ( CheckIfNotNullOrEmpty(v.player_search_TB.Text) )
            {
                v.players_dgv.DataSource = m.GetAllPlayers().Where( x => x.usrName.Contains(v.player_search_TB.Text) ||
                x.usrName.ToLower().Contains(v.player_search_TB.Text) ).ToList();
            }
            else
            {
                ResetPlayerDGV();
            }
        }

        private bool CheckIfNotNullOrEmpty( string input)
        {
            if ( !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input) )
            {
                return true;
            }
            return false; 
        }

        private void V_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadInfo()
        {
            ResetRankingDGV();
            ResetPlayerDGV();
            UpdateAllRequestDGV();
            v.player_money.Maximum = Decimal.MaxValue;
        }

        private void UpdateAllRequestDGV()
        {
            v.request_name_TB.Text = "";
            v.request_money_TB.Text = "";

            ResetAllRequestsDGV();
            ResetAllPendingRequestsDGV();
            ResetAllAcceptedRequestsDGV();
            ResetAllDeclinedRequestsDGV();
        }

        private void ResetRankingDGV()
        {
            v.ranking_dgv.DataSource = m.GetPlayerRanking();
        }

        private void ResetPlayerDGV()
        {
            v.players_dgv.DataSource = m.GetAllPlayers();
        }

        private void ResetAllRequestsDGV()
        {
            v.allRequests_DGV.DataSource = m.GetAllMoneyRequests();
        }

        private void ResetAllPendingRequestsDGV()
        {
            v.pendingRequests_DGV.DataSource = m.GetPendingMoneyRequests();
        }

        private void ResetAllAcceptedRequestsDGV()
        {
            v.accepted_requests_DGV.DataSource = m.GetAcceptedMoneyRequests();
        }

        private void ResetAllDeclinedRequestsDGV()
        {
            v.declined_requests_DGV.DataSource = m.GetDeniedMoneyRequests();
        }

        private void MaskInfo()
        {
            v.ranking_dgv.Columns["pwd"].Visible = false;
            v.ranking_dgv.Columns["cardBack"].Visible = false;
            v.ranking_dgv.Columns["gameBg"].Visible = false;

            v.allRequests_DGV.Columns["id"].Visible = false;

            v.pendingRequests_DGV.Columns["id"].Visible = false;
            v.pendingRequests_DGV.Columns["accepted"].Visible = false;

            v.accepted_requests_DGV.Columns["id"].Visible = false;
            v.accepted_requests_DGV.Columns["pending"].Visible = false;

            v.declined_requests_DGV.Columns["id"].Visible = false;
            v.declined_requests_DGV.Columns["pending"].Visible = false;
        }

    }
}
