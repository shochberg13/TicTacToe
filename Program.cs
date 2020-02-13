using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{// TO DO LIST
    /**
     * 
     * DONE 1) Give user option to skip tutorial
     * 2) Create algorithm
     * DONE 3) Handle bad inputs from user
     *      a) If user tries to overwrite taken spot
     *      b) If user gives nonsense input (not a number between 1 - 9) 
     * 4) Allow user to choose X or O
     * 5) Change user input to qweasdzxc
     * 
     */
    class Program
    {
        public static void Main(string[] args)

        {
            Console.SetWindowSize(100, 20);
            UserInterface ui = new UserInterface();
            ui.GameStart();

            while (true)
            {
                Console.WriteLine("\n Would you like to play again? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.Clear();
                    ui = new UserInterface();
                    ui.GameStart();
                }
                else
                {
                    break;
                }
            }
        }
	}
}


