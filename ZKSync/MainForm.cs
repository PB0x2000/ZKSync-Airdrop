using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZKSync
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            addWalletsTab1.Hide();
            settingsTab1.Hide();
            viewDataTab1.Show();
            viewDataTab1.LoadViewData();
        }

        private void AddWalletsButton_Click(object sender, EventArgs e)
        {
            settingsTab1.Hide();
            viewDataTab1.Hide();
            addWalletsTab1.Show();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            addWalletsTab1.Hide();
            viewDataTab1.Hide();
            settingsTab1.Hide();
        }
        
    }
}