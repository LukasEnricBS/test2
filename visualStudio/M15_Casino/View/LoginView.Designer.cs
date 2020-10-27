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
            this.tb_loginUsrName = new System.Windows.Forms.TextBox();
            this.bt_loginUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_loginUsrPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.register_CXB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tb_loginUsrName
            // 
            this.tb_loginUsrName.Location = new System.Drawing.Point(9, 24);
            this.tb_loginUsrName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_loginUsrName.Name = "tb_loginUsrName";
            this.tb_loginUsrName.Size = new System.Drawing.Size(76, 20);
            this.tb_loginUsrName.TabIndex = 0;
            // 
            // bt_loginUser
            // 
            this.bt_loginUser.Location = new System.Drawing.Point(18, 57);
            this.bt_loginUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_loginUser.Name = "bt_loginUser";
            this.bt_loginUser.Size = new System.Drawing.Size(56, 19);
            this.bt_loginUser.TabIndex = 1;
            this.bt_loginUser.Text = "Entrar";
            this.bt_loginUser.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nom d\'usuari";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contrasenya";
            // 
            // tb_loginUsrPwd
            // 
            this.tb_loginUsrPwd.Location = new System.Drawing.Point(110, 24);
            this.tb_loginUsrPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_loginUsrPwd.Name = "tb_loginUsrPwd";
            this.tb_loginUsrPwd.PasswordChar = '*';
            this.tb_loginUsrPwd.Size = new System.Drawing.Size(76, 20);
            this.tb_loginUsrPwd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "No tens usuari?";
            // 
            // register_CXB
            // 
            this.register_CXB.AutoSize = true;
            this.register_CXB.Location = new System.Drawing.Point(110, 110);
            this.register_CXB.Name = "register_CXB";
            this.register_CXB.Size = new System.Drawing.Size(75, 17);
            this.register_CXB.TabIndex = 7;
            this.register_CXB.Text = "Registra\'m";
            this.register_CXB.UseVisualStyleBackColor = true;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 139);
            this.Controls.Add(this.register_CXB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_loginUsrPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_loginUser);
            this.Controls.Add(this.tb_loginUsrName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.Text = "User Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_loginUsrName;
        public System.Windows.Forms.Button bt_loginUser;
        public System.Windows.Forms.TextBox tb_loginUsrPwd;
        public System.Windows.Forms.CheckBox register_CXB;
    }
}

