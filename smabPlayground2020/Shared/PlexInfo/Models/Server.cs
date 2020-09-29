using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class Server
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("host")]
		public string Host { get; set; }

		[JsonPropertyName("address")]
		public string Address { get; set; }

		[JsonPropertyName("port")]
		public int Port { get; set; }

		[JsonPropertyName("machineIdentifier")]
		public string MachineIdentifier { get; set; }

		[JsonPropertyName("version")]
		public string Version { get; set; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
