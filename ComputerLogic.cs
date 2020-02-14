using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
	class ComputerLogic
	{
		private readonly string[] xoList;
		private bool userGoesFirst;
		private int computerMoveNumber;
		private string cpuLetter;
		private string userLetter;

		public ComputerLogic(String[] xoList)
		{
			this.xoList = xoList;
			computerMoveNumber = 0;
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
				return true;
			}
			return false;
		}

		public bool BoardIsFull()
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
			this.computerMoveNumber++;

			// Block or win the game if applicable
			int winningMove;
			int blockingMove;
			if (CanWin(out winningMove)) return winningMove;
			if (CanBlock(out blockingMove)) return blockingMove;


			// Algorithm if Computer has first move
			if (!userGoesFirst)
			{
				if (this.computerMoveNumber == 1) return 0;
				if (this.computerMoveNumber == 2)
				{
					if (xoList[3] == userLetter || xoList[5] == userLetter || xoList[6] == userLetter) return 2;
					if (xoList[1] == userLetter || xoList[2] == userLetter || xoList[7] == userLetter || xoList[8] == userLetter) return 6;
					if (xoList[4] == userLetter) return 8;
				}
				if (this.computerMoveNumber == 3)
				{
					if (xoList[2] == cpuLetter)
					{
						if (xoList[3] == userLetter || xoList[6] == userLetter) return 8;
						if (xoList[5] == userLetter) return 6;
					}
					if (xoList[6] == cpuLetter) 
					{
						if (xoList[1] == userLetter || xoList[2] == userLetter) return 8;
						if (xoList[7] == userLetter || xoList[8] == userLetter) return 2;
					}
				}
			}


			// Algorithm if User has first move
			if (userGoesFirst)
			{
				if (this.computerMoveNumber == 1)
				{
					if (xoList[4] == userLetter) return 0; // Center start
					if (xoList[0] == userLetter || xoList[2] == userLetter || xoList[6] == userLetter || xoList[8] == userLetter) return 4; // Corner Start
					if (xoList[1] == userLetter || xoList[3] == userLetter || xoList[5] == userLetter || xoList[7] == userLetter) return 4; // Edge Start
				}

				if (this.computerMoveNumber == 2)
				{
					// Center start
					if (xoList[4] == userLetter && xoList[0] == cpuLetter && xoList[8] == userLetter) return 2;
					
					// Corner Start
					if (xoList[0] == userLetter && xoList[8] == userLetter || xoList[2] == userLetter && xoList[6] == userLetter) return 1; 
					if (xoList[0] == userLetter && xoList[5] == userLetter) return 2; 
					if (xoList[0] == userLetter && xoList[7] == userLetter) return 6; 
					if (xoList[2] == userLetter && xoList[3] == userLetter) return 0; 
					if (xoList[2] == userLetter && xoList[7] == userLetter) return 8; 
					if (xoList[6] == userLetter && xoList[1] == userLetter) return 0; 
					if (xoList[6] == userLetter && xoList[5] == userLetter) return 8;
					if (xoList[8] == userLetter && xoList[1] == userLetter) return 2;
					if (xoList[8] == userLetter && xoList[3] == userLetter) return 6;

					// Edge Start
					if ((xoList[3] == userLetter && xoList[5] == userLetter) || (xoList[1] == userLetter && xoList[7] == userLetter)) return 2;
					if (xoList[1] == userLetter && xoList[3] == userLetter) return 0;
					if (xoList[1] == userLetter && xoList[5] == userLetter) return 2;
					if (xoList[7] == userLetter && xoList[3] == userLetter) return 6;
					if (xoList[7] == userLetter && xoList[5] == userLetter) return 8;

				}
			}

			Console.WriteLine("moving randomly");
			return ComputerMovesRandomly();

		}

		public bool CanWin(out int winningMove)
		{
			if (xoList[0] == " ") // Top Left to Win or Block
			{
				if (SameCpu(1,2) || SameCpu(4,8)  || SameCpu(3,6))
				{
					winningMove = 0;
					return true;
				}
			}

			if (xoList[1] == " ") // Top Center to Win or Block
			{
				if (SameCpu(0,2) || SameCpu(4,7))  
				{
					winningMove = 1;
					return true;
				}
			}

			if (xoList[2] == " ") // Top Right to Win or Block
			{
				if (SameCpu(0,1) || SameCpu(4,6) || SameCpu(5,8))  
				{
					winningMove = 2;
					return true;
				}
			}

			if (xoList[3] == " ") // Center Left to Win or Block
			{
				if (SameCpu(0,6) || SameCpu(4,5))  
				{
					winningMove = 3;
					return true;
				}
			}

			if (xoList[4] == " ") // Center Center to Win or Block
			{
				if (SameCpu(0,8) || SameCpu(2, 6) || SameCpu(1,7) || SameCpu(3,5))
				{
					winningMove = 4;
					return true;
				}
			}
			
			if(xoList[5] == " ") // Center Right to Win or Block
			{
				if (SameCpu(2,8) || SameCpu(3,4))
				{
					winningMove = 5;
					return true;
				}
			}

			if(xoList[6] == " ") // Bottom Left to Win or Block
			{
				if (SameCpu(0,3) || SameCpu(2,4) || SameCpu(7,8))
				{
					winningMove = 6;
					return true;
				}
			}

			if(xoList[7] == " ") // Bottom Center to Win or Block
			{
				if (SameCpu(1,4) || SameCpu(6,8))  
				{
					winningMove = 7;
					return true;
				}
			}

			if(xoList[8] == " ") // Bottom Right to Win or Block
			{
				if (SameCpu(2,5) || SameCpu(0,4) || SameCpu(6,7))
				{
					winningMove = 8;
					return true;
				}
			}

			winningMove = -1;
			return false;
		}

		public bool CanBlock(out int blockingMove)
		{
			if (xoList[0] == " ") // Top Left to Win or Block
			{
				if (SameUser(1, 2) || SameUser(4, 8) || SameUser(3, 6))
				{
					blockingMove = 0;
					return true;
				}
			}

			if (xoList[1] == " ") // Top Center to Win or Block
			{
				if (SameUser(0, 2) || SameUser(4, 7))
				{
					blockingMove = 1;
					return true;
				}
			}

			if (xoList[2] == " ") // Top Right to Win or Block
			{
				if (SameUser(0, 1) || SameUser(4, 6) || SameUser(5, 8))
				{
					blockingMove = 2;
					return true;
				}
			}

			if (xoList[3] == " ") // Center Left to Win or Block
			{
				if (SameUser(0, 6) || SameUser(4, 5))
				{
					blockingMove = 3;
					return true;
				}
			}

			if (xoList[4] == " ") // Center Center to Win or Block
			{
				if (SameUser(0, 8) || SameUser(2, 6) || SameUser(1, 7) || SameUser(3, 5))
				{
					blockingMove = 4;
					return true;
				}
			}

			if (xoList[5] == " ") // Center Right to Win or Block
			{
				if (SameUser(2, 8) || SameUser(3, 4))
				{
					blockingMove = 5;
					return true;
				}
			}

			if (xoList[6] == " ") // Bottom Left to Win or Block
			{
				if (SameUser(0, 3) || SameUser(2, 4) || SameUser(7, 8))
				{
					blockingMove = 6;
					return true;
				}
			}

			if (xoList[7] == " ") // Bottom Center to Win or Block
			{
				if (SameUser(1, 4) || SameUser(6, 8))
				{
					blockingMove = 7;
					return true;
				}
			}

			if (xoList[8] == " ") // Bottom Right to Win or Block
			{
				if (SameUser(2, 5) || SameUser(0, 4) || SameUser(6, 7))
				{
					blockingMove = 8;
					return true;
				}
			}

			blockingMove = -1;
			return false;
		}

		public bool SameCpu(int a, int b)
		{
			if (xoList[a] == xoList[b] && xoList[a] != " " && xoList[a] == cpuLetter)
			{
				return true;
			}
			return false;
		}

		public bool SameUser(int a, int b)
		{
			if (xoList[a] == xoList[b] && xoList[a] != " " && xoList[a] == userLetter)
			{
				return true;
			}
			return false;
		}

		public void SetUserGoesFirst(bool userGoesFirst)
		{
			this.userGoesFirst = userGoesFirst;
		}
		public void SetCpuLetter(string cpuLetter)
		{
			this.cpuLetter = cpuLetter;
		}

		public void SetUserLetter(string userLetter)
		{
			this.userLetter = userLetter;
		}
	}
}
