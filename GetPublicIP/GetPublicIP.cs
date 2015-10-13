using System;
using System.Net;
using System.IO;

namespace GetPublicIP
{
    public class GetPublicIP
    {
        public string getIP()
        {
            try
            {
                String publicIP = String.Empty;
                WebRequest request = WebRequest.Create(@"http://checkip.dyndns.org");
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                { publicIP = stream.ReadToEnd();}
                int ini = publicIP.IndexOf("Address: ") + 9;
                int fim = publicIP.LastIndexOf("</body>");
                publicIP = publicIP.Substring(ini, fim - ini);
                return publicIP;
            }
            catch
            {
                return "404";
            }
        }
    }
}
