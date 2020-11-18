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

        public bool IsSelected { get; set; } = false;
        public string ArrowDirection { get; set; } = "NONE";
        public List<BoggleSlot> AdjacentSlots { get; set; }

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

        public void ToggleSelect()
        {
            IsSelected = !IsSelected;
        }


    }
}
