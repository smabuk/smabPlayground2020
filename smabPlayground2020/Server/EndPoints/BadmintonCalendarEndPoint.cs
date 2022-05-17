using System.Runtime.InteropServices;

using Smab.ReadingBadminton;
using Smab.ReadingBadminton.Models;

using Smab.Calendar;

namespace smabPlayground2020.Server.EndPoints;
public static partial class BadmintonCalendarEndPoint
{
	public const string DefaultBadmintonCalendarByTeamRoute = "/calendar/badminton/{Division}/{TeamName}";

	public static Func<string, string, string?, IReadingBadmintonReader, HttpContext, Task<IResult>> GetCalendarByTeam =
	async (string Division, string TeamName, string? Command, IReadingBadmintonReader _badmintonReader, HttpContext context) =>
	{
		TeamName = TeamName.Replace("_", " ");
			List<Fixture>? fixtures = await _badmintonReader.GetFixtures(Division, TeamName);
		if (fixtures is null || fixtures.Count == 0) {
			return Results.NotFound();
		}

		TimeZoneInfo gmtZone = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) switch {
			true => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
			false => TimeZoneInfo.FindSystemTimeZoneById("GMT")
		};

		IcalCalendar ical = new() {
			Name = $"Reading Badminton - {Division} fixtures - {TeamName}",
			Description = "Fixtures and results of matches for the Reading Badminton Association"
		};

		ical.Events = new List<VEvent>();
		foreach (Fixture fixture in fixtures)
				{
			VEvent fixtureEvent = new() {
				UID = $"RBA {fixture.HomeTeam} vs {fixture.AwayTeam}",
				Summary = $"🏸 {fixture.HomeTeam} vs {fixture.AwayTeam}",
				Location = fixture.Venue,
				DateStart = TimeZoneInfo.ConvertTimeToUtc(fixture.When, gmtZone),
				DateEnd = TimeZoneInfo.ConvertTimeToUtc(fixture.When.AddHours(2.5), gmtZone),
				Priority = VEvent.PriorityLevel.Normal,
				Transparency = VEvent.TransparencyType.TRANSPARENT,
				Categories = "Badminton",
				Description = $"\n"
			};

			if (!string.IsNullOrEmpty(TeamName)) // If looking at a particular team add BUSY and 1hr REMINDER
			{
				fixtureEvent.Transparency = VEvent.TransparencyType.OPAQUE;
				fixtureEvent.Alarms = new List<VAlarm>
				{
					new VAlarm
					{
						Trigger = new System.TimeSpan(0, 0, 60, 0),
						Action = VAlarm.ActionType.DISPLAY,
						Description = "Reminder"
					}
				};
			}

			if (fixture.IsCompleted) {
				if (fixture.ForHome > fixture.ForAway) {
					fixtureEvent.Description += $"\nWIN:  {fixture.HomeTeam.ToUpper()}";
					fixtureEvent.Description += $"\nLOSS: {fixture.AwayTeam}";
				} else if (fixture.ForHome < fixture.ForAway) {
					fixtureEvent.Description += $"\nLOSS: {fixture.HomeTeam}";
					fixtureEvent.Description += $"\nWIN:  {fixture.AwayTeam.ToUpper()}";
				} else if (fixture.ForHome == fixture.ForAway) {
					fixtureEvent.Description += $"\nDRAW: {fixture.HomeTeam} and {fixture.AwayTeam}";
				}
				fixtureEvent.Description += $"\nScore: {fixture.Score}";
			}

			ical.Events.Add(fixtureEvent);
		}

		// Different ways of returning the information
		switch (Command?.ToUpper()) {
			case "TEXT":
				return Results.Content(ical.ToString(), "text/plain");
			case "CONTENT":
				context.Response.Headers.Add("content-disposition", $"inline;filename={Division}{TeamName}Fixtures.ics");
				return Results.Content(ical.ToString(), "text/calendar", System.Text.Encoding.UTF8);
			case "FILE":
				return Results.File(System.Text.Encoding.UTF8.GetBytes(ical.ToString()), "text/calendar", $"{Division}{TeamName}Fixtures.ics");
			case "JSON":
				return Results.Json(ical);
			case "NEG":
				return Results.Content(ical.ToString());
			default:
				break;
		}

		return Results.File(System.Text.Encoding.UTF8.GetBytes(ical.ToString()), "text/calendar", $"{Division}{TeamName}Fixtures.ics");

	};
}
