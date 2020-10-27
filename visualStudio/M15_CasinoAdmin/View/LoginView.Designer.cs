namespace View
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_bt = new System.Windows.Forms.Button();
            this.login_usr = new System.Windows.Forms.TextBox();
            this.login_pwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuari:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // login_bt
            // 
            this.login_bt.Location = new System.Drawing.Point(114, 103);
            this.login_bt.Name = "login_bt";
            this.login_bt.Size = new System.Drawing.Size(75, 23);
            this.login_bt.TabIndex = 2;
            this.login_bt.Text = "Login";
            this.login_bt.UseVisualStyleBackColor = true;
            // 
            // login_usr
            // 
            this.login_usr.Location = new System.Drawing.Point(94, 32);
            this.login_usr.Name = "login_usr";
            this.login_usr.ReadOnly = true;
            this.login_usr.Size = new System.Drawing.Size(117, 20);
            this.login_usr.TabIndex = 3;
            this.login_usr.Text = "Admin";
            // 
            // login_pwd
            // 
            this.login_pwd.Location = new System.Drawing.Point(94, 64);
            this.login_pwd.MaxLength = 20;
            this.login_pwd.Name = "login_pwd";
            this.login_pwd.Size = new System.Drawing.Size(117, 20);
            this.login_pwd.TabIndex = 4;
            this.login_pwd.UseSystemPasswordChar = true;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 152);
            this.Controls.Add(this.login_pwd);
            this.Controls.Add(this.login_usr);
            this.Controls.Add(this.login_bt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.Text = "Administrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button login_bt;
        public System.Windows.Forms.TextBox login_usr;
        public System.Windows.Forms.TextBox login_pwd;
    }
}

