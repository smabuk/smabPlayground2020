using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class Server
	{
		[JsonPropertyName("name")]
		public string Name { get; init; }

		[JsonPropertyName("host")]
		public string Host { get; init; }

		[JsonPropertyName("address")]
		public string Address { get; init; }

		[JsonPropertyName("port")]
		public int Port { get; init; }

		[JsonPropertyName("machineIdentifier")]
		public string MachineIdentifier { get; init; }

		[JsonPropertyName("version")]
		public string Version { get; init; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
