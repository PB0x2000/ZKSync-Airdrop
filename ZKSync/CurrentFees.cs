using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Leaf.xNet;

namespace ZKSync
{
    public class CurrentFees
    {
        public static bool CheckBridgeFees(double maxfees)
        {
            HttpRequest requestOBJ = new HttpRequest();
            float gas_limit = 149210;
            float eth_usd = float.Parse(Regex.Match(requestOBJ.Get("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=USD").ToString(), @"USD"":(.+?)}").Groups[1].Value, CultureInfo.GetCultureInfo("en-US"));
            int gwei = Int32.Parse(Regex.Match(requestOBJ.Get("https://api.etherscan.io/api?module=gastracker&action=gasoracle&apikey=ZU2C3Q43Z76STUSZSWI6GJT78D1T2XFTQX").ToString(), @"ProposeGasPrice"":""(.+?)""").Groups[1].Value);
            float fee = ((gas_limit / 1000000000 * gwei)) * eth_usd;

            if (fee > maxfees) return false;
            return true;
        }

        public static bool CheckZKSyncFees(double gasLimit, double maxfees)
        {
            HttpRequest requestOBJ = new HttpRequest();
            float eth_usd = float.Parse(Regex.Match(requestOBJ.Get("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=USD").ToString(), @"USD"":(.+?)}").Groups[1].Value, CultureInfo.GetCultureInfo("en-US"));
            string result = requestOBJ.Post("https://mainnet.era.zksync.io", @"{""jsonrpc"":""2.0"",""method"":""eth_gasPrice"",""params"":[],""id"":0}", "application/json").ToString();
            double decValue = Convert.ToInt32(Regex.Match(result, @"result"":""(.+?)""").Groups[1].Value, 16);
            double fees = (((gasLimit * decValue ) / 1000000000) / 1000000000) * eth_usd;
            if (fees > maxfees) return false;
            return true;
        }

        public static double USDtoETH(double usd)
        {
            HttpRequest requestOBJ = new HttpRequest();
            float eth_usd = float.Parse(Regex.Match(requestOBJ.Get("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=USD").ToString(), @"USD"":(.+?)}").Groups[1].Value, CultureInfo.GetCultureInfo("en-US"));
            float dollar = float.Parse(usd.ToString());
            return double.Parse((dollar / eth_usd).ToString());
        }
    }
}