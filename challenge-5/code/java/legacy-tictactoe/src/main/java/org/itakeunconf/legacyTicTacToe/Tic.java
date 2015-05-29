package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;
import java.util.Date;
import java.util.Random;
import java.util.Scanner;

public class Tic {
	final static public char X_CHAR = 'x';
	final static public char O_CHAR = 'o';
	final static private Random random = new Random(new Date().getTime());
	final static private float FIFTY_PERCENT_TRESHOLD = 0.5f;

	final Scanner scanner = new Scanner(System.in);

	private char[] tab;
	private int tableSize;

	public Tic(int tableSize) {
		super();

		this.tableSize = tableSize;
		this.tab = new char[tableSize * tableSize + 1];
	}

	public void printTable() {
		for (int i = 1; i <= tableSize * tableSize; i++) {
			System.out.print(tab[i]);

			if (i % tableSize == 0) {
				System.out.print("\n");
			}
		}
	}

	void play() throws IOException {
		final int startingPlayerIndex = (random.nextFloat() < FIFTY_PERCENT_TRESHOLD) ? 1
				: 0;

		for (int i = 1; i <= tableSize * tableSize; i++) {
			readNextMove(i, i % 2 == startingPlayerIndex);
		}
	}

	private void readNextMove(int i, boolean firstPlayerIsNext) {
		if (firstPlayerIsNext) {
			System.out.print("player A:");
			tab[scanner.nextInt()] = X_CHAR;
		} else {
			System.out.print("player B:");
			tab[scanner.nextInt()] = O_CHAR;
		}

		scanner.nextLine();
	}

	void eval() throws IOException {
		play();

		displayWinner();
	}

	private void displayWinner() {
		if (firstPlayerWins()) {
			System.out.println("\nthe winner is : player A\n");
		}

		if (secondPlayerWins()) {
			System.out.println("\nthe winner is : player B\n");
		}
	}

	private boolean firstPlayerWins() {
		return isThereALine(X_CHAR);
	}

	private boolean secondPlayerWins() {
		return isThereALine(O_CHAR);
	}

	private boolean isThereALine(char playerName) {
		return isHorizontalLine(playerName) || isVerticalLine(playerName)
				|| isDiagonalLine(playerName);
	}

	private boolean isHorizontalLine(char playerName) {
		boolean cellHasPlayerName;

		for (int i = 1; i <= tableSize; i += tableSize) {
			cellHasPlayerName = true;

			for (int j = 0; (j < tableSize) && cellHasPlayerName; j++) {
				cellHasPlayerName = (tab[i + j] == playerName);
			}

			if (cellHasPlayerName) {
				return true;
			}
		}

		return false;
	}

	private boolean isVerticalLine(char playerName) {
		boolean cellHasPlayerName;

		for (int i = 1; i <= tableSize; i++) {
			cellHasPlayerName = true;

			for (int j = 0; (j < tableSize) && cellHasPlayerName; j++) {
				cellHasPlayerName = (tab[i + j * tableSize] == playerName);
			}

			if (cellHasPlayerName) {
				return true;
			}
		}

		return false;
	}

	private boolean isDiagonalLine(char playerName) {
		boolean upperDiagonal = true;
		boolean lowerDiagonal = true;

		for (int i = 1; i <= tableSize; i++) {
			upperDiagonal = upperDiagonal
					&& (tab[i + (i - 1) * tableSize] == playerName);
			lowerDiagonal = lowerDiagonal
					&& (tab[i * tableSize - (i - 1)] == playerName);
		}

		return upperDiagonal || lowerDiagonal;
	}
}
