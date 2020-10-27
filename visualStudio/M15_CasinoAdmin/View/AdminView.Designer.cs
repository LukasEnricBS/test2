namespace View
{
    partial class AdminView
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.player_search_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.players_dgv = new System.Windows.Forms.DataGridView();
            this.ranking_dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.player_search_BT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.player_cards = new System.Windows.Forms.NumericUpDown();
            this.player_table = new System.Windows.Forms.NumericUpDown();
            this.player_money = new System.Windows.Forms.NumericUpDown();
            this.player_name_TB = new System.Windows.Forms.TextBox();
            this.player_pwd_TB = new System.Windows.Forms.TextBox();
            this.insert_player_BT = new System.Windows.Forms.Button();
            this.delete_player_BT = new System.Windows.Forms.Button();
            this.update_player_BT = new System.Windows.Forms.Button();
            this.allRequests_DGV = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pendingRequests_DGV = new System.Windows.Forms.DataGridView();
            this.request_money_TB = new System.Windows.Forms.TextBox();
            this.request_name_TB = new System.Windows.Forms.TextBox();
            this.accept_request_BT = new System.Windows.Forms.Button();
            this.decline_request_BT = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.declined_requests_DGV = new System.Windows.Forms.DataGridView();
            this.accepted_requests_DGV = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.players_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ranking_dgv)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_cards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_money)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allRequests_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingRequests_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.declined_requests_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accepted_requests_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, -3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 528);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.update_player_BT);
            this.tabPage1.Controls.Add(this.delete_player_BT);
            this.tabPage1.Controls.Add(this.insert_player_BT);
            this.tabPage1.Controls.Add(this.player_pwd_TB);
            this.tabPage1.Controls.Add(this.player_name_TB);
            this.tabPage1.Controls.Add(this.player_money);
            this.tabPage1.Controls.Add(this.player_table);
            this.tabPage1.Controls.Add(this.player_cards);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.player_search_BT);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.player_search_TB);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.players_dgv);
            this.tabPage1.Controls.Add(this.ranking_dgv);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1020, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Jugadors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cerca per nom:";
            // 
            // player_search_TB
            // 
            this.player_search_TB.Location = new System.Drawing.Point(702, 8);
            this.player_search_TB.Name = "player_search_TB";
            this.player_search_TB.Size = new System.Drawing.Size(226, 20);
            this.player_search_TB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Llista de Jugadors";
            // 
            // players_dgv
            // 
            this.players_dgv.AllowUserToAddRows = false;
            this.players_dgv.AllowUserToDeleteRows = false;
            this.players_dgv.AllowUserToResizeColumns = false;
            this.players_dgv.AllowUserToResizeRows = false;
            this.players_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.players_dgv.Location = new System.Drawing.Point(260, 32);
            this.players_dgv.MultiSelect = false;
            this.players_dgv.Name = "players_dgv";
            this.players_dgv.ReadOnly = true;
            this.players_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.players_dgv.Size = new System.Drawing.Size(749, 337);
            this.players_dgv.TabIndex = 2;
            // 
            // ranking_dgv
            // 
            this.ranking_dgv.AllowUserToAddRows = false;
            this.ranking_dgv.AllowUserToDeleteRows = false;
            this.ranking_dgv.AllowUserToResizeColumns = false;
            this.ranking_dgv.AllowUserToResizeRows = false;
            this.ranking_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ranking_dgv.Location = new System.Drawing.Point(9, 32);
            this.ranking_dgv.MultiSelect = false;
            this.ranking_dgv.Name = "ranking_dgv";
            this.ranking_dgv.ReadOnly = true;
            this.ranking_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ranking_dgv.Size = new System.Drawing.Size(245, 461);
            this.ranking_dgv.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ranking de Jugadors";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.accepted_requests_DGV);
            this.tabPage2.Controls.Add(this.declined_requests_DGV);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.decline_request_BT);
            this.tabPage2.Controls.Add(this.accept_request_BT);
            this.tabPage2.Controls.Add(this.request_name_TB);
            this.tabPage2.Controls.Add(this.request_money_TB);
            this.tabPage2.Controls.Add(this.pendingRequests_DGV);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.allRequests_DGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1020, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sol·licituds";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // player_search_BT
            // 
            this.player_search_BT.Location = new System.Drawing.Point(934, 6);
            this.player_search_BT.Name = "player_search_BT";
            this.player_search_BT.Size = new System.Drawing.Size(75, 23);
            this.player_search_BT.TabIndex = 7;
            this.player_search_BT.Text = "Tots";
            this.player_search_BT.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nom:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contrasenya:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 465);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Diners:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(549, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fons de Taula:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(549, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Estil de cartes:";
            // 
            // player_cards
            // 
            this.player_cards.Location = new System.Drawing.Point(631, 389);
            this.player_cards.Name = "player_cards";
            this.player_cards.Size = new System.Drawing.Size(40, 20);
            this.player_cards.TabIndex = 13;
            // 
            // player_table
            // 
            this.player_table.Location = new System.Drawing.Point(631, 429);
            this.player_table.Name = "player_table";
            this.player_table.Size = new System.Drawing.Size(40, 20);
            this.player_table.TabIndex = 14;
            // 
            // player_money
            // 
            this.player_money.Location = new System.Drawing.Point(366, 463);
            this.player_money.Name = "player_money";
            this.player_money.Size = new System.Drawing.Size(156, 20);
            this.player_money.TabIndex = 15;
            // 
            // player_name_TB
            // 
            this.player_name_TB.Location = new System.Drawing.Point(366, 389);
            this.player_name_TB.Name = "player_name_TB";
            this.player_name_TB.Size = new System.Drawing.Size(156, 20);
            this.player_name_TB.TabIndex = 16;
            // 
            // player_pwd_TB
            // 
            this.player_pwd_TB.Location = new System.Drawing.Point(366, 428);
            this.player_pwd_TB.Name = "player_pwd_TB";
            this.player_pwd_TB.Size = new System.Drawing.Size(156, 20);
            this.player_pwd_TB.TabIndex = 17;
            // 
            // insert_player_BT
            // 
            this.insert_player_BT.Location = new System.Drawing.Point(702, 411);
            this.insert_player_BT.Name = "insert_player_BT";
            this.insert_player_BT.Size = new System.Drawing.Size(90, 52);
            this.insert_player_BT.TabIndex = 18;
            this.insert_player_BT.Text = "Afegir";
            this.insert_player_BT.UseVisualStyleBackColor = true;
            // 
            // delete_player_BT
            // 
            this.delete_player_BT.Location = new System.Drawing.Point(919, 411);
            this.delete_player_BT.Name = "delete_player_BT";
            this.delete_player_BT.Size = new System.Drawing.Size(90, 52);
            this.delete_player_BT.TabIndex = 19;
            this.delete_player_BT.Text = "Esborrar";
            this.delete_player_BT.UseVisualStyleBackColor = true;
            // 
            // update_player_BT
            // 
            this.update_player_BT.Location = new System.Drawing.Point(811, 411);
            this.update_player_BT.Name = "update_player_BT";
            this.update_player_BT.Size = new System.Drawing.Size(90, 52);
            this.update_player_BT.TabIndex = 20;
            this.update_player_BT.Text = "Modificar";
            this.update_player_BT.UseVisualStyleBackColor = true;
            // 
            // allRequests_DGV
            // 
            this.allRequests_DGV.AllowUserToAddRows = false;
            this.allRequests_DGV.AllowUserToDeleteRows = false;
            this.allRequests_DGV.AllowUserToResizeColumns = false;
            this.allRequests_DGV.AllowUserToResizeRows = false;
            this.allRequests_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allRequests_DGV.Location = new System.Drawing.Point(12, 31);
            this.allRequests_DGV.MultiSelect = false;
            this.allRequests_DGV.Name = "allRequests_DGV";
            this.allRequests_DGV.ReadOnly = true;
            this.allRequests_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allRequests_DGV.Size = new System.Drawing.Size(444, 462);
            this.allRequests_DGV.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(658, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Pendents";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(658, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Acceptades";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(658, 365);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Rebutjades";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Totes";
            // 
            // pendingRequests_DGV
            // 
            this.pendingRequests_DGV.AllowUserToAddRows = false;
            this.pendingRequests_DGV.AllowUserToDeleteRows = false;
            this.pendingRequests_DGV.AllowUserToResizeColumns = false;
            this.pendingRequests_DGV.AllowUserToResizeRows = false;
            this.pendingRequests_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pendingRequests_DGV.Location = new System.Drawing.Point(661, 31);
            this.pendingRequests_DGV.MultiSelect = false;
            this.pendingRequests_DGV.Name = "pendingRequests_DGV";
            this.pendingRequests_DGV.ReadOnly = true;
            this.pendingRequests_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pendingRequests_DGV.Size = new System.Drawing.Size(348, 197);
            this.pendingRequests_DGV.TabIndex = 5;
            // 
            // request_money_TB
            // 
            this.request_money_TB.Enabled = false;
            this.request_money_TB.Location = new System.Drawing.Point(531, 191);
            this.request_money_TB.Name = "request_money_TB";
            this.request_money_TB.Size = new System.Drawing.Size(110, 20);
            this.request_money_TB.TabIndex = 8;
            // 
            // request_name_TB
            // 
            this.request_name_TB.Enabled = false;
            this.request_name_TB.Location = new System.Drawing.Point(531, 161);
            this.request_name_TB.Name = "request_name_TB";
            this.request_name_TB.Size = new System.Drawing.Size(110, 20);
            this.request_name_TB.TabIndex = 9;
            // 
            // accept_request_BT
            // 
            this.accept_request_BT.Location = new System.Drawing.Point(475, 247);
            this.accept_request_BT.Name = "accept_request_BT";
            this.accept_request_BT.Size = new System.Drawing.Size(70, 60);
            this.accept_request_BT.TabIndex = 10;
            this.accept_request_BT.Text = "Acceptar";
            this.accept_request_BT.UseVisualStyleBackColor = true;
            // 
            // decline_request_BT
            // 
            this.decline_request_BT.Location = new System.Drawing.Point(572, 247);
            this.decline_request_BT.Name = "decline_request_BT";
            this.decline_request_BT.Size = new System.Drawing.Size(70, 60);
            this.decline_request_BT.TabIndex = 11;
            this.decline_request_BT.Text = "Rebutjar";
            this.decline_request_BT.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(472, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Nom:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(472, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Quantitat:";
            // 
            // declined_requests_DGV
            // 
            this.declined_requests_DGV.AllowUserToAddRows = false;
            this.declined_requests_DGV.AllowUserToDeleteRows = false;
            this.declined_requests_DGV.AllowUserToResizeColumns = false;
            this.declined_requests_DGV.AllowUserToResizeRows = false;
            this.declined_requests_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.declined_requests_DGV.Location = new System.Drawing.Point(661, 381);
            this.declined_requests_DGV.MultiSelect = false;
            this.declined_requests_DGV.Name = "declined_requests_DGV";
            this.declined_requests_DGV.ReadOnly = true;
            this.declined_requests_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.declined_requests_DGV.Size = new System.Drawing.Size(348, 112);
            this.declined_requests_DGV.TabIndex = 14;
            // 
            // accepted_requests_DGV
            // 
            this.accepted_requests_DGV.AllowUserToAddRows = false;
            this.accepted_requests_DGV.AllowUserToDeleteRows = false;
            this.accepted_requests_DGV.AllowUserToResizeColumns = false;
            this.accepted_requests_DGV.AllowUserToResizeRows = false;
            this.accepted_requests_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accepted_requests_DGV.Location = new System.Drawing.Point(661, 247);
            this.accepted_requests_DGV.MultiSelect = false;
            this.accepted_requests_DGV.Name = "accepted_requests_DGV";
            this.accepted_requests_DGV.ReadOnly = true;
            this.accepted_requests_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accepted_requests_DGV.Size = new System.Drawing.Size(348, 115);
            this.accepted_requests_DGV.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(491, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Sol·licitud pendent actual";
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 524);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminView";
            this.Text = "Administrador";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.players_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ranking_dgv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_cards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_money)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allRequests_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingRequests_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.declined_requests_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accepted_requests_DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView ranking_dgv;
        public System.Windows.Forms.DataGridView players_dgv;
        public System.Windows.Forms.TextBox player_search_TB;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button player_search_BT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button update_player_BT;
        public System.Windows.Forms.Button delete_player_BT;
        public System.Windows.Forms.Button insert_player_BT;
        public System.Windows.Forms.TextBox player_pwd_TB;
        public System.Windows.Forms.TextBox player_name_TB;
        public System.Windows.Forms.NumericUpDown player_money;
        public System.Windows.Forms.NumericUpDown player_table;
        public System.Windows.Forms.NumericUpDown player_cards;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.DataGridView pendingRequests_DGV;
        public System.Windows.Forms.DataGridView allRequests_DGV;
        public System.Windows.Forms.DataGridView accepted_requests_DGV;
        public System.Windows.Forms.DataGridView declined_requests_DGV;
        public System.Windows.Forms.Button decline_request_BT;
        public System.Windows.Forms.Button accept_request_BT;
        public System.Windows.Forms.TextBox request_name_TB;
        public System.Windows.Forms.TextBox request_money_TB;
    }
}