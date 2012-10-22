using System.Runtime.Serialization;

namespace EventSockets.API.Models
{
    [DataContract(Name = "envelope")]
    public class Envelope
    {
        public Envelope() { }

        public Envelope(string message, string auth)
        {
            Message = message;
            Auth = auth;
        }

        [DataMember(Name = "message")]
        public string Message;

        [DataMember(Name = "auth")]
        public string Auth;

        public static Envelope FromJson(string jsonEnvelope)
        {
            return Tools.Json.Parse<Envelope>(jsonEnvelope);
        }

        public string ToJson() 
        {
            return Tools.Json.Stringify(this);
        }
    }
}
