using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using MailKit.Net.Pop3;
using MailKit.Security;

namespace ZKSync
{
    public class Pinata
    {
        public static string Pop3ActivationUrl(string email, string password)
        {
            string domain = null;   //Domain von pinata einfügen
            
            using (var client = new Pop3Client())
            {
                client.Connect("outlook.office365.com", 995, SecureSocketOptions.SslOnConnect);
                client.Authenticate(email, password);

                for (int i = client.Count - 1; i != client.Count - 6; i--)
                {
                    try
                    {
                        var message = client.GetMessage(i);
                        var regex = new Regex(@"(?i)\b(?:https?://|www\.)\S+\b");
                        var match = regex.Match(message.Body.ToString());
                        if (match.Value.Contains(domain))
                        {
                            client.Disconnect(true);
                            return match.Value;
                        }
                    }
                    catch
                    {
                        client.Disconnect(true);
                        return null;
                    }
                }

                // Disconnect from the server
                client.Disconnect(true);
                return null;
            }
        }
    }
}