using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Display
    {
		public void DisplayBeginningBoard()
		{
			Console.WriteLine("   |   |   ");
			Console.WriteLine(" 1 | 2 | 3 ");
			Console.WriteLine("___|___|___");
			Console.WriteLine("   |   |   ");
			Console.WriteLine(" 4 | 5 | 6 ");
			Console.WriteLine("___|___|___");
			Console.WriteLine("   |   |   ");
			Console.WriteLine(" 7 | 8 | 9 ");
			Console.WriteLine("   |   |   ");
		}

		public void DisplayBoard(String[] xoList)
		{
			Console.WriteLine("   |   |   ");
			Console.WriteLine(" " + xoList[0] + " | " + xoList[1] + " | " + xoList[2] + " ");
			Console.WriteLine("___|___|___");
			Console.WriteLine("   |   |   ");
			Console.WriteLine(" " + xoList[3] + " | " + xoList[4] + " | " + xoList[5] + " ");
			Console.WriteLine("___|___|___");
			Console.WriteLine("   |   |   ");
			Console.WriteLine(" " + xoList[6] + " | " + xoList[7] + " | " + xoList[8] + " ");
			Console.WriteLine("   |   |   ");
		}
	}
}

