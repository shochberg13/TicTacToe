using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        public static void Main(string[] args)

        {
            UserInterface ui = new UserInterface();
            ui.GameStart();

        }
	}
}

// TO DO LIST
/**
 * 1) Create algorithm
 * 2) Handle bad inputs from user
 *      a) If user tries to overwrite taken spot
 *      b) If user gives nonsense input (not a number between 1 - 9) 
 * 3) Allow user to choose X or O
 * 
 */
