using Model;
using View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.WebSockets;

namespace Controller
{
    class LoginController
    {
        CRUD crud;
        LoginView v;

        CancellationTokenSource cts = new CancellationTokenSource();
        ClientWebSocket socket = new ClientWebSocket();

        public LoginController()
        {
            
            crud = new CRUD();
            v = new LoginView();
            Start();
        }

        private void Start()
        {
            loadLoginListeners();
            Application.Run(v);
        }

        private void loadLoginListeners()
        {
            v.bt_loginUser.Click += Bt_loginUser_Click;
        }

        private void Bt_loginUser_Click(object sender, EventArgs e)
        {
            /* NEW USER registered*/
            if ( crud.GetPlayerByName(v.tb_loginUsrName.Text) == null && v.register_CXB.Checked )
            {
                Player p = ConstructDataPlayer();
                if (p != null) { crud.InsertPlayer(p); }
                else MessageBox.Show("Error de dades");
                CheckUser();
                ProceedToGame();
            }
            /* NEW USER has not registered yet */
            else if ( crud.GetPlayerByName(v.tb_loginUsrName.Text) == null && !v.register_CXB.Checked )
            {
                MessageBox.Show("Registra't amb aquest usuari");
            }
            /* EXISTING USER registering again */
            else if (crud.GetPlayerByName(v.tb_loginUsrName.Text) != null && v.register_CXB.Checked)
            {
                MessageBox.Show("Aquest usuari ja existeix");
            }
            /* EXISTING USER login again */
            else if (crud.GetPlayerByName(v.tb_loginUsrName.Text) != null && !v.register_CXB.Checked)
            {
                CheckUser();
                ProceedToGame();
            }
        }

        private void ProceedToGame()
        {
            v.Hide();
            new MenuController();
        }

        private Player ConstructDataPlayer()
        {
            Player p = new Player();

            if (CheckIfNotNullOrEmpty(v.tb_loginUsrName.Text)) { p.usrName = v.tb_loginUsrName.Text.Trim(); }
            else new Player();
            if (CheckIfNotNullOrEmpty(v.tb_loginUsrPwd.Text)) { p.pwd = v.tb_loginUsrPwd.Text.Trim(); }
            else new Player();

            p.currentMoney = 1000;
            p.cardBack = 0;
            p.gameBg = 0;

            return p;
        }

        private bool CheckIfNotNullOrEmpty(string input)
        {
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            return false;
        }

        private bool CheckUser()
        {
            try
            {
                String name = v.tb_loginUsrName.Text;
                String pwd = v.tb_loginUsrPwd.Text;

                List<Player> allPlayers = crud.GetAllPlayers();

                foreach (Player p in allPlayers)
                {
                    if (p.usrName.Equals(name))
                    {
                        if (p.pwd.Equals(pwd))
                        {
                            Globals.activeUser = p;
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CheckUser a ControllerLogin: " + ex.Message);
                return false;
            }
        }

    }
}
