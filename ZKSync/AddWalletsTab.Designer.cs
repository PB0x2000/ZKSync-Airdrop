namespace ZKSync
{
    partial class AddWalletsTab
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
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWalletsTab));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.email_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxy_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.email_data,
            this.pass_data,
            this.proxy_data});
            this.dataGridView1.Location = new System.Drawing.Point(391, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(673, 476);
            this.dataGridView1.TabIndex = 6;
            // 
            // email_data
            // 
            this.email_data.HeaderText = "Email";
            this.email_data.Name = "email_data";
            this.email_data.Width = 250;
            // 
            // pass_data
            // 
            this.pass_data.HeaderText = "Password";
            this.pass_data.Name = "pass_data";
            this.pass_data.Width = 200;
            // 
            // proxy_data
            // 
            this.proxy_data.HeaderText = "Proxy";
            this.proxy_data.Name = "proxy_data";
            this.proxy_data.Width = 180;
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.CreateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreateButton.BackgroundImage")));
            this.CreateButton.FlatAppearance.BorderSize = 0;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.ForeColor = System.Drawing.Color.Black;
            this.CreateButton.Location = new System.Drawing.Point(1079, 495);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(146, 33);
            this.CreateButton.TabIndex = 7;
            this.CreateButton.Text = " Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // AddWalletsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AddWalletsTab";
            this.Size = new System.Drawing.Size(1487, 548);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn proxy_data;
    }
}
