using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using Newtonsoft.Json;

namespace ZKSync
{
    internal class BalanceCheck
    {
        public class ETH
        {
            public Price price { get; set; }
            public double balance { get; set; }
            public string rawBalance { get; set; }
        }

        public class Price
        {
            public double rate { get; set; }
            public double diff { get; set; }
            public double diff7d { get; set; }
            public int ts { get; set; }
            public double marketCapUsd { get; set; }
            public double availableSupply { get; set; }
            public double volume24h { get; set; }
            public double volDiff1 { get; set; }
            public double volDiff7 { get; set; }
            public double volDiff30 { get; set; }
            public double diff30d { get; set; }
        }

        public class ERC20Balance
        {
            public string address { get; set; }
            public ETH ETH { get; set; }
            public int countTxs { get; set; }
            public List<Token> tokens { get; set; }
        }

        public class Token
        {
            public TokenInfo tokenInfo { get; set; }
            public double balance { get; set; }
            public int totalIn { get; set; }
            public int totalOut { get; set; }
            public string rawBalance { get; set; }
        }

        public class TokenInfo
        {
            public string address { get; set; }
            public string decimals { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public string totalSupply { get; set; }
            public int issuancesCount { get; set; }
            public int lastUpdated { get; set; }
            public object price { get; set; }
            public int holdersCount { get; set; }
            public string website { get; set; }
            public string image { get; set; }
            public int ethTransfersCount { get; set; }
        }

        //Balance Check ERC20
        public static double CheckERC20Balance(string addy)
        {
            HttpRequest requestOBJ = new HttpRequest();
            ERC20Balance balance = JsonConvert.DeserializeObject<ERC20Balance>(requestOBJ.Get("https://api.ethplorer.io/getAddressInfo/" + addy + "?apiKey=freekey").ToString());
            double rebalance = balance.ETH.balance * balance.ETH.price.rate;
            return rebalance;
            //Console.WriteLine("Balance: {0:0.00}$", CheckERC20Balance("0x7b0654e5500352b150ca1829c7b2eb9b7d9e7df9"));
        }
    }
}
