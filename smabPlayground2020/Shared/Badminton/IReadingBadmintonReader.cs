using Smab.ReadingBadminton.Models;

namespace Smab.ReadingBadminton;

public interface IReadingBadmintonReader {
	Task<List<Fixture>?> GetFixtures(string Division, string TeamName);
}
