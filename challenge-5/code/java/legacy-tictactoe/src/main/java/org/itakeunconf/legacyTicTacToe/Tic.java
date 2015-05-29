package org.itakeunconf.legacyTicTacToe;

import java.util.List;

public class Tic {
	CommandLine commandLine;
	GameRules gameRules;

	public Tic() {
		commandLine = new CommandLine();
		gameRules = new GameRules();
	}

	void eval() {
		run();
		commandLine.print(gameRules.getBoard());
	}

	private void run() {
		play();
		checkWinner();
	}

	private void play() {
		int boardPositions = gameRules.getBoardPositions();
		for (int i = 0; i < boardPositions; i++) {
			readPlayer(gameRules.getPlayerTurn());
		}
	}

	private void readPlayer(Player player) {
		commandLine.print(player.getName() + ":");
		gameRules.setBoardChoice(player, commandLine.getNumber());
	}

	private void checkWinner() {
		List<Player> winners = gameRules.getWinner();
		for (Player player : winners)
			commandLine.print("\nthe winner is : " + player.getName() + "\n\n");
	}

}