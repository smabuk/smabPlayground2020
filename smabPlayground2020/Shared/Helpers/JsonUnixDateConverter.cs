﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.Helpers
{
	public sealed class JsonUnixDateConverter : JsonConverter<DateTime>
	{
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> reader.GetDouble().FromUnixDate();

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
			=> writer.WriteNumberValue((value.Year == 1) ? 0 : (value - Unix.Epoch).TotalSeconds);
	}

	public sealed class JsonUnixDateConverterWithNulls : JsonConverter<DateTime?>
	{
		public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> reader.GetDouble().FromUnixDate();

		public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
		{
			if (value is null)
			{
				writer.WriteNullValue();
			}
			if (value.HasValue)
			{
				if (value.Value.Year == 1)
				{
					writer.WriteNullValue();
				}
				else
				{
					writer.WriteNumberValue((value.Value - Unix.Epoch).TotalSeconds);
				}
			}
		}
	}

	internal static class Unix
	{
		internal readonly static DateTime Epoch = new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, millisecond: 0, kind: DateTimeKind.Utc);
	}

	internal static class DoubleExtensions
	{
		public static DateTime FromUnixDate(this double? unixDate)
		{
			DateTime dt;
			if (unixDate > 99999999999)
				// UNIX Epoch milliseconds
				dt = Unix.Epoch.AddSeconds(unixDate / (double)1000 ?? 0.0);
			else
				// UNIX Epoch seconds
				dt = Unix.Epoch.AddSeconds(unixDate ?? 0.0);
			return dt;
		}

		public static DateTime FromUnixDate(this double unixDate)
		{
			DateTime dt;
			if (unixDate > 99999999999)
				// UNIX Epoch milliseconds
				dt = Unix.Epoch.AddSeconds(unixDate / 1000);
			else
				// UNIX Epoch seconds
				dt = Unix.Epoch.AddSeconds(unixDate);
			return dt;
		}
	}

}
