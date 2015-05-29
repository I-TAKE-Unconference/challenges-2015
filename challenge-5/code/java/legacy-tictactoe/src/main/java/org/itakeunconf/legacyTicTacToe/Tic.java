package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;
import java.util.Date;
import java.util.Random;
import java.util.Scanner;

/**
 * Tic-Tac-Toe naive implementation
 * 
 * @author Paul Brodner
 *
 */
public class Tic {
	char[] board = new char[10];
	int inputValue=0;
	
	private char[][] winCombinations = { 
			{ '1', '2', '3' }, { '4', '5', '6' },
			{ '7', '8', '9' }, { '1', '4', '7' }, 
			{ '2', '5', '8' }, { '3', '6', '9' }, 
			{ '1', '5', '9' }, { '3', '5', '7' } };
	Scanner scanner;

	public enum Player {
		A("Player A", 'x'), B("Player B", 'o');

		private final String name;
		private final char mark;

		private Player(final String name, final char mark) {
			this.name = name;
			this.mark = mark;
		}

		public String getName() {
			return name;
		}

		public char getMark() {
			return this.mark;
		}

	}

	public Tic() {
		scanner = new Scanner(System.in);
	}

	/**
	 * @param userName
	 *            the name displayed in game
	 * @param userMark
	 *            the mark value assigned to this user
	 */
	private void startPlayingWith(Player playerA, Player playerB) {
		for (int i = 1; i <= 9; i++) {
			if (i % 2 != 0) {
				usePlayerInputValue(playerA);
			} else {
				usePlayerInputValue(playerB);
			}
		}
	}

	/**
	 * Use the input value received from player
	 * The method will also validate some inputs
	 * 
	 * @param player
	 */
	private void usePlayerInputValue(Player player) {
		String inputMask = "%s, is your turn, please add your input!";
		System.out.println(String.format(inputMask, player.getName()));
		
		getChoiseFromScanner();
		
		if (inputValue < 1 || inputValue > 9) {
			System.out.println("Please add a valid choise [1-9]!");
			getChoiseFromScanner();
		}

		if (board[inputValue] != 0) {
			System.out.println("This board cell, has already been taken. Please try again!");
			getChoiseFromScanner();
		}
		else{
			board[inputValue] = player.getMark();
		}
		
	}
	
	/**
	 * Read inputs from System.in
	 */
	private void getChoiseFromScanner(){
		System.out.print("Choose:");
		try {
			inputValue = scanner.nextInt();
			scanner.nextLine();
		} catch (Exception e) {
			System.out.println("Please use only digits as your choise");
		}
	}

	/**
	 * Randomly pick a user to start with and ask for their choises.
	 * @throws IOException
	 */
	private void getChoiceFromRandomUser() throws IOException {
		float tirage = 0;
		tirage = new Random(new Date().getTime()).nextFloat();

		if (tirage < 0.5) {
			startPlayingWith(Player.A, Player.B);

		} else if (tirage >= 0.5) {
			startPlayingWith(Player.B, Player.A);
		}
	}

	/**
	 * Just a helper method for reading board values;
	 * 
	 * @param character
	 * @return
	 */
	private char getBoardValue(char character) {
		return board[Character.getNumericValue(character)];
	}

	/**
	 * @param player
	 * @return boolean value if the player is a winner.
	 */
	private boolean isWinner(Player player) {
		boolean isWinner = false;

		for (char[] winPositions : winCombinations) {

			if (getBoardValue(winPositions[0]) == player.getMark()
				&& getBoardValue(winPositions[1]) == player.getMark()
				&& getBoardValue(winPositions[2]) == player.getMark()) {
				System.out.println(String.format("\nThe winner is : %s. Checkout the '%s' mark.\n", player.getName(), player.getMark()));
				return true;
			}
		}
		return isWinner;
	}

	/**
	 * Evaluate the tic tac toe game. 
	 * @throws IOException
	 */
	void eval() throws IOException {
		getChoiceFromRandomUser();

		if (!isWinner(Player.A) && !isWinner(Player.B)){
			System.out.println("It seems we have a draw game!");
		}
		
		System.out.println("Results board:");
		for (int i = 1; i <= 9; i++) {
            System.out.print(board[i]);
            if (i == 3 || i == 6 || i == 9)
                System.out.print("\n");
        }
	}
}
