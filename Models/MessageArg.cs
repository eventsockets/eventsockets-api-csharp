using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EventSockets.API.Models
{
    [DataContract(Name = "messageArg")]
    public class MessageArg
    {
        public MessageArg() { }

        public MessageArg(string channelPrefix, string channelName, string eventPrefix, string eventName)
        {
            this.ChannelPrefix = channelPrefix;
            this.ChannelName = channelName;
            this.EventPrefix = eventPrefix;
            this.EventName = eventName;
        }

        public MessageArg(string channelPrefix, string channelName, string eventPrefix, string eventName, Dictionary<string, string> eventData)
        {
            this.ChannelPrefix = channelPrefix;
            this.ChannelName = channelName;
            this.EventPrefix = eventPrefix;
            this.EventName = eventName;
            this.EventData = eventData;
        }

        [DataMember(Name = "eventPrefix")]
        public string EventPrefix;

        [DataMember(Name = "eventName")]
        public string EventName;

        [DataMember(Name = "channelPrefix")]
        public string ChannelPrefix;

        [DataMember(Name = "channelName")]
        public string ChannelName;

        [DataMember(Name = "eventData")]
        public Dictionary<string, string> EventData = new Dictionary<string, string>();
    }
}
