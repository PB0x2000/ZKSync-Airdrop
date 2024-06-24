using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ZKSync
{
    public partial class ViewDataTab : UserControl
    {
        public ViewDataTab()
        {
            InitializeComponent();
        }

        private void ViewDataTab_Load(object sender, EventArgs e)
        {
            LoadViewData();
        }

        public void LoadViewData()
        {
            if (File.Exists(JsonHelper.jsonPath))
            {
                JsonHelper.ReadJson();
                LoadDataInTable();
            }
            else
            {
                //disable Start button 
                button3.Enabled = false;
                //disable stop button
                button4.Enabled = false;
            }
        }

        //Daten von profile Liste in dataview laden
        private void LoadDataInTable()
        {
            // Dieser Code könnte in einem anderen Thread laufen
            Invoke((MethodInvoker)delegate {
                // Ihr Code, der auf dataGridView1 zugreift, kommt hier hin
                dataGridView1.Rows.Clear();
                int dataViewRowCounter = 0;
                foreach (Profile profile in JsonHelper.profiles)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = profile.ID;
                    row.Cells[1].Value = profile.Email;
                    row.Cells[2].Value = profile.Password;
                    row.Cells[3].Value = profile.Wallet;
                    row.Cells[4].Value = profile.Phrase;
                    row.Cells[5].Value = profile.WalletPass;
                    row.Cells[6].Value = profile.Proxy;
                    row.Cells[7].Value = profile.Balance.ToString("F2");
                    row.Cells[8].Value = profile.ZKSyncInit;
                    row.Cells[9].Value = profile.SyncSwapInit.Done;
                    row.Cells[10].Value = profile.SpaceSwapInit.Done;
                    row.Cells[11].Value = profile.MintsquareInit;
                    row.Cells[12].Value = profile.OrbiterInit;
                    row.Cells[13].Value = profile.PinataInit;
                    row.Cells[14].Value = profile.ZigZagInit.Done;
                    row.Cells[15].Value = profile.SyncSwap;
                    row.Cells[16].Value = profile.SpaceSwap;
                    row.Cells[17].Value = profile.CurrentState;
                    dataGridView1.Rows.Add(row);
                    dataViewRowCounter++;
                }
            });
        }

        private int[] GetCheckedProfiles()
        {
            List<int> checkedProfiles = new List<int>();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null) break;
                try
                {
                    if ((bool) row.Cells[18].Value) checkedProfiles.Add(row.Index);
                }
                catch{}
            }
            return checkedProfiles.ToArray();
        }

        //Check balance button einfügen
        private void CheckBalance()
        {
            int[] profilesToProcess = GetCheckedProfiles();
            if (profilesToProcess.Length == 0)
            {
                ShowNoCheckedMessage();
                return;
            }
            foreach (int ID in profilesToProcess)
            {
                Profile profile = JsonHelper.profiles[ID];
                if (!profile.ZKSyncInit)
                {
                    profile.Balance = BalanceCheck.CheckERC20Balance(profile.Wallet);
                    if (profile.Balance < MaxFees.OverallMaxFees && !profile.ZKSyncInit) profile.CurrentState = "Not enough balance to start. At least " + MaxFees.OverallMaxFees + "$";
                    JsonHelper.profiles[ID] = profile;
                    JsonHelper.WriteJson();
                    LoadDataInTable();
                }
            }
            MessageBox.Show("Balance updated for all checked elements", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Timer hinzufügen für LoadDataInTable?
        //Check balance <x throw error in StartProcess
        //Msg: Nicht genug balance
        //Msg: No profiles checked, check profiles for action
        //Tutorial bar
        //Startprocess über timer laufen lassen

        bool isStopped;
        private void StartProcess()
        {
            //Get all selected profiles
            int[] profilesToProcess = GetCheckedProfiles();
            if (profilesToProcess.Length == 0)
            {
                ShowNoCheckedMessage();
                return;
            }

            //Check all selected profiles before bridging if enough balance
            if (!CheckEnoughBalance(profilesToProcess)) return;



            //Test
            foreach (int ID in profilesToProcess)
            {
                Profile profile = JsonHelper.profiles[ID];
                //ZKSync init
                SyncSwap.LiquidityProvide(profile);
            }
            Thread.Sleep(1000000);


            //Solange nicht gestoppt ist
            while (!isStopped)
            {
                foreach (int ID in profilesToProcess)
                {
                    Profile profile = JsonHelper.profiles[ID];

                    //Wenn fees vorher zu hoch waren oder noch gar nicht probiert
                    if (MaxFees.TryAgainFeesHopefullyLow(profile.InitTryAgain) || profile.InitTryAgain == 0)
                    {
                        if (!profile.ZKSyncInit && !isStopped)
                        {
                            //ZKSync init
                            if (!BridgeZKSyncIO.Start(profile)) continue;
                            //Nach jedem step:
                            profile.ZKSyncInit = true;
                            JsonHelper.profiles[ID] = profile;
                            JsonHelper.WriteJson();
                            LoadDataInTable();
                        }
                        if (!profile.SyncSwapInit.Done && !isStopped)
                        {
                            //Syncswap init
                        }
                        if(!profile.SpaceSwapInit.Done && !isStopped)
                        {
                            //SpaceSwap init
                        }
                        if (!profile.MintsquareInit && !isStopped)
                        {
                            //Mitsquare init
                        }
                        if (!profile.OrbiterInit && !isStopped)
                        {
                            //Orbiter init
                        }
                        if (!profile.PinataInit && !isStopped)
                        {
                            //Pinata init
                        }
                        if (!profile.ZigZagInit.Done && !isStopped)
                        {
                            //ZigZag init
                            if (!ZigZag.Init(profile)) continue;
                            profile.ZigZagInit.Done = true;
                            JsonHelper.profiles[ID] = profile;
                            JsonHelper.WriteJson();
                            LoadDataInTable();
                        }
                    }
                    //neuer if befehl mit anderem timestamp
                    if (CheckSyncSwapTrade(profile))
                    {
                        //SyncSwap traden
                    }
                    if (CheckSpaceSwapTrade(profile))
                    {
                        //SpaceSwap traden
                    }
                }
                Thread.Sleep(120000);
            }
            

        }

        private bool CheckSyncSwapTrade(Profile profile)
        {
            //Checken ob syncswap trade überfällig
            if (profile.SyncSwap == null) return false;//immer ausführen wenn nixe
            return false;
        }

        private bool CheckSpaceSwapTrade(Profile profile)
        {
            //Checken ob spaceswap trade überfällig
            if (profile.SpaceSwap == null) return false;//immer ausführen wenn nixe
            return false;
        }

        //Start/Play button
        private void button3_Click(object sender, EventArgs e)
        {
            Thread startProcess = new Thread(StartProcess);
            startProcess.Start();
            isStopped = false;
        }

        private void checkAllBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkAllBox.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null) break;
                    row.Cells[18].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null) break;
                    row.Cells[18].Value = false;
                }
            }
        }

        private void startProcessTimer_Tick(object sender, EventArgs e)
        {
            
        }

        //Stop button
        private void button4_Click(object sender, EventArgs e)
        {
            isStopped = true;
        }

        //Check balance button
        private void button1_Click(object sender, EventArgs e)
        {
            CheckBalance();
        }

        private static void ShowNoCheckedMessage()
        {
            MessageBox.Show("No elements are checked!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static bool CheckEnoughBalance(int[] profilesToProcess)
        {
            foreach (int ID in profilesToProcess)
            {
                Profile profile = JsonHelper.profiles[ID];
                if (profile.Balance < MaxFees.OverallMaxFees && !profile.ZKSyncInit)
                {
                    MessageBox.Show("One or more profile has not enough balance to start. Load more balance and recheck.", "Low Balance Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
    }
}
