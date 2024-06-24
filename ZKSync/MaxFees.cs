using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKSync
{
    internal class MaxFees
    {
        // Vars zum anpassen
        public static double OverallMaxFees = 100.00;
        public static double BridgingFees = 8.00;

        public static double ZKSyncFees = 8.00;
        public static double SyncSwapInitFees = 0.50;

        public static double ZigZagFees = 0.30;

       
        public static int MinsForNextFeesTry = 30;

        public static long FeesTryAgainTimeStamp()
        {
            return new DateTimeOffset(DateTime.UtcNow).AddMinutes(MinsForNextFeesTry).ToUnixTimeSeconds();
        }

        public static bool TryAgainFeesHopefullyLow(long input)
        {
            long currentUnix = new DateTimeOffset(DateTime.UtcNow).AddMinutes(30).ToUnixTimeSeconds();
            if (currentUnix >= input) return true;
            return false;
        }
    }
}
