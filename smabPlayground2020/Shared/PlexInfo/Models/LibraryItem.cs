using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smab.PlexInfo.Models
{
    public record LibraryItem
    {
        [JsonPropertyName("MediaContainer")]
        public MediaContainer MediaContainer { get; init; }
    }
}
