import java.util.Scanner;

public class UserInterface {
	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		
		// Intro to game
		gameStart();
		
		// Generate Empty String List (will update as game progress)
		String[] xoxoList = new String[9];
		for (int i = 0; i < xoxoList.length; i++){
			xoxoList[i] = " ";
		}
		
		boolean isThereAWinner = false;
		boolean isThereATie = false;
		
		// THE ACTUAL GAME
		while(!isThereAWinner || !isThereATie){
			
			// Ask for a number to put "X"
			System.out.println("Type your number. (Must be between 1 and 9)");
			int input = reader.nextInt();
	
			// Update StringArray with user's input
			xoxoList[input - 1] = "X";

			// Display the board with their recent move
			Display.displayBoard(xoxoList);
			
			// Check for winners or ties
			isThereAWinner = GameLogic.checkForAWinner(xoxoList);
			
			// Only check for a tie if there is no winner yet
			if (!isThereAWinner) {
				isThereATie = GameLogic.checkForATie(xoxoList);
			}
			
			if (isThereAWinner || isThereATie){
				break;
			}
			
			// Prompt user to see cpu move
			waitForComputerMove();
	
			// Make CPU move and display it.
			xoxoList = computerMove(xoxoList);
			
			// Repeat if no winners or ties yet!
			isThereAWinner = GameLogic.checkForAWinner(xoxoList);
			
			// Only check for a tie if there is no winner yet
			if (!isThereAWinner) {
				isThereATie = GameLogic.checkForATie(xoxoList);
			}
		}
	}

	public static void gameStart(){
		Scanner reader = new Scanner(System.in);	
		
		System.out.println("Welcome to Tic Tac Toe! You will be X, and I will be O.\n\n    Type what letter you will be to confirm.");
		String checkForUnderstanding = reader.nextLine();
		while (!checkForUnderstanding.equalsIgnoreCase("X")){
			checkForUnderstanding = reader.nextLine();	
		}
		
		System.out.println("\n \n \n \n Excellent! You will be X");
		System.out.println("Now in order to interact with this game, you will be typing a number from 1 through 9 like so:.");
		Display.displayBeginningBoard();
		
		System.out.println(" \nTo confirm you understand, type the number corresponding to the middle-middle square.");
		String checkForUnderstanding2 = reader.nextLine();
		while (!checkForUnderstanding2.equals("5")){
			checkForUnderstanding2 = reader.nextLine();	
		}
		
		System.out.println("\n \n \nExcellent! Now type the number that corresponds to the top right square.");
		String checkForUnderstanding3 = reader.nextLine();
		while (!checkForUnderstanding3.equals("3")){
			checkForUnderstanding3 = reader.nextLine();	
		}
		
		System.out.println("\n \n \nStupendous! Last test: type the number that corresponds to the bottom left square.");
		String checkForUnderstanding4 = reader.nextLine();
		int stupidCounter = 1;
		while (!checkForUnderstanding4.equals("7")){
				checkForUnderstanding4 = reader.nextLine();
				stupidCounter = stupidCounter + 1;
		}
		if (stupidCounter == 1){
		System.out.println("On your first try! You are ready");
		}
		else{
			System.out.println("-.- Only took you " + stupidCounter + " tries... Let's begin the game anyway.");
		}
		
		System.out.println("\n \n \n \n \n \n \n \n ------------ GAME BEGIN -----------");
	}

	public static void waitForComputerMove(){
		Scanner reader = new Scanner(System.in);
		System.out.println("\n Type enter to see the computer's move.");
		reader.nextLine();
	}

	public static String[] computerMove(String[] xoxoList){
		int availableSpot = GameLogic.goodRandomNumber(xoxoList);
		xoxoList[availableSpot] = "O";
		Display.displayBoard(xoxoList);
		return xoxoList;
	}
}
