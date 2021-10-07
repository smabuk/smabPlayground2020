using smab.ReadingBadminton.Models;

namespace smab.ReadingBadminton;

public interface IReadingBadmintonReader {
	Task<List<Fixture>?> GetFixtures(string Division, string TeamName);
}
