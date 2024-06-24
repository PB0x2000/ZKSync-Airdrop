using System;
using System.Windows.Forms;
using System.IO;

namespace ZKSync
{
    public partial class AddWalletsTab : UserControl
    {
        public AddWalletsTab()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            //Add additionail wallets
            bool addAdditionalWallets = false;
            if (JsonHelper.profiles.Count != 0) addAdditionalWallets = true;
           
            //Read input data table
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Cells[0].Value == null) break;
                Profile profile = new Profile();
                //Wenn wallets existieren zaehle profile ID weiter nach list count
                if (addAdditionalWallets) profile.ID = JsonHelper.profiles.Count + row.Index;
                else profile.ID = row.Index;
                profile.Email = row.Cells[0].Value.ToString();
                profile.Password = row.Cells[1].Value.ToString();
                profile.Proxy = row.Cells[2].Value.ToString();
                //Add to main json list
                JsonHelper.profiles.Add(profile);
                
            }
            //Write to json zwischenspeichern
            JsonHelper.WriteJson();

            //for each input mail create wallet
            for (int i = 0; i < JsonHelper.profiles.Count; i++)
            {
                Profile profile = JsonHelper.profiles[i];
                if (profile.Phrase != null) continue;   //Wenn metamask bereits erstellt try next bis die additional wallets erreicht sind
                var metamaskInit = Metamask.Init(profile.ID, profile.Proxy);
                profile.WalletPass = metamaskInit.walletPass;
                profile.Phrase = metamaskInit.phrase;
                profile.Wallet = metamaskInit.walletID;
                profile.ExtensionID = metamaskInit.extensionID;
                profile.Balance = 0.00;
                profile.ZKSyncInit = false;
                profile.SyncSwapInit = new InitSwap();
                profile.SyncSwapInit.Done = false;
                profile.SyncSwapInit.SwapCount = 0;
                profile.SpaceSwapInit = new InitSwap();
                profile.SpaceSwapInit.Done = false;
                profile.SpaceSwapInit.SwapCount = 0;
                profile.MintsquareInit = false;
                profile.OrbiterInit = false;
                profile.PinataInit = false;
                profile.ZigZagInit = new InitSwap();
                profile.ZigZagInit.Done = false;
                profile.ZigZagInit.SwapCount = 0;
                profile.CurrentState = "Wallet created, waiting for balance";
                JsonHelper.profiles[i] = profile;
                JsonHelper.WriteJson();
                //Write json in profile folder chrome safety
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\Chrome\" + profile.ID + @"\WalletPhraseBackup.txt", profile.Wallet);
            }
        }
    }
}
