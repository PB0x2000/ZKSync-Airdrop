using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKSync
{
    public class Profile
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Wallet { get; set; }
        public string ExtensionID { get; set; }
        public string Phrase { get; set; }
        public string WalletPass { get; set; }
        public string Proxy { get; set; }
        public double Balance { get; set; }
        public bool ZKSyncInit { get; set; }
        public InitSwap SyncSwapInit { get; set; }
        public InitSwap SpaceSwapInit { get;set; }
        public bool MintsquareInit { get; set; }
        public bool OrbiterInit { get; set; }
        public bool PinataInit { get; set; }
        public InitSwap ZigZagInit { get; set; }
        public long InitTryAgain { get; set; }
        public Swap SyncSwap { get; set; }
        public Swap SpaceSwap { get; set; }
        public string CurrentState { get; set; }
    }

    public class Swap
    {
        public int Count { get; set; }
        public string Date { get; set; }
    }

    public class InitSwap
    {
        public bool Done { get; set; }
        public int SwapCount { get; set; }
    }
}
