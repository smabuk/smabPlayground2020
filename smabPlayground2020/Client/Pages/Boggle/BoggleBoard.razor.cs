﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Smab.Boggle.Models;
using Smab.DiceAndTiles;

using static Smab.DiceAndTiles.BoggleDice.BoggleType;

namespace smabPlayground2020.Client.Pages.Boggle;

public partial class BoggleBoard {
	string currentWord = String.Empty;
	BoggleSlot? lastSlot;

	[Parameter]
	public BoggleTray BoggleTray { get; set; } = new();
	[Parameter]
	public bool Reverse { get; set; } = false;

	protected override void OnParametersSet() {
		Console.WriteLine($"New Game: {BoggleTray.BoggleSetType}");
		lastSlot = null;
		currentWord = String.Empty;
	}

	private void SelectSlot(MouseEventArgs e, BoggleSlot slot) {
		string letter = slot.Die?.FaceValue.Value ?? String.Empty;
		if (lastSlot is not null && lastSlot == slot) {
			Console.WriteLine($"Word:  {currentWord}  Score: {ScoreWord(currentWord, BoggleTray.BoggleSetType)}");
			// ToDo: Check Word
			// ToDo: Add score
			currentWord = String.Empty;
			lastSlot = null;
			BoggleTray.Slots.ForEach(s => { s.IsSelected = false; s.ArrowDirection = "NONE"; });
		} else if (slot.IsSelectable && (lastSlot is null || (slot.AdjacentSlots?.Contains(lastSlot) ?? false))) {
			//Console.WriteLine($"Selected: {letter} at ({slot.X}, {slot.Y}) with Button={((ButtonType)e.Button).ToString()} and OtherButtons={((OtherButtonTypes)e.Buttons).ToString()}");
			//Console.WriteLine($"Direction: {GetDirection(lastSlot?.X, lastSlot?.Y, slot.X, slot.Y)}");
			if (lastSlot is null) {
				slot.ArrowDirection = GetDirection(lastSlot?.X, lastSlot?.Y, slot.X, slot.Y);
			} else {
				lastSlot.ArrowDirection = GetDirection(lastSlot?.X, lastSlot?.Y, slot.X, slot.Y);
			}
			slot.IsSelected = true;
			currentWord += letter;
			lastSlot = slot;
		}
	}

	private static int ScoreWord(string word, BoggleDice.BoggleType boggleSetType) {
		return (boggleSetType, word.Length) switch {
			(BigBoggleDeluxe or BigBoggleOriginal or BigBoggleChallenge or SuperBigBoggle2012, <= 3) => 0,
			(SuperBigBoggle2012, >= 9) => word.Length * 2,
			(_, 3) => 1,
			(_, 4) => 1,
			(_, 5) => 2,
			(_, 6) => 3,
			(_, 7) => 5,
			(_, >= 8) => 11,
			(_, _) => 0
		};

		/*
		*     4x4 version            5x5 version           6x6 version
		*
		*    Word                   Word                  Word
		*   length	Points         length	Points       length	Points
		*     3       1              3       0             3       0
		*     4       1              4       1             4       1
		*     5       2              5       2             5       2
		*     6       3              6       3             6       3
		*     7       5              7       5             7       5
		*     8+     11              8+     11             8      11
		*                                                  9+   2 pts per letter
		*/
	}

	private static bool CheckWord(string word) {
		return true;
	}

	private static string GetDirection(int? lastX, int? lastY, int newX, int newY) {
		if (lastX is null || lastY is null) {
			return "START";
		}

		return (newX - lastX, newY - lastY) switch {
			(0, 0) => "END",
			(0, -1) => "N",
			(1, -1) => "NE",
			(1, 0) => "E",
			(1, 1) => "SE",
			(0, 1) => "S",
			(-1, 1) => "SW",
			(-1, 0) => "W",
			(-1, -1) => "NW",
			_ => String.Empty
		};
	}


	private enum ButtonType {
		Left = 0,
		Middle = 1,
		Right = 2
	}

	[Flags]
	private enum OtherButtonTypes {
		None = 0,
		Left = 1,
		Right = 2,
		Middle = 4,
		Back = 8,
		Forward = 16,
	}

}
