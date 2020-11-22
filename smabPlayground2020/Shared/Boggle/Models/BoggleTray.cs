using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Smab.DiceAndTiles;

using static Smab.DiceAndTiles.BoggleDice.BoggleType;

namespace Smab.Boggle.Models
{
    public partial class BoggleTray
    {
		public BoggleDice BoggleSet { get; set; }
        public BoggleDice.BoggleType BoggleSetType { get; set; } = Classic4x4;
		public List<BoggleSlot> Slots { get; set; } = new();

        public int Width => BoggleSet.BoardSize;
        public int Height => BoggleSet.BoardSize;
        public int DiceCount => BoggleSet.NoOfDice;
		// public GameStatus Status { get; set; }

		public Stopwatch Stopwatch { get; set; } = new();

		public BoggleTray()
		{
            Reset();
		}

		public BoggleTray(BoggleDice.BoggleType boggleSetType)
		{
			BoggleSetType = boggleSetType;
            Reset();
		}

        public void Reset()
		{
            StartNewGame(BoggleSetType);
		}

		private void StartNewGame(BoggleDice.BoggleType boggleSetType)
		{
			BoggleSet = new BoggleDice(BoggleSetType);
			BoggleSet.ShakeAndFillBoard();
            int id = 1;
			int setIndex = 0;
			for (int i = 1; i <= Height; i++)
			{
				for (int j = 1; j <= Width; j++)
				{
					Slots.Add(new BoggleSlot(id++, j, i, BoggleSet.Board[setIndex++]));
				}
			}
			Slots.ForEach(s => s.AdjacentSlots = GetAdjacentSlots(s.X, s.Y));
			Stopwatch.Reset();
			Stopwatch.Start();
        }

		public void EndGame()
		{
			Stopwatch.Stop();
		}

		public List<BoggleSlot> GetAdjacentSlots(int x, int y)
		{
			IEnumerable<BoggleSlot> adjacentSlots = 
				Slots.Where(slot => slot.X >= (x - 1) && slot.X <= (x + 1) && slot.Y >= (y - 1) && slot.Y <= (y + 1));
			IEnumerable<BoggleSlot> currentSlot = Slots.Where(slot => slot.X == x && slot.Y == y);
			return adjacentSlots.Except(currentSlot).ToList();
		}
	}
}
