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
                int ini, fim;
                string publicIP = string.Empty;
                WebRequest request = WebRequest.Create(@"http://checkip.dyndns.org");

                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                { publicIP = stream.ReadToEnd();}

                ini = publicIP.IndexOf("Address: ") + 9;
                fim = publicIP.LastIndexOf("</body>");

                return publicIP.Substring(ini, fim - ini);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}
