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
        public string AuthToken { get; init; }

        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("mappingState")]
        public string MappingState { get; init; }

        [JsonPropertyName("mappingError")]
        public string MappingError { get; init; }

        [JsonPropertyName("signInState")]
        public string SignInState { get; init; }

        [JsonPropertyName("publicAddress")]
        public string PublicAddress { get; init; }

        [JsonPropertyName("publicPort")]
        public int PublicPort { get; init; }

        [JsonPropertyName("privateAddress")]
        public string PrivateAddress { get; init; }

        [JsonPropertyName("privatePort")]
        public int PrivatePort { get; init; }

        [JsonPropertyName("subscriptionFeatures")]
        public string SubscriptionFeatures { get; init; }

        [JsonPropertyName("subscriptionActive")]
        public bool SubscriptionActive { get; init; }

        [JsonPropertyName("subscriptionState")]
        public string SubscriptionState { get; init; }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
