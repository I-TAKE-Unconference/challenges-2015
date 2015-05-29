package org.itakeunconf.legacyTicTacToe;

public class Player {
	String name;
	char mark;

	public Player(String name, char mark) {
		this.name = name;
		this.mark = mark;
	}

	public String getName() {
		return name;
	}

	public char getMark() {
		return mark;
	}
}
