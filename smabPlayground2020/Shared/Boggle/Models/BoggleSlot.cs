using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Smab.DiceAndTiles;

namespace Smab.Boggle.Models
{
    public class BoggleSlot
    {
		public int Id { get; init; }

        public int X { get; init; }
        public int Y { get; init; }
        public LetterDie Die { get; set; }

        public bool IsMine { get; set; }
        public int AdjacentMines { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }

        public BoggleSlot(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
        public BoggleSlot(int id, int x, int y, LetterDie die)
        {
            Id = id;
            X = x;
            Y = y;
            Die = die;
        }

        public void Flag()
        {
            if (!IsRevealed)
            {
                IsFlagged = !IsFlagged;
            }
        }

        public void Reveal()
        {
            IsRevealed = true;
            IsFlagged = false; //Revealed panels cannot be flagged
        }
    }
}
