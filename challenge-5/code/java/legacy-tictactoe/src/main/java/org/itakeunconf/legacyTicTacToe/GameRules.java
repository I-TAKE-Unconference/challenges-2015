package org.itakeunconf.legacyTicTacToe;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Random;

public class GameRules {
	private List<Player> players = null;
	private Board board = new Board();

	Player getPlayerTurn() {
		if (players == null) {
			initializePlayers();
		}
		Player player = players.get(0);
		turnOver();
		return player;
	}

	private void initializePlayers() {
		players = new ArrayList<Player>();
		players.add(new Player("player A", 'x'));
		players.add(new Player("player B", 'o'));
		checkPlayersSequence();
	}

	private void checkPlayersSequence() {
		if (getTirage() >= 0.5) {
			turnOver();
		}
	}

	private void turnOver() {
		players.add(players.get(0));
		players.remove(0);
	}

	private float getTirage() {
		return (new Random(new Date().getTime())).nextFloat();
	}

	List<Player> getWinner() {
		List<Player> winners = new ArrayList<Player>();
		for (Player player : players) {
			if (board.isWinner(player.getMark()))
				winners.add(player);
		}
		return winners;
	}

	void setBoardChoice(Player player, int number) {
		board.setPositionWithMark(number, player.getMark());
	}

	String getBoard() {
		return board.toString();
	}

	int getBoardPositions() {
		return board.getCountPositions();
	}
}
