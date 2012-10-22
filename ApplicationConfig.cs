using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventSockets.API
{
    public class ApplicationConfig
    {
        public readonly string Version = "1.0";
        public string ClusterKey;
        public string ApplicationKey;
        public string SignatureKey;
        public bool Secure;

        public ApplicationConfig(string clusterKey, string applicationKey, string signatureKey, bool secure) 
        {
            this.ClusterKey = clusterKey;
            this.ApplicationKey = applicationKey;
            this.SignatureKey = signatureKey;
            this.Secure = secure;
        }
    }
}
