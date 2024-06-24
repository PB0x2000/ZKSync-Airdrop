using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace ZKSync
{
    internal class ProxyDetection
    {
        public class Proxy_Info
        {
            public string status { get; set; }
            public string country { get; set; }
            public string countryCode { get; set; }
            public string region { get; set; }
            public string regionName { get; set; }
            public string city { get; set; }
            public string zip { get; set; }
            public double lat { get; set; }
            public double lon { get; set; }
            public string timezone { get; set; }
            public string isp { get; set; }
            public string org { get; set; }
            public string @as { get; set; }
            public string query { get; set; }
        }
        public class Proxy_Checked
        {
            public string proxy { get; set; }
            public Proxy_Info proxy_info { get; set; }
        }

        //Get Proxy Info
        private static Proxy_Checked get_proxy_info(string proxy)
        {
            HttpRequest requestOBJ = new HttpRequest();
            requestOBJ.Proxy = HttpProxyClient.Parse(proxy);
            string realIP = Regex.Match(requestOBJ.Get("https://api.ipify.org?format=json").ToString(), @"ip"":""(.+?)""").Groups[1].Value;
            Proxy_Checked p_info = new Proxy_Checked();
            p_info.proxy = proxy;
            p_info.proxy_info = JsonConvert.DeserializeObject<Proxy_Info>(requestOBJ.Get("http://ip-api.com/json/" + realIP).ToString());
            return p_info;
        }  
        
        //Set Geo-Location in Chrome
        public static void set_geoLocation(ChromeDriver driver, string proxy)
        {
            Proxy_Checked p_info = get_proxy_info(proxy);

            driver.ExecuteCdpCommand("Emulation.setGeolocationOverride", new Dictionary<string, object>
            {
                ["latitude"] = p_info.proxy_info.lat,
                ["longitude"] = p_info.proxy_info.lon,
                ["accuracy"] = 100
            });
            driver.ExecuteCdpCommand("Emulation.setTimezoneOverride", new Dictionary<string, object>
            {
                ["timezoneId"] = p_info.proxy_info.timezone
            });            
        }
    }
}
