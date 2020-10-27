using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Controller
{
    public class LoginController
    {
        CRUD m;
        LoginView v;

        public LoginController()
        {
            m = new CRUD();
            v = new LoginView();
            start();
        }

        private void start()
        {
            InitListeners();
            Application.Run(v);
        }

        private void InitListeners()
        {
            v.login_bt.Click += Login_bt_Click;
        }

        private void Login_bt_Click(object sender, EventArgs e)
        {
            if ( !string.IsNullOrEmpty(v.login_usr.Text) && !string.IsNullOrWhiteSpace(v.login_usr.Text) &&
                !string.IsNullOrEmpty(v.login_pwd.Text) && !string.IsNullOrWhiteSpace(v.login_pwd.Text) )
            {
                Player admin = m.GetPlayerByName(v.login_usr.Text);

                if ( admin != null && v.login_pwd.Text.Equals(admin.pwd) )
                {
                    v.Hide();
                    new AdminController();
                }
                else
                {
                    MessageBox.Show("Contrasenya incorrecta");
                }
            }
            else
            {
                MessageBox.Show("Contrasenya incorrecta");
            }
        }
    }
}
