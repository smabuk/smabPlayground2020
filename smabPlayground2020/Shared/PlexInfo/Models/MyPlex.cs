using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class MyPlex
    {

        [JsonPropertyName("authToken")]
        public string AuthToken { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("mappingState")]
        public string MappingState { get; set; }

        [JsonPropertyName("mappingError")]
        public string MappingError { get; set; }

        [JsonPropertyName("signInState")]
        public string SignInState { get; set; }

        [JsonPropertyName("publicAddress")]
        public string PublicAddress { get; set; }

        [JsonPropertyName("publicPort")]
        public int PublicPort { get; set; }

        [JsonPropertyName("privateAddress")]
        public string PrivateAddress { get; set; }

        [JsonPropertyName("privatePort")]
        public int PrivatePort { get; set; }

        [JsonPropertyName("subscriptionFeatures")]
        public string SubscriptionFeatures { get; set; }

        [JsonPropertyName("subscriptionActive")]
        public bool SubscriptionActive { get; set; }

        [JsonPropertyName("subscriptionState")]
        public string SubscriptionState { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
