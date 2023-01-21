using System.Diagnostics;

using Smab.DiceAndTiles;

using static Smab.DiceAndTiles.BoggleDice.BoggleType;

namespace Smab.Boggle.Models;

public partial class BoggleTray {

	private long _timerStart;
	
	public BoggleDice BoggleSet { get; set; } = new();
	public BoggleDice.BoggleType BoggleSetType { get; set; } = Classic4x4;
	public List<BoggleSlot> Slots { get; set; } = new();

	public int Width => BoggleSet.BoardSize;
	public int Height => BoggleSet.BoardSize;
	public int DiceCount => BoggleSet.NoOfDice;
	// public GameStatus Status { get; set; }

	public TimeSpan ElapsedTime => Stopwatch.GetElapsedTime(_timerStart);
	//private TimeSpan TimeRemaining => TimerLength.Subtract(Stopwatch.GetElapsedTime(_timerStart));

	public BoggleTray() {
		Reset();
	}

	public BoggleTray(BoggleDice.BoggleType boggleSetType) {
		BoggleSetType = boggleSetType;
		Reset();
	}

	public void Reset() {
		StartNewGame(BoggleSetType);
	}

	private void StartNewGame(BoggleDice.BoggleType boggleSetType) {
		BoggleSet = new BoggleDice(boggleSetType);
		BoggleSet.ShakeAndFillBoard();
		int id = 1;
		int setIndex = 0;
		for (int i = 1; i <= Height; i++) {
			for (int j = 1; j <= Width; j++) {
				Slots.Add(new BoggleSlot(id++, j, i, (LetterDie)BoggleSet.Board[setIndex++].Die));
			}
		}
		Slots.ForEach(s => s.AdjacentSlots = GetAdjacentSlots(s.X, s.Y));
		_timerStart = Stopwatch.GetTimestamp();
	}

	public void EndGame() {
		//Stopwatch.Stop();
	}

	public List<BoggleSlot> GetAdjacentSlots(int x, int y) {
		IEnumerable<BoggleSlot> adjacentSlots =
			Slots.Where(slot => slot.X >= (x - 1) && slot.X <= (x + 1) && slot.Y >= (y - 1) && slot.Y <= (y + 1));
		IEnumerable<BoggleSlot> currentSlot = Slots.Where(slot => slot.X == x && slot.Y == y);
		return adjacentSlots.Except(currentSlot).ToList();
	}
}
