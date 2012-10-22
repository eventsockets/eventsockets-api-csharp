using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace EventSockets.API.Models
{
    [DataContract(Name = "message")]
    public class Message
    {
        public Message() { }

        public Message(List<MessageArg> messageArgs, Dictionary<string, string> messageData)
        {
            this.MessageArgs = messageArgs;
            this.MessageData = messageData;
        }
        public Message(List<MessageArg> messageArgs)
        {
            this.MessageArgs = messageArgs;
        }
        public Message(Dictionary<string, string> messageData)
        {
            this.MessageData = messageData;
        }

        [DataMember(Name = "messageArgs")]
        public List<MessageArg> MessageArgs = new List<MessageArg>();

        [DataMember(Name = "messageData")]
        public Dictionary<string, string> MessageData = new Dictionary<string, string>();

        public static Message FromJson(string jsonMessage)
        {
            return Tools.Json.Parse<Message>(jsonMessage);
        }

        public string ToJson()
        {
            return Tools.Json.Stringify(this);
        }

        public Envelope Sign(ApplicationConfig applicationConfig)
        {
            var envelope = new Envelope();
            envelope.Message = this.ToJson();

            var hashBytes = new HMACSHA256(Encoding.UTF8.GetBytes(applicationConfig.SignatureKey)).ComputeHash(Encoding.UTF8.GetBytes(envelope.Message));
            var hexString = new StringBuilder();
            for (var i = 0; i < hashBytes.Length; i++)
            {
                hexString.Append(hashBytes[i].ToString("X2"));
            }
            envelope.Auth = hexString.ToString();

            return envelope;
        }
    }
}
