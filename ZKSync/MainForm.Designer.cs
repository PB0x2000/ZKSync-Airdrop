namespace ZKSync
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddWalletsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.viewDataTab1 = new ZKSync.ViewDataTab();
            this.addWalletsTab1 = new ZKSync.AddWalletsTab();
            this.settingsTab1 = new ZKSync.SettingsTab();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.AddWalletsButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SettingsButton);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Location = new System.Drawing.Point(352, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 152);
            this.panel1.TabIndex = 0;
            // 
            // AddWalletsButton
            // 
            this.AddWalletsButton.BackColor = System.Drawing.Color.White;
            this.AddWalletsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddWalletsButton.BackgroundImage")));
            this.AddWalletsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddWalletsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddWalletsButton.ForeColor = System.Drawing.Color.White;
            this.AddWalletsButton.Location = new System.Drawing.Point(309, 76);
            this.AddWalletsButton.Name = "AddWalletsButton";
            this.AddWalletsButton.Size = new System.Drawing.Size(171, 37);
            this.AddWalletsButton.TabIndex = 4;
            this.AddWalletsButton.Text = "   Add Wallets";
            this.AddWalletsButton.UseVisualStyleBackColor = false;
            this.AddWalletsButton.Click += new System.EventHandler(this.AddWalletsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "ZKSync Bot";
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.White;
            this.SettingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsButton.BackgroundImage")));
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Location = new System.Drawing.Point(531, 76);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(171, 37);
            this.SettingsButton.TabIndex = 1;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.White;
            this.StartButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartButton.BackgroundImage")));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(80, 76);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(171, 37);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // viewDataTab1
            // 
            this.viewDataTab1.BackColor = System.Drawing.SystemColors.Highlight;
            this.viewDataTab1.Location = new System.Drawing.Point(2, 146);
            this.viewDataTab1.Name = "viewDataTab1";
            this.viewDataTab1.Size = new System.Drawing.Size(1477, 548);
            this.viewDataTab1.TabIndex = 3;
            // 
            // addWalletsTab1
            // 
            this.addWalletsTab1.BackColor = System.Drawing.SystemColors.Highlight;
            this.addWalletsTab1.Location = new System.Drawing.Point(2, 146);
            this.addWalletsTab1.Name = "addWalletsTab1";
            this.addWalletsTab1.Size = new System.Drawing.Size(1214, 548);
            this.addWalletsTab1.TabIndex = 2;
            // 
            // settingsTab1
            // 
            this.settingsTab1.BackColor = System.Drawing.SystemColors.Highlight;
            this.settingsTab1.Location = new System.Drawing.Point(2, 146);
            this.settingsTab1.Name = "settingsTab1";
            this.settingsTab1.Size = new System.Drawing.Size(1214, 548);
            this.settingsTab1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1484, 711);
            this.Controls.Add(this.viewDataTab1);
            this.Controls.Add(this.addWalletsTab1);
            this.Controls.Add(this.settingsTab1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZKSync Bot";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button AddWalletsButton;
        private SettingsTab settingsTab1;
        private AddWalletsTab addWalletsTab1;
        private ViewDataTab viewDataTab1;
    }
}