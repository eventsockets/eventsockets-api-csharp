using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using EventSockets.API.Models;

namespace EventSockets.API.Tools
{
    public static class Rest
    {
        public static void Send(ApplicationConfig applicationConfig, Message message) 
        {
            var templateRestUrl = "{0}://{1}.{2}.eventsockets.com/?applicationKey={3}&version=" + applicationConfig.Version;

            var envelopeString = message.Sign(applicationConfig).ToJson();

            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            Stream httpWebRequestStream = null;

            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;

                var buffer = Encoding.UTF8.GetBytes(envelopeString);

                httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(templateRestUrl, (!applicationConfig.Secure ? "http" : "https"), (!applicationConfig.Secure ? "api" : "apis"), applicationConfig.ClusterKey, applicationConfig.ApplicationKey));
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = buffer.Length;

                httpWebRequestStream = httpWebRequest.GetRequestStream();
                httpWebRequestStream.Write(buffer, 0, buffer.Length);
                httpWebRequestStream.Close();

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            finally
            {
                if (httpWebRequestStream != null)
                {
                    httpWebRequestStream.Dispose();
                }

                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
            }

        }
    }
}
