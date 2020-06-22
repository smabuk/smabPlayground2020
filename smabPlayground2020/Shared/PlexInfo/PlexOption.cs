using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo
{
    public class PlexOption
    {
		public string Key { get; set; }
		public string Value { get; set; }

		public PlexOption(string key, string value)
		{
			Key = key;
			Value = value;
		}

		public PlexOption(string key, bool value)
		{
			Key = key;
			Value = (value == true) ? "1" : "0";
		}

		public PlexOption(string key, int value)
		{
			Key = key;
			Value = value.ToString();
		}

		public override string ToString() => $"{Key}={Value}";
	}
}
