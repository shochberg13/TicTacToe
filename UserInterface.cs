using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class UserInterface
    {
        private readonly String[] xoList;
        private readonly GameLogic logic;
        private readonly Display display;
        private bool gameContinues;

        public UserInterface()
        {
            this.xoList = new string[9];
            for(int i = 0; i < xoList.Length; i++)
            {
                xoList[i] = " ";
            }
            this.logic = new GameLogic(xoList);
            this.display = new Display();
            this.gameContinues = true;
        }

        public void GameStart()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Would like to do the brief tutorial? (y/n)");
            if (Console.ReadLine() == "y") Tutorial();

            while (gameContinues) 
            {
                UserMove();
                if (CheckIfGameIsOver()) break;
                ComputerMove();
                CheckIfGameIsOver();
            }
        }

        public void Tutorial()
        {

            Console.WriteLine("You will be X, and I will be O.\n\nType what letter you will be to confirm.");
            CheckForUnderstanding("X");
            Console.WriteLine("\n Excellent! You will be X");
            
            Console.WriteLine("Now in order to interact with this game, you will be typing a number from 1 through 9 like so:.");
            display.DisplayBeginningBoard();

            Console.WriteLine(" \nTo confirm you understand, type the number corresponding to the middle-middle square.");
            CheckForUnderstanding("5");

            Console.WriteLine("\n Excellent! Now type the number that corresponds to the top right square.");
            CheckForUnderstanding("3");

            Console.WriteLine("\n Last test: type the number that corresponds to the bottom left square.");
            CheckForUnderstanding("7");

            Console.WriteLine("\n \n------------ GAME BEGIN -----------");
        }

        public void CheckForUnderstanding(string expectedOutput)
        {
            String checkForUnderstanding;
            do
            {
                checkForUnderstanding = Console.ReadLine();
            } while (checkForUnderstanding != expectedOutput);
        }
        
        public void UserMove()
        {
            Console.WriteLine("Type your number to place 'X'. (Must be between 1 and 9)");
            int input = Int32.Parse(Console.ReadLine());

            xoList[input - 1] = "X";
            display.DisplayBoard(xoList);
        }

        public void ComputerMove()
        {
            WaitForComputerMove();
            int cpuMove = logic.ComputerMoves();
            xoList[cpuMove] = "O";
            display.DisplayBoard(xoList);
        }

        public static void WaitForComputerMove()
        {
            Console.WriteLine("\n Type [ENTER] to see the computer's move.");
            Console.ReadLine();
        }

        public bool CheckIfGameIsOver()
        {
            // Check for winners or ties
            bool isThereAWinner = logic.CheckForAWinner();

            if (isThereAWinner)
            {
                Console.WriteLine("We have a winner!");
                gameContinues = false;
                return true;
            }
            
            if (logic.CheckIfBoardIsFull())
            {
                Console.WriteLine("Well played. Looks like we tied");
                gameContinues = false;
                return true;
            }
            return false;
        }
    }

    






}
