using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
	class ComputerLogic
	{
		private readonly string[] xoList;

		public ComputerLogic(String[] xoList)
		{
			this.xoList = xoList;
		}

		public bool CheckForAWinner()
		{
			if (
					(xoList[0] == xoList[1] && xoList[0] == xoList[2] && xoList[0] != " ") ||  // Top row
					(xoList[3] == xoList[4] && xoList[3] == xoList[5] && xoList[3] != " ") ||  // Middle row
					(xoList[6] == xoList[7] && xoList[6] == xoList[8] && xoList[6] != " ") ||  // Bottom row
					(xoList[0] == xoList[3] && xoList[0] == xoList[6] && xoList[0] != " ") ||  // Left column
					(xoList[1] == xoList[4] && xoList[1] == xoList[7] && xoList[1] != " ") ||  // Middle column
					(xoList[2] == xoList[5] && xoList[2] == xoList[8] && xoList[2] != " ") ||  // Right column
					(xoList[0] == xoList[4] && xoList[0] == xoList[8] && xoList[0] != " ") ||  // Diagonal 1
					(xoList[2] == xoList[4] && xoList[2] == xoList[6] && xoList[2] != " ")     // Diagonal 2
					)
			{
				Console.WriteLine("We have a winner!");
				return true;
			}
			return false;
		}

		public bool CheckIfBoardIsFull()
		{
			for (int i = 0; i < xoList.Length; i++)
			{
				if (xoList[i] == " ")
				{
					return false;
				}
			}
			return true;
		}

		public int ComputerMovesRandomly()
		{
			Random random = new Random();
			int randomNumber;
			do
			{
				randomNumber = random.Next(9);
			} while (xoList[randomNumber] != " ");

			return randomNumber;
		}
	
		public int ComputerMoves()
		{
			int winningMove;
			if (CanWinOrBlock(out winningMove)) return winningMove;

			return ComputerMovesRandomly();

		}

		public bool CanWinOrBlock(out int winningMove)
		{
			if (xoList[0] == " ") // Top Left to Win or Block
			{
				if (same(1,2) || same(4,8) || same(3,6)) 
				{
					winningMove = 0;
					return true;
				}
			}

			if (xoList[1] == " ") // Top Center to Win or Block
			{
				if (same(0,2) || same(4,7))  
				{
					winningMove = 1;
					return true;
				}
			}

			if (xoList[2] == " ") // Top Right to Win or Block
			{
				if (same(0,1) || same(4,6) || same(5,8))  
				{
					winningMove = 2;
					return true;
				}
			}

			if (xoList[3] == " ") // Center Left to Win or Block
			{
				if (same(0,6) || same(4,5))  
				{
					winningMove = 3;
					return true;
				}
			}

			if (xoList[4] == " ") // Center Center to Win or Block
			{
				if (same(0,8) || same(2, 6) || same(1,7) || same(3,5))
				{
					winningMove = 4;
					return true;
				}
			}
			
			if(xoList[5] == " ") // Center Right to Win or Block
			{
				if (same(2,8) || same(3,4))
				{
					winningMove = 5;
					return true;
				}
			}

			if(xoList[6] == " ") // Bottom Left to Win or Block
			{
				if (same(0,3) || same(2,4) || same(7,8))
				{
					winningMove = 6;
					return true;
				}
			}

			if(xoList[7] == " ") // Bottom Center to Win or Block
			{
				if (same(1,4) || same(6,8))  
				{
					winningMove = 7;
					return true;
				}
			}

			if(xoList[8] == " ") // Bottom Right to Win or Block
			{
				if (same(2,5) || same(0,4) || same(6,7))
				{
					winningMove = 8;
					return true;
				}
			}

			winningMove = -1;
			return false;
		}

		public bool same(int a, int b)
		{
			if (xoList[a] == xoList[b] && xoList[a] != " ")
			{
				return true;
			}
			return false;
		}
	}
}
