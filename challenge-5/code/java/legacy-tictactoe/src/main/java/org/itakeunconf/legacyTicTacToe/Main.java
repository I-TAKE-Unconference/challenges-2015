package org.itakeunconf.legacyTicTacToe;

import java.io.IOException;

public class Main {
	public static void main(String[] args) {
		Tic tic = new Tic(3);

		try {
			tic.eval();
		} catch (IOException exc) {
			exc.printStackTrace();
		}
		
		tic.printTable();
	}
}
