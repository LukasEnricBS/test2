namespace View
{
    partial class MenuView
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bt_exitGame = new System.Windows.Forms.Button();
            this.bt_startGame = new System.Windows.Forms.Button();
            this.DGV_TablePlayers = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.bt_createNewGame = new System.Windows.Forms.Button();
            this.tb_newGamePwd = new System.Windows.Forms.TextBox();
            this.tb_newGameName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.bt_connectToGame = new System.Windows.Forms.Button();
            this.dgv_openGames = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_gamePwd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ranking_dgv = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cb_usrCardBack = new System.Windows.Forms.ComboBox();
            this.cb_usrGameBg = new System.Windows.Forms.ComboBox();
            this.bt_usrUpd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_usrMoney = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_usrPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_usrName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.insertMoneyRequest_BT = new System.Windows.Forms.Button();
            this.moneyRequestAmount = new System.Windows.Forms.NumericUpDown();
            this.moneyRequests_CB = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.moneyRequests_DGV = new System.Windows.Forms.DataGridView();
            this.usr_card_PB = new System.Windows.Forms.PictureBox();
            this.usr_bg_PB = new System.Windows.Forms.PictureBox();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TablePlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_openGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ranking_dgv)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyRequestAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyRequests_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_card_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_bg_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bt_exitGame);
            this.tabPage2.Controls.Add(this.bt_startGame);
            this.tabPage2.Controls.Add(this.DGV_TablePlayers);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.bt_createNewGame);
            this.tabPage2.Controls.Add(this.tb_newGamePwd);
            this.tabPage2.Controls.Add(this.tb_newGameName);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.bt_connectToGame);
            this.tabPage2.Controls.Add(this.dgv_openGames);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tb_gamePwd);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.ranking_dgv);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(801, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Taules de Joc";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bt_exitGame
            // 
            this.bt_exitGame.Enabled = false;
            this.bt_exitGame.Location = new System.Drawing.Point(744, 110);
            this.bt_exitGame.Name = "bt_exitGame";
            this.bt_exitGame.Size = new System.Drawing.Size(43, 23);
            this.bt_exitGame.TabIndex = 29;
            this.bt_exitGame.Text = "Sortir";
            this.bt_exitGame.UseVisualStyleBackColor = true;
            // 
            // bt_startGame
            // 
            this.bt_startGame.Enabled = false;
            this.bt_startGame.Location = new System.Drawing.Point(623, 381);
            this.bt_startGame.Name = "bt_startGame";
            this.bt_startGame.Size = new System.Drawing.Size(75, 23);
            this.bt_startGame.TabIndex = 28;
            this.bt_startGame.Text = "Començar";
            this.bt_startGame.UseVisualStyleBackColor = true;
            // 
            // DGV_TablePlayers
            // 
            this.DGV_TablePlayers.AllowUserToAddRows = false;
            this.DGV_TablePlayers.AllowUserToDeleteRows = false;
            this.DGV_TablePlayers.AllowUserToResizeColumns = false;
            this.DGV_TablePlayers.AllowUserToResizeRows = false;
            this.DGV_TablePlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_TablePlayers.Location = new System.Drawing.Point(531, 136);
            this.DGV_TablePlayers.MultiSelect = false;
            this.DGV_TablePlayers.Name = "DGV_TablePlayers";
            this.DGV_TablePlayers.ReadOnly = true;
            this.DGV_TablePlayers.RowHeadersVisible = false;
            this.DGV_TablePlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_TablePlayers.Size = new System.Drawing.Size(256, 233);
            this.DGV_TablePlayers.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(528, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Jugadors de la Sala:";
            // 
            // bt_createNewGame
            // 
            this.bt_createNewGame.Location = new System.Drawing.Point(388, 359);
            this.bt_createNewGame.Margin = new System.Windows.Forms.Padding(2);
            this.bt_createNewGame.Name = "bt_createNewGame";
            this.bt_createNewGame.Size = new System.Drawing.Size(75, 57);
            this.bt_createNewGame.TabIndex = 25;
            this.bt_createNewGame.Text = "Crear partida";
            this.bt_createNewGame.UseVisualStyleBackColor = true;
            // 
            // tb_newGamePwd
            // 
            this.tb_newGamePwd.Location = new System.Drawing.Point(214, 396);
            this.tb_newGamePwd.Margin = new System.Windows.Forms.Padding(2);
            this.tb_newGamePwd.Name = "tb_newGamePwd";
            this.tb_newGamePwd.PasswordChar = '*';
            this.tb_newGamePwd.Size = new System.Drawing.Size(170, 20);
            this.tb_newGamePwd.TabIndex = 21;
            // 
            // tb_newGameName
            // 
            this.tb_newGameName.Location = new System.Drawing.Point(214, 359);
            this.tb_newGameName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_newGameName.Name = "tb_newGameName";
            this.tb_newGameName.Size = new System.Drawing.Size(170, 20);
            this.tb_newGameName.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(211, 381);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Contrasenya";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(211, 344);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Nom de la sala";
            // 
            // bt_connectToGame
            // 
            this.bt_connectToGame.Location = new System.Drawing.Point(676, 35);
            this.bt_connectToGame.Margin = new System.Windows.Forms.Padding(2);
            this.bt_connectToGame.Name = "bt_connectToGame";
            this.bt_connectToGame.Size = new System.Drawing.Size(69, 19);
            this.bt_connectToGame.TabIndex = 20;
            this.bt_connectToGame.Text = "Connectar";
            this.bt_connectToGame.UseVisualStyleBackColor = true;
            // 
            // dgv_openGames
            // 
            this.dgv_openGames.AllowUserToAddRows = false;
            this.dgv_openGames.AllowUserToDeleteRows = false;
            this.dgv_openGames.AllowUserToResizeColumns = false;
            this.dgv_openGames.AllowUserToResizeRows = false;
            this.dgv_openGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_openGames.Location = new System.Drawing.Point(214, 34);
            this.dgv_openGames.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_openGames.MultiSelect = false;
            this.dgv_openGames.Name = "dgv_openGames";
            this.dgv_openGames.ReadOnly = true;
            this.dgv_openGames.RowHeadersVisible = false;
            this.dgv_openGames.RowHeadersWidth = 51;
            this.dgv_openGames.RowTemplate.Height = 24;
            this.dgv_openGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_openGames.Size = new System.Drawing.Size(203, 308);
            this.dgv_openGames.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Partides actuals";
            // 
            // tb_gamePwd
            // 
            this.tb_gamePwd.Location = new System.Drawing.Point(518, 34);
            this.tb_gamePwd.Margin = new System.Windows.Forms.Padding(2);
            this.tb_gamePwd.Name = "tb_gamePwd";
            this.tb_gamePwd.PasswordChar = '*';
            this.tb_gamePwd.Size = new System.Drawing.Size(154, 20);
            this.tb_gamePwd.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(445, 37);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Contrasenya:";
            // 
            // ranking_dgv
            // 
            this.ranking_dgv.AllowUserToAddRows = false;
            this.ranking_dgv.AllowUserToDeleteRows = false;
            this.ranking_dgv.AllowUserToResizeColumns = false;
            this.ranking_dgv.AllowUserToResizeRows = false;
            this.ranking_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ranking_dgv.Location = new System.Drawing.Point(6, 34);
            this.ranking_dgv.MultiSelect = false;
            this.ranking_dgv.Name = "ranking_dgv";
            this.ranking_dgv.ReadOnly = true;
            this.ranking_dgv.RowHeadersVisible = false;
            this.ranking_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ranking_dgv.Size = new System.Drawing.Size(203, 382);
            this.ranking_dgv.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Ranking Global de Jugadors";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.usr_bg_PB);
            this.tabPage1.Controls.Add(this.usr_card_PB);
            this.tabPage1.Controls.Add(this.cb_usrCardBack);
            this.tabPage1.Controls.Add(this.cb_usrGameBg);
            this.tabPage1.Controls.Add(this.bt_usrUpd);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tb_usrMoney);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tb_usrPwd);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tb_usrName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(801, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuració";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cb_usrCardBack
            // 
            this.cb_usrCardBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_usrCardBack.FormattingEnabled = true;
            this.cb_usrCardBack.Location = new System.Drawing.Point(86, 115);
            this.cb_usrCardBack.Margin = new System.Windows.Forms.Padding(2);
            this.cb_usrCardBack.Name = "cb_usrCardBack";
            this.cb_usrCardBack.Size = new System.Drawing.Size(92, 21);
            this.cb_usrCardBack.TabIndex = 25;
            // 
            // cb_usrGameBg
            // 
            this.cb_usrGameBg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_usrGameBg.FormattingEnabled = true;
            this.cb_usrGameBg.Location = new System.Drawing.Point(695, 30);
            this.cb_usrGameBg.Margin = new System.Windows.Forms.Padding(2);
            this.cb_usrGameBg.Name = "cb_usrGameBg";
            this.cb_usrGameBg.Size = new System.Drawing.Size(92, 21);
            this.cb_usrGameBg.TabIndex = 24;
            // 
            // bt_usrUpd
            // 
            this.bt_usrUpd.Location = new System.Drawing.Point(483, 382);
            this.bt_usrUpd.Margin = new System.Windows.Forms.Padding(2);
            this.bt_usrUpd.Name = "bt_usrUpd";
            this.bt_usrUpd.Size = new System.Drawing.Size(151, 37);
            this.bt_usrUpd.TabIndex = 23;
            this.bt_usrUpd.Text = "Actualitza";
            this.bt_usrUpd.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fons de carta:";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fons de sala:";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // tb_usrMoney
            // 
            this.tb_usrMoney.Location = new System.Drawing.Point(171, 31);
            this.tb_usrMoney.Margin = new System.Windows.Forms.Padding(2);
            this.tb_usrMoney.Name = "tb_usrMoney";
            this.tb_usrMoney.ReadOnly = true;
            this.tb_usrMoney.Size = new System.Drawing.Size(153, 20);
            this.tb_usrMoney.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Diners disponibles:";
            // 
            // tb_usrPwd
            // 
            this.tb_usrPwd.Location = new System.Drawing.Point(86, 74);
            this.tb_usrPwd.Margin = new System.Windows.Forms.Padding(2);
            this.tb_usrPwd.Name = "tb_usrPwd";
            this.tb_usrPwd.Size = new System.Drawing.Size(238, 20);
            this.tb_usrPwd.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Contrasenya:";
            // 
            // tb_usrName
            // 
            this.tb_usrName.Location = new System.Drawing.Point(10, 31);
            this.tb_usrName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_usrName.Name = "tb_usrName";
            this.tb_usrName.ReadOnly = true;
            this.tb_usrName.Size = new System.Drawing.Size(153, 20);
            this.tb_usrName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nom d\'usuari:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 457);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.insertMoneyRequest_BT);
            this.tabPage3.Controls.Add(this.moneyRequestAmount);
            this.tabPage3.Controls.Add(this.moneyRequests_CB);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.moneyRequests_DGV);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(801, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sol·licituds de moneda";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nova sol·licitud";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Filtrar per:";
            // 
            // insertMoneyRequest_BT
            // 
            this.insertMoneyRequest_BT.Location = new System.Drawing.Point(179, 144);
            this.insertMoneyRequest_BT.Name = "insertMoneyRequest_BT";
            this.insertMoneyRequest_BT.Size = new System.Drawing.Size(75, 23);
            this.insertMoneyRequest_BT.TabIndex = 13;
            this.insertMoneyRequest_BT.Text = "Sol·licitar";
            this.insertMoneyRequest_BT.UseVisualStyleBackColor = true;
            // 
            // moneyRequestAmount
            // 
            this.moneyRequestAmount.Location = new System.Drawing.Point(134, 118);
            this.moneyRequestAmount.Name = "moneyRequestAmount";
            this.moneyRequestAmount.Size = new System.Drawing.Size(120, 20);
            this.moneyRequestAmount.TabIndex = 12;
            this.moneyRequestAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // moneyRequests_CB
            // 
            this.moneyRequests_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moneyRequests_CB.FormattingEnabled = true;
            this.moneyRequests_CB.Location = new System.Drawing.Point(666, 54);
            this.moneyRequests_CB.Name = "moneyRequests_CB";
            this.moneyRequests_CB.Size = new System.Drawing.Size(121, 21);
            this.moneyRequests_CB.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Sol·licituds";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Quantitat:";
            // 
            // moneyRequests_DGV
            // 
            this.moneyRequests_DGV.AllowUserToAddRows = false;
            this.moneyRequests_DGV.AllowUserToDeleteRows = false;
            this.moneyRequests_DGV.AllowUserToResizeColumns = false;
            this.moneyRequests_DGV.AllowUserToResizeRows = false;
            this.moneyRequests_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moneyRequests_DGV.Location = new System.Drawing.Point(294, 81);
            this.moneyRequests_DGV.MultiSelect = false;
            this.moneyRequests_DGV.Name = "moneyRequests_DGV";
            this.moneyRequests_DGV.ReadOnly = true;
            this.moneyRequests_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.moneyRequests_DGV.Size = new System.Drawing.Size(493, 337);
            this.moneyRequests_DGV.TabIndex = 8;
            // 
            // usr_card_PB
            // 
            this.usr_card_PB.Location = new System.Drawing.Point(83, 141);
            this.usr_card_PB.Name = "usr_card_PB";
            this.usr_card_PB.Size = new System.Drawing.Size(180, 262);
            this.usr_card_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.usr_card_PB.TabIndex = 26;
            this.usr_card_PB.TabStop = false;
            // 
            // usr_bg_PB
            // 
            this.usr_bg_PB.Location = new System.Drawing.Point(337, 56);
            this.usr_bg_PB.Name = "usr_bg_PB";
            this.usr_bg_PB.Size = new System.Drawing.Size(450, 305);
            this.usr_bg_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.usr_bg_PB.TabIndex = 27;
            this.usr_bg_PB.TabStop = false;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuView";
            this.Text = "Menu";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TablePlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_openGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ranking_dgv)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyRequestAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyRequests_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_card_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usr_bg_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.ComboBox cb_usrCardBack;
        public System.Windows.Forms.ComboBox cb_usrGameBg;
        public System.Windows.Forms.Button bt_usrUpd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_usrMoney;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tb_usrPwd;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tb_usrName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button insertMoneyRequest_BT;
        public System.Windows.Forms.NumericUpDown moneyRequestAmount;
        public System.Windows.Forms.ComboBox moneyRequests_CB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DataGridView moneyRequests_DGV;
        public System.Windows.Forms.DataGridView ranking_dgv;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button bt_connectToGame;
        public System.Windows.Forms.DataGridView dgv_openGames;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox tb_gamePwd;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Button bt_createNewGame;
        public System.Windows.Forms.TextBox tb_newGamePwd;
        public System.Windows.Forms.TextBox tb_newGameName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Button bt_exitGame;
        public System.Windows.Forms.Button bt_startGame;
        public System.Windows.Forms.DataGridView DGV_TablePlayers;
        public System.Windows.Forms.PictureBox usr_card_PB;
        public System.Windows.Forms.PictureBox usr_bg_PB;
    }
}