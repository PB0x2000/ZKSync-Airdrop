namespace ZKSync
{
    partial class ViewDataTab
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDataTab));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkAllBox = new System.Windows.Forms.CheckBox();
            this.startProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.ID_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wallet_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phrase_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.walletPass_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxy_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zksync_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syncswap_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spaceswapInit_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mintsquare_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orbiter_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pinata_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zigzag_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syncswaptrades_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spaceswaptrades_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkAction = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_data,
            this.email_data,
            this.pass_data,
            this.wallet_data,
            this.phrase_data,
            this.walletPass_data,
            this.proxy_data,
            this.balance_data,
            this.zksync_data,
            this.syncswap_data,
            this.spaceswapInit_data,
            this.mintsquare_data,
            this.orbiter_data,
            this.pinata_data,
            this.zigzag_data,
            this.syncswaptrades_data,
            this.spaceswaptrades_data,
            this.state_data,
            this.checkAction});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(3, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1481, 466);
            this.dataGridView1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(20, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 33);
            this.button3.TabIndex = 6;
            this.button3.Text = "Play";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Highlight;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(186, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 33);
            this.button4.TabIndex = 7;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkAllBox
            // 
            this.checkAllBox.AutoSize = true;
            this.checkAllBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAllBox.ForeColor = System.Drawing.Color.White;
            this.checkAllBox.Location = new System.Drawing.Point(1375, 45);
            this.checkAllBox.Name = "checkAllBox";
            this.checkAllBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkAllBox.Size = new System.Drawing.Size(106, 28);
            this.checkAllBox.TabIndex = 8;
            this.checkAllBox.Text = "Check all";
            this.checkAllBox.UseVisualStyleBackColor = true;
            this.checkAllBox.CheckStateChanged += new System.EventHandler(this.checkAllBox_CheckStateChanged);
            // 
            // startProcessTimer
            // 
            this.startProcessTimer.Interval = 120000;
            this.startProcessTimer.Tick += new System.EventHandler(this.startProcessTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(356, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "    Check Balance";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID_data
            // 
            this.ID_data.HeaderText = "ID";
            this.ID_data.Name = "ID_data";
            this.ID_data.ReadOnly = true;
            this.ID_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID_data.Width = 20;
            // 
            // email_data
            // 
            this.email_data.HeaderText = "Email";
            this.email_data.Name = "email_data";
            this.email_data.ReadOnly = true;
            this.email_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.email_data.Width = 110;
            // 
            // pass_data
            // 
            this.pass_data.HeaderText = "Password";
            this.pass_data.Name = "pass_data";
            this.pass_data.ReadOnly = true;
            this.pass_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pass_data.Width = 95;
            // 
            // wallet_data
            // 
            this.wallet_data.HeaderText = "Wallet";
            this.wallet_data.Name = "wallet_data";
            this.wallet_data.ReadOnly = true;
            this.wallet_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.wallet_data.Width = 115;
            // 
            // phrase_data
            // 
            this.phrase_data.HeaderText = "Phrase";
            this.phrase_data.Name = "phrase_data";
            this.phrase_data.ReadOnly = true;
            this.phrase_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.phrase_data.Width = 105;
            // 
            // walletPass_data
            // 
            this.walletPass_data.HeaderText = "Wallet Pass";
            this.walletPass_data.Name = "walletPass_data";
            this.walletPass_data.ReadOnly = true;
            this.walletPass_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.walletPass_data.Width = 82;
            // 
            // proxy_data
            // 
            this.proxy_data.HeaderText = "Proxy";
            this.proxy_data.Name = "proxy_data";
            this.proxy_data.ReadOnly = true;
            this.proxy_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // balance_data
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.balance_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.balance_data.HeaderText = "Balance";
            this.balance_data.Name = "balance_data";
            this.balance_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.balance_data.Width = 60;
            // 
            // zksync_data
            // 
            this.zksync_data.HeaderText = "ZKSync";
            this.zksync_data.Name = "zksync_data";
            this.zksync_data.ReadOnly = true;
            this.zksync_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.zksync_data.Width = 50;
            // 
            // syncswap_data
            // 
            this.syncswap_data.HeaderText = "SyncSwap";
            this.syncswap_data.Name = "syncswap_data";
            this.syncswap_data.ReadOnly = true;
            this.syncswap_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.syncswap_data.Width = 63;
            // 
            // spaceswapInit_data
            // 
            this.spaceswapInit_data.HeaderText = "SpaceSwap";
            this.spaceswapInit_data.Name = "spaceswapInit_data";
            this.spaceswapInit_data.ReadOnly = true;
            this.spaceswapInit_data.Width = 69;
            // 
            // mintsquare_data
            // 
            this.mintsquare_data.HeaderText = "Mintsquare";
            this.mintsquare_data.Name = "mintsquare_data";
            this.mintsquare_data.ReadOnly = true;
            this.mintsquare_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mintsquare_data.Width = 63;
            // 
            // orbiter_data
            // 
            this.orbiter_data.HeaderText = "Orbiter";
            this.orbiter_data.Name = "orbiter_data";
            this.orbiter_data.ReadOnly = true;
            this.orbiter_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.orbiter_data.Width = 46;
            // 
            // pinata_data
            // 
            this.pinata_data.HeaderText = "Pinata";
            this.pinata_data.Name = "pinata_data";
            this.pinata_data.ReadOnly = true;
            this.pinata_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pinata_data.Width = 46;
            // 
            // zigzag_data
            // 
            this.zigzag_data.HeaderText = "ZigZag";
            this.zigzag_data.Name = "zigzag_data";
            this.zigzag_data.ReadOnly = true;
            this.zigzag_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.zigzag_data.Width = 48;
            // 
            // syncswaptrades_data
            // 
            this.syncswaptrades_data.HeaderText = "SyncSwap trades";
            this.syncswaptrades_data.Name = "syncswaptrades_data";
            this.syncswaptrades_data.ReadOnly = true;
            this.syncswaptrades_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.syncswaptrades_data.Width = 73;
            // 
            // spaceswaptrades_data
            // 
            this.spaceswaptrades_data.HeaderText = "SpaceSwap trades";
            this.spaceswaptrades_data.Name = "spaceswaptrades_data";
            this.spaceswaptrades_data.ReadOnly = true;
            this.spaceswaptrades_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.spaceswaptrades_data.Width = 78;
            // 
            // state_data
            // 
            this.state_data.HeaderText = "State";
            this.state_data.Name = "state_data";
            this.state_data.ReadOnly = true;
            this.state_data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.state_data.Width = 165;
            // 
            // checkAction
            // 
            this.checkAction.HeaderText = "Check";
            this.checkAction.Name = "checkAction";
            this.checkAction.Width = 50;
            // 
            // ViewDataTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkAllBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewDataTab";
            this.Size = new System.Drawing.Size(1487, 548);
            this.Load += new System.EventHandler(this.ViewDataTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkAllBox;
        private System.Windows.Forms.Timer startProcessTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn wallet_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn phrase_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn walletPass_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn proxy_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn zksync_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncswap_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn spaceswapInit_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn mintsquare_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn orbiter_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn pinata_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn zigzag_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncswaptrades_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn spaceswaptrades_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn state_data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkAction;
    }
}
