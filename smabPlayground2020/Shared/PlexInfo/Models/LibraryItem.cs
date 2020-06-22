using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public class LibraryItem
    {

        [JsonPropertyName("MediaContainer")]
        public MediaContainer MediaContainer { get; set; } = new MediaContainer();
    }

}
