using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
	class GameLogic
	{
		private readonly string[] xoxoList;

		public GameLogic(String[] xoxoList)
		{
			this.xoxoList = xoxoList;
		}

		public bool CheckForAWinner()
		{
			if (
					(xoxoList[0] == xoxoList[1] && xoxoList[0] == xoxoList[2] && xoxoList[0] != " ") ||  // Top row
					(xoxoList[3] == xoxoList[4] && xoxoList[3] == xoxoList[5] && xoxoList[3] != " ") ||  // Middle row
					(xoxoList[6] == xoxoList[7] && xoxoList[6] == xoxoList[8] && xoxoList[6] != " ") ||  // Bottom row
					(xoxoList[0] == xoxoList[3] && xoxoList[0] == xoxoList[6] && xoxoList[0] != " ") ||  // Left column
					(xoxoList[1] == xoxoList[4] && xoxoList[1] == xoxoList[7] && xoxoList[1] != " ") ||  // Middle column
					(xoxoList[2] == xoxoList[5] && xoxoList[2] == xoxoList[8] && xoxoList[2] != " ") ||  // Right column
					(xoxoList[0] == xoxoList[4] && xoxoList[0] == xoxoList[8] && xoxoList[0] != " ") ||  // Diagonal 1
					(xoxoList[2] == xoxoList[4] && xoxoList[2] == xoxoList[6] && xoxoList[2] != " ")     // Diagonal 2
					)
			{
				Console.WriteLine("We have a winner!");
				return true;
			}
			return false;
		}

		public bool CheckIfBoardIsFull()
		{
			for (int i = 0; i < xoxoList.Length; i++)
			{
				if (xoxoList[i] == " ")
				{
					return false;
				}
			}
			return true;
		}

		public int ComputerMoves()
		{
			Random random = new Random();
			int randomNumber;
			do
			{
				randomNumber = random.Next(9);
			} while (xoxoList[randomNumber] != " ");

			return randomNumber;
		}
	}
}
