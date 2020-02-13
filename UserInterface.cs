using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class UserInterface
    {
        private readonly String[] xoList;
        private readonly ComputerLogic logic;
        private readonly Display display;
        private bool userGoesFirst;
        private string userLetter;
        private string cpuLetter;
        private bool gameContinues;

        public UserInterface()
        {
            this.xoList = new string[9];
            for(int i = 0; i < xoList.Length; i++)
            {
                xoList[i] = " ";
            }
            this.logic = new ComputerLogic(xoList);
            this.display = new Display();
            this.gameContinues = true;
        }

        public void GameStart()
        {
            
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Tutorial();
            ChooseLetters();
            DecideWhoGoesFirst();

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
            string userInput;
            do
            {
                Console.Write("Would like to do the brief tutorial? (y/n)  ");
                userInput = Console.ReadLine().ToLower();
            }
            while (userInput != "y" && userInput != "n");

            if (userInput == "n") return;

            Console.WriteLine("Now in order to interact with this game, you will be typing a number from 1 through 9 like so:");
            display.DisplayBeginningBoard();

            Console.WriteLine(" \nTo confirm you understand, type the number corresponding to the middle-middle square.");
            CheckForUnderstanding("5");

            Console.WriteLine("\nExcellent! Now type the number that corresponds to the top right square.");
            CheckForUnderstanding("3");

            Console.WriteLine("\nLast test: type the number that corresponds to the bottom left square.");
            CheckForUnderstanding("7");
        }

        public void CheckForUnderstanding(string expectedOutput)
        {
            String checkForUnderstanding;
            do
            {
                checkForUnderstanding = Console.ReadLine();
            } while (checkForUnderstanding != expectedOutput);
        }
        
        public void ChooseLetters()
        {
            string userInput;
            do {
                Console.Write("Would you like to be X or O?  ");
                userInput = Console.ReadLine().ToUpper();
            } while (userInput != "X" && userInput != "O") ;
            
            this.userLetter = userInput;
            if (this.userLetter == "X") this.cpuLetter = "O";
            if (this.userLetter == "O") this.cpuLetter = "X";
            this.logic.setCpuLetter(this.cpuLetter);
            this.logic.setUserLetter(this.userLetter);

            Console.WriteLine("You'll be {0} and I'll be {1}", this.userLetter, this.cpuLetter);
        }


        public void DecideWhoGoesFirst()
        {
            this.userGoesFirst = UserGoFirst();
            logic.setUserGoesFirst(this.userGoesFirst);

            if (!this.userGoesFirst)
            {
                Console.WriteLine("Computer will go first");
                Console.WriteLine("\n \n------------ GAME BEGIN -----------");
                ComputerMove();

            }
            else
            {
                Console.WriteLine("You will go first.");
                Console.WriteLine("\n \n------------ GAME BEGIN -----------");
            }
        }

        public bool UserGoFirst()
        {
            Console.WriteLine("\nNow let's flip a coin to see who goes first!");
            Console.Write("Would you like heads or tails? (h/t)  ");
            string inputStr = Console.ReadLine().ToLower();

            //Add pause for suspense
            Console.Write("Coin flip");
            for (int i = 0; i < 4; i++)
            {
                System.Threading.Thread.Sleep(500);
                Console.Write(" . ");
            }

            if (new Random().Next(2) == 0)
            {
                Console.WriteLine(" --> HEADS");
                if (inputStr == "h") return true;
                if (inputStr == "t") return false;
            }
            else
            {
                Console.WriteLine(" --> TAILS");
                if (inputStr == "h") return false;
                if (inputStr == "t") return true;
            }

            // For now just testing cpu goes first case
            return false;
        }

        public void UserMove()
        {
            int input = -1;

            // Catch any invalid inputs
            do
            {
                Console.Write("Type your number to place \'{0}\'. (Must be between 1 and 9)  ", this.userLetter);
                try
                {
                    // Catch if input is not an integer
                    input = Int32.Parse(Console.ReadLine());
                    
                    // Catch if input is not between 1 and 9
                    if (input < 1 || input > 9)
                    {
                        Console.WriteLine("Out of Range");
                        input = -1; // Reset to stay in do-while loop
                        throw new Exception();
                    }

                    // Catch if spot is already taken
                    if (xoList[input - 1] != " ")
                    {
                        Console.WriteLine("That spot is taken");
                        input = -1; // Reset to stay in do-while loop
                        throw new Exception();
                    }
                        
                }
                catch
                {
                }
            } while (input == -1);


            xoList[input - 1] = this.userLetter;
            display.DisplayBoard(xoList);
        }
        
        public void ComputerMove()
        {
            WaitForComputerMove();
            xoList[logic.ComputerMoves()] = this.cpuLetter;
            display.DisplayBoard(xoList);
        }

        public static void WaitForComputerMove()
        {
            Console.WriteLine("\nType [ENTER] to see the my move.");
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
            
            if (logic.BoardIsFull())
            {
                Console.WriteLine("Well played. Looks like we tied");
                gameContinues = false;
                return true;
            }
            return false;
        }
        
    }
}
