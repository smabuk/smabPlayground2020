
using HtmlAgilityPack;

using Smab.ReadingBadminton.Models;

namespace Smab.ReadingBadminton;

public class ReadingBadmintonReader : IReadingBadmintonReader {

	public async Task<List<Fixture>?> GetFixtures(string Division, string TeamName) {
		string html;
		string url = $@"{"http://"}www.readingbadminton.org.uk/2021-22/fixtures/";
		string division = Division.Replace(" ", "_").ToLowerInvariant().Trim();
		using (HttpClient client = new()) {
			html = await client.GetStringAsync(url);
		}
		HtmlDocument doc = new();
		doc.LoadHtml(html);
		List<Fixture> fixtures = new();

		foreach (HtmlNode fixtureNode in doc.DocumentNode.Descendants().Where(n => n.HasClass("fixture") && n.HasClass($"bg_{division}"))) {

			bool CompletedFixture = fixtureNode.HasClass("complete");

			Fixture fixture = new() {
				Division = Division.Replace("%20", " "),
				IsCompleted = CompletedFixture
			};

			string when =
				$"{fixtureNode.ChildNodes[0].ChildNodes[0].InnerText}" +
				$" {_months[fixtureNode.ChildNodes[0].ChildNodes[0].InnerText[^3..]]}" +
				$" {fixtureNode.ChildNodes[0].ChildNodes[2].InnerText}";
			fixture.When = DateTime.Parse(when);

			fixture.Venue = fixtureNode.ChildNodes[1].ChildNodes[0].InnerText.Trim(); // td > span
			fixture.Division = fixtureNode.ChildNodes[2].ChildNodes[0].InnerText.Trim(); // td > span

			fixture.HomeTeam = fixtureNode.ChildNodes[3].ChildNodes[0].InnerText.Trim(); // td > span
			fixture.AwayTeam = fixtureNode.ChildNodes[5].ChildNodes[0].InnerText.Trim(); // td > span

			if (fixture.HomeTeam.ToLowerInvariant() == TeamName.ToLowerInvariant().Replace("%20", " ")
				|| fixture.AwayTeam.ToLowerInvariant() == TeamName.ToLowerInvariant().Replace("%20", " ")) {
				fixtures.Add(fixture);
			}

		}

		return fixtures;
	}

	private readonly Dictionary<string, string> _months = new() {
		{ "Sep", "2021" },
		{ "Oct", "2021" },
		{ "Nov", "2021" },
		{ "Dec", "2021" },
		{ "Jan", "2022" },
		{ "Feb", "2022" },
		{ "Mar", "2022" },
		{ "Apr", "2022" },
		{ "May", "2022" },
		{ "Jun", "2022" },
		{ "Jul", "2022" },
		{ "Aug", "2022" },
	};


}
