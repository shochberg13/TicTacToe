public class GameLogic {

	public static boolean checkForAWinner(String[] xoxoList){
		boolean isThereAWinnerYet = false;
		
		if (  
				(xoxoList[0].equals(xoxoList[1]) && xoxoList[0].equals(xoxoList[2])  && !xoxoList[0].equals(" ")) ||  // Top row
				(xoxoList[3].equals(xoxoList[4]) && xoxoList[3].equals(xoxoList[5])  && !xoxoList[3].equals(" ")) ||  // Middle row
				(xoxoList[6].equals(xoxoList[7]) && xoxoList[6].equals(xoxoList[8])  && !xoxoList[6].equals(" ")) ||  // Bottom row
				(xoxoList[0].equals(xoxoList[3]) && xoxoList[0].equals(xoxoList[6])  && !xoxoList[0].equals(" ")) ||  // Left column
				(xoxoList[1].equals(xoxoList[4]) && xoxoList[1].equals(xoxoList[7])  && !xoxoList[1].equals(" ")) ||  // Middle column
				(xoxoList[2].equals(xoxoList[5]) && xoxoList[2].equals(xoxoList[8])  && !xoxoList[2].equals(" ")) ||  // Right column
				(xoxoList[0].equals(xoxoList[4]) && xoxoList[0].equals(xoxoList[8])  && !xoxoList[0].equals(" ")) ||  // Diagonal 1
				(xoxoList[2].equals(xoxoList[4]) && xoxoList[2].equals(xoxoList[6])  && !xoxoList[2].equals(" "))     // Diagonal 2
				){
			
			isThereAWinnerYet = true;
			System.out.println("We have a winner!");
		}
		
		return isThereAWinnerYet;
	}

	public static boolean checkForATie(String[] xoxoList) {
		boolean isThereATieYet = true;

		for (int i = 0; i < xoxoList.length; i++) {
			if (xoxoList[i].equals(" ")) {
				isThereATieYet = false;
			}
		}
		if (isThereATieYet) {
			System.out
					.println("You win some, you lose some. But in this case, we both TIED!");
		}
		return isThereATieYet;
	}

	public static int randomNumber() {

		// Randomly set find an integer between 0 and 8
		int multiplier = 8;
		int randomNumber = (int) Math.round(Math.random() * multiplier);
		return randomNumber;
	}

	public static int goodRandomNumber(String[] xoxoList) {

		// Keep finding random number until it matches an unnoccupied spot
		int randomNumber = randomNumber();
		while (!xoxoList[randomNumber].equals(" ")) {
			randomNumber = randomNumber();
		}
		return randomNumber;
	}
}
