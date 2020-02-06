public class Display {

	public static void displayBeginningBoard() {

		System.out.println("   |   |   ");
		System.out.println(" 1 | 2 | 3 ");
		System.out.println("___|___|___");
		System.out.println("   |   |   ");
		System.out.println(" 4 | 5 | 6 ");
		System.out.println("___|___|___");
		System.out.println("   |   |   ");
		System.out.println(" 7 | 8 | 9 ");
		System.out.println("   |   |   ");
	}

	public static void displayBoard(String[] xoxoList) {

		
		System.out.println("   |   |   ");
		System.out.println(" " + xoxoList[0] + " | " + xoxoList[1] + " | " + xoxoList[2] + " ");
		System.out.println("___|___|___");
		System.out.println("   |   |   ");
		System.out.println(" " + xoxoList[3] + " | " + xoxoList[4] + " | " + xoxoList[5] + " ");
		System.out.println("___|___|___");
		System.out.println("   |   |   ");
		System.out.println(" " + xoxoList[6] + " | " + xoxoList[7] + " | " + xoxoList[8] + " ");
		System.out.println("   |   |   ");
		
		
		
	}
}
